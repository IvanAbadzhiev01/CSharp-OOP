using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {

        const double DEFALT_HumanitySubject_RATE = 1.15;
        public HumanitySubject(int subjectId, string subjectName) : base(subjectId, subjectName, DEFALT_HumanitySubject_RATE)
        {
        }
    }
}
