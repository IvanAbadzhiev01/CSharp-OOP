using System.Text;
using System;

namespace Person
{
    public class Person
    {

        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }

        public override string ToString() => $"Name: {this.Name}, Age: {this.Age}";


    }
}
