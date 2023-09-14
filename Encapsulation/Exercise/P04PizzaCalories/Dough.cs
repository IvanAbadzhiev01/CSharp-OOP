namespace PizzaCalories
{
    public class Dough
    {


        private readonly Dictionary<string, double> ModifiersKvp = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0},
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0 }
        };
        private string flourType;
        private string bakingTechnique;
        private int weigth;

        public Dough(string flourType, string bakingTechnique, int weigth)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weigth = weigth;
        }
        public int Weigth
        {
            get { return weigth; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weigth = value;
            }
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!ModifiersKvp.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {

                if (!ModifiersKvp.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }

        }

        public double Calories => 2 * weigth * ModifiersKvp[FlourType.ToLower()] * ModifiersKvp[BakingTechnique.ToLower()];
    }
}
