using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            Price = price;
        }
        public string Name
        {
            get => name;
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

                }
                name = value;
            }
        }

        public double Price { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} - {Price:F2} lv");
            return sb.ToString().TrimEnd();
        }
    }
}
