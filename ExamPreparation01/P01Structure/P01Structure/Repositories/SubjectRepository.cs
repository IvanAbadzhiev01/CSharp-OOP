using System.Collections.Generic;
using UniversityCompetition.Models;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Models.Contracts;
using System.Linq;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        public List<ISubject> models;
        public SubjectRepository()
        {
            models = new List<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => models.AsReadOnly();

        public void AddModel(ISubject model)
        {
            ISubject subject = null;
            if (model is TechnicalSubject)
            {
                subject = new TechnicalSubject(models.Count + 1, model.Name);
            }
            if (model is EconomicalSubject)
            {
                subject = new EconomicalSubject(models.Count + 1, model.Name);
            }
            if (model is HumanitySubject)
            {
                subject = new HumanitySubject(models.Count + 1, model.Name);
            }
            models.Add(subject);
        }



        public ISubject FindById(int id) => models.FirstOrDefault(s => s.Id == id);


        public ISubject FindByName(string name) => models.FirstOrDefault(s => s.Name == name);

    }

}
