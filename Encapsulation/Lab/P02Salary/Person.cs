namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal selary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Selary = selary;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Selary { get; private set; }


        public void IncreaseSalary(decimal percentage)
        {
            if (Age > 30)
            {
                Selary += +Selary * percentage / 100;
            }
            else
            {
                Selary += Selary * percentage / 200;
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Selary:f2} leva.";
        }
    }
}
