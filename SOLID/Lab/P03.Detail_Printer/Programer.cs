
using P03.DetailPrinter;

namespace P03.Detail_Printer
{
    public class Programer : Employee
    {
        public Programer(string name, int id) : base(name)
        {
            Id = id;
        }

        public int Id { get; set; }


        public override string ToString()
        {
            return $"{base.ToString()} With id: {Id}";
        }
    }
}
