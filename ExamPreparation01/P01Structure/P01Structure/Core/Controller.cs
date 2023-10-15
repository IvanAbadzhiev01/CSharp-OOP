using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{


    public class Controller : IController
    {
        private string[] subjectTypesAll = new string[]
         {
            "TechnicalSubject",
            "EconomicalSubject",
            "HumanitySubject"
         };


        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            students.AddModel(new Student(0, firstName, lastName));

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (!subjectTypesAll.Contains(subjectType))
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            Subject subject = null;
            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(0, subjectName);
            }
            if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(0, subjectName);
            }
            if (subjectType == "HumanitySubject")
            {
                subject = new HumanitySubject(0, subjectName);
            }

            subjects.AddModel(subject);

            return String.Format(OutputMessages.SubjectAddedSuccessfully, subject.GetType().Name, subjectName, subjects.GetType().Name);

        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requarerdSubjectAsInt = requiredSubjects.Select(s => subjects.FindByName(s).Id).ToList();

            University university = new University(0, universityName, category, capacity, requarerdSubjectAsInt);
            universities.AddModel(university);

            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);

        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] names = studentName.Split();
            IStudent student = students.FindByName(studentName);
            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, names[0], names[1]);
            }
            IUniversity university = universities.FindByName(universityName);
            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            foreach (var requaredExam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(requaredExam))
                {
                    return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, names[0], names[1], universityName);
            }

            student.JoinUniversity(university);
            return String.Format(OutputMessages.StudentSuccessfullyJoined, names[0], names[1], universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            if (student == null)
            {
                return String.Format(OutputMessages.InvalidStudentId);
            }
            ISubject subject = subjects.FindById(subjectId);
            if (subject == null)
            {
                return String.Format(OutputMessages.InvalidSubjectId);
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);


            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);


        }

        public string UniversityReport(int universityId)
        {
            StringBuilder sb = new();
            IUniversity university = universities.FindById(universityId);

            sb.AppendLine($"*** {university.Name} ***");

            sb.AppendLine($"Profile: {university.Category}");

            sb.AppendLine($"Students admitted: {CountStudentInUni(university)}");
            sb.AppendLine($"University vacancy: {university.Capacity - (CountStudentInUni(university))}");
            return sb.ToString().TrimEnd();
        }

        private int CountStudentInUni(IUniversity university)
        {
            int count = 0;
            foreach (var stude in students.Models)
            {
                if (stude.University?.Id == university.Id)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
