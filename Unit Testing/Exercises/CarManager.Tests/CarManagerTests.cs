namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Audi", "A4", 5.3, 45);
        }
        [TearDown]
        public void TearDoown()
        {
            car = null;
        }
        [Test]
        public void TestCreateCar()
        {
            car = new Car("Audi", "A4", 5.3, 45);

            Assert.AreEqual("Audi", car.Make);
            Assert.AreEqual("A4", car.Model);
            Assert.AreEqual(5.3, car.FuelConsumption);
            Assert.AreEqual(45, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void TestCreateCarPutInvalidData()
        {

            string expectedMessage = "Make cannot be null or empty!";
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car(null, "A4", 5.3, 45));

            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
        }
        [Test]
        public void TestCreateCarPutInvalidDataMake()
        {

            string expectedMessage = "Make cannot be null or empty!";
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car(null, "A4", 5.3, 45));

            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
        }
        [Test]
        public void TestCreateCarPutInvalidDataModel()
        {

            string expectedMessage = "Model cannot be null or empty!";
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Audi", null, 5.3, 45));

            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
        }
        [Test]
        public void TestCreateCarPutInvalidDataFuelConsumption()
        {

            string expectedMessage = "Fuel consumption cannot be zero or negative!";
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Audi", "A4", -1, 45));

            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
        }
        [Test]
        public void TestCreateCarPutInvalidDataFuelCapacity()
        {

            string expectedMessage = "Fuel capacity cannot be zero or negative!";
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Audi", "A4", 5.3, 0));

            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
        }
        [Test]
        public void TestRefuelCar()
        {
            const int expectedFuelAmount = 10;
            car.Refuel(10);

            Assert.That(expectedFuelAmount, Is.EqualTo(car.FuelAmount));
        }
        [Test]
        public void TestRefuelCarMoreThenCapacity()
        {
            const int expectedFuelAmount = 45;
            car.Refuel(50);

            Assert.That(expectedFuelAmount, Is.EqualTo(car.FuelAmount));
        }
        [Test]
        public void TestRefuelCarWithInvalidData()
        {
            string expectedMessage = "Fuel amount cannot be zero or negative!";
            ArgumentException ex = Assert.Throws<ArgumentException>(() => car.Refuel(0));

            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
        }
        [Test]
        public void TestDriveCar()
        {
            const double expectedFuelAmount = 5.3;
            car.Refuel(10.6);
            car.Drive(100);

            Assert.That(expectedFuelAmount, Is.EqualTo(car.FuelAmount));
        }
        [Test]
        public void TestDriveCarWithInvalidData()
        {
            const string exMessage = "You don't have enough fuel to drive!";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => car.Drive(10));
            Assert.That(exMessage, Is.EqualTo(exception.Message));
        }


    }
}