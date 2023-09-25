using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfacs;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }
        public void Run()
        {
            string[] carData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckData = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicleFactory factory = new VehicleFactory();

            try
            {
                vehicles.Add(factory.Create(carData[0], double.Parse(carData[1]), double.Parse(carData[2])));
                vehicles.Add(factory.Create(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2])));
            }
            catch (ArgumentException ex)
            {

                writer.WriteLine(ex.Message);
            }

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string method = data[0];
                string typeVehicle = data[1];
                double value = double.Parse(data[2]);
                try
                {

                    ProcesCommadn(method, typeVehicle, value);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }

        }

        private void ProcesCommadn(string method, string typeVehicle, double value)
        {
            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == typeVehicle);

            if (vehicle == null)
            {
                Console.WriteLine("Invalid vehicle type");
            }

            if (method == "Drive")
            {
                writer.WriteLine(vehicle.Drive(value));
            }
            else if (method == "Refuel")
            {
                vehicle.Refuel(value);
            }

        }

    }
}
