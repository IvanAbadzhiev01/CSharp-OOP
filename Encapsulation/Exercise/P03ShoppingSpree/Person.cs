namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProduct;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProduct = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {

                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> BagOfProduct => bagOfProduct;

        public void AddProduct(Product product)
        {
            if (money >= product.Cost)
            {

                bagOfProduct.Add(product);
                this.money -= product.Cost;
            }
            else
            {
                throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
            }


        }
        public override string ToString()
        {
            if (this.BagOfProduct.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            var products = this.bagOfProduct.Select(p => p.Name);

            return $"{this.Name} - {string.Join(", ", products)}";
        }


    }
}
