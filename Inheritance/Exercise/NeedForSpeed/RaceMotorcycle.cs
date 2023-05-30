namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {

        private const double RaceMotorcyvlrDefaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => RaceMotorcyvlrDefaultFuelConsumption;

        public override void Drive(double kilometers) => Fuel -= kilometers * FuelConsumption;

    }
}
