using Vehicles.Models.Interfacs;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {

        private double increasedConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsumptionLitersPerKm, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionLitersPerKm = fuelConsumptionLitersPerKm;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionLitersPerKm { get; private set; }

        public string Drive(double distance)
        {
            double consumption = FuelConsumptionLitersPerKm + this.increasedConsumption;
            double needFuel = distance * consumption;
            if (needFuel <= FuelQuantity)
            {
                FuelQuantity -= needFuel;
                return $"{GetType().Name} travelled {distance} km";

            }

            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        public virtual void Refuel(double amountFuel)
        {
            FuelQuantity += amountFuel;
        }

        public override string ToString()
       => $"{this.GetType().Name}: {FuelQuantity:F2}";

    }
}
