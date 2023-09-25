namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double increasedConsumptionTruck = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionLitersPerKm) : base(fuelQuantity, fuelConsumptionLitersPerKm, increasedConsumptionTruck)
        {
        }


        public override void Refuel(double amountFuel)
        {
            base.Refuel(amountFuel * 0.95);
        }
    }
}
