namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double SportCarDefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => SportCarDefaultFuelConsumption;

        public override void Drive(double kilometers) => Fuel -= kilometers * FuelConsumption;

    }
}
