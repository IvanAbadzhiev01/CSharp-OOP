using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private List<int> converedExam;
        private IUniversity university;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;

            converedExam = new List<int>();
        }

        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => converedExam.AsReadOnly();

        public IUniversity University
        {
            get
            {
                return university;
            }

        }

        public void CoverExam(ISubject subject)
        {
            int subjectId = subject.Id;
            converedExam.Add(subjectId);

        }
        public void JoinUniversity(IUniversity university)
        {
            this.university = university;
        }
    }
}
