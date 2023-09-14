namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputPizza = Console.ReadLine()
                 .Split();

            string[] inputDough = Console.ReadLine()
                 .Split();
            string type = inputDough[0];
            string flourType = inputDough[1];
            string backingTechnique = inputDough[2];
            int weight = int.Parse(inputDough[3]);
            try
            {
                Dough dough = new(flourType, backingTechnique, weight);
                string name = inputPizza[1];
                Pizza pizza = new(name, dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {

                    string[] toppingInfo = command.Split();

                    string toppingType = toppingInfo[1];
                    int tppingWeight = int.Parse(toppingInfo[2]);

                    Topping topping = new(toppingType, tppingWeight);

                    pizza.AddTopping(topping);
                }


                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }
    }
}