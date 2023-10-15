using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        public List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => models.AsReadOnly();

        public void AddModel(IStudent model)
        {
            Student student = new Student(models.Count + 1, model.FirstName, model.LastName);
            models.Add(student);
        }

        public IStudent FindById(int id) => models.FirstOrDefault(s => s.Id == id);


        public IStudent FindByName(string name)
        {
            string[] nameArgs = name.Split();

            string firstName = nameArgs[0];
            string lastName = nameArgs[1];

            return models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }

    }
}
