namespace Vehicles.Models.Interfacs
{
    public interface IVehicle
    {

        double FuelQuantity { get; }
        double FuelConsumptionLitersPerKm { get; }

        string Drive(double distance);
        void Refuel(double amountFuel);

    }
}
