using System;
using System.IO;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string type;

            while ((type = Console.ReadLine()) != "Beast!")
            {
                try
                {

                    string[] tokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Animal animal = CreateAnima(tokens, type);

                    Console.WriteLine(animal.ProduceSound());


                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {

                    throw;
                }
            }







        }

        private static Animal CreateAnima(string[] tokens, string type)
        {

            string name = tokens[0];
            int age = int.Parse(tokens[1]);


            switch (type)
            {
                case "Dog":
                    string Doggender = tokens[2];
                    return new Dog(name, age, Doggender);
                case "Cat":
                    string Catgender = tokens[2];
                    return new Cat(name, age, Catgender);
                case "Frog":
                    string Froggender = tokens[2];
                    return new Frog(name, age, Froggender);
                case "Kitten":
                    return new Kitten(name, age);
                case "Tomcat":
                    return new Tomcat(name, age);

                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}
