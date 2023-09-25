namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double increasedConsumptionCar = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionLitersPerKm) : base(fuelQuantity, fuelConsumptionLitersPerKm, increasedConsumptionCar)
        {
        }
    }
}
