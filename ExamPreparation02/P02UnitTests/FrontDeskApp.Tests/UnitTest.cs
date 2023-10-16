using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("BestHotel", 4);
        }

        [Test]
        public void CtorTest()
        {
            hotel = new Hotel("BestHotel", 4);
            Assert.AreEqual("BestHotel", hotel.FullName);
            Assert.AreEqual(4, hotel.Category);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]


        public void TestFullNameInvalidData(string name)
        {

            Assert.Throws<ArgumentNullException>(() => new Hotel(name, 4));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(6)]
        public void TestCategoriWithInvalidDate(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Best", category));
        }
        [Test]
        public void AddRoomTest()
        {
            Room room = new Room(10, 100);

            hotel.AddRoom(room);

            Assert.AreEqual(hotel.Rooms.Count, 1);
        }


        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoomInvalidDataAdults(int adults)
        {
            Room room = new Room(10, 100);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 2, 3, 200));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-1)]

        public void BookRoomInvalidDataChil(int chil)
        {
            Room room = new Room(10, 100);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, chil, 3, 200));
        }
        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoomInvalidDataDurat(int durat)
        {
            Room room = new Room(10, 100);

            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 2, durat, 200));
        }

        [Test]
        public void TestBookRoom()
        {
            Room room = new Room(2, 100);
            hotel.AddRoom(room);


            hotel.BookRoom(2, 0, 1, 300);

            Assert.AreEqual(100, hotel.Turnover);
        }

        [Test]
        public void TestBokroomInvalidData()
        {
            Room room = new Room(3, 100);
            hotel.AddRoom(room);

            hotel.BookRoom(4, 1, 2, 100);

            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void TestBookRoomInvalidBudget()
        {
            Room room = new Room(2, 100);
            hotel.AddRoom(room);


            hotel.BookRoom(2, 0, 1, 50);

            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void BookRoomBooks()
        {
            Room room = new Room(5, 70);
            hotel.AddRoom(room);


            hotel.BookRoom(4, 1, 2, 150);

            Assert.AreEqual(hotel.Turnover, 140);
            Assert.AreEqual(hotel.Bookings.Count, 1);
            Assert.AreEqual(hotel.Rooms.Count, 1);
        }
    }
}