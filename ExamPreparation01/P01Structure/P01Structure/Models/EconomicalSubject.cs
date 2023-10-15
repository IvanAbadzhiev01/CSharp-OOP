namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        const double DEFALT_EconomicalSubject_RATE = 1.0;
        public EconomicalSubject(int subjectId, string subjectName) : base(subjectId, subjectName, DEFALT_EconomicalSubject_RATE)
        {
        }
    }
}
