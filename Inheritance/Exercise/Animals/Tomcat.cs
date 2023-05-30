namespace Animals
{
    internal class Tomcat : Cat //male
    {
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }

        public override string ProduceSound() => "MEOW";


    }
}
