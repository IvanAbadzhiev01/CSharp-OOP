namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        const double DEFALT_TechnicalSubject_RATE = 1.3;
        public TechnicalSubject(int subjectId, string subjectName) : base(subjectId, subjectName, DEFALT_TechnicalSubject_RATE)
        {
        }
    }
}
