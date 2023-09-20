using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate //solder
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        //public Private(string id, string firstName, string lastName, decimal salary)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Salary = salary;
        //}


        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:f2}";
        }
    }
}
