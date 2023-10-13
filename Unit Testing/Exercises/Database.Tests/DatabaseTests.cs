namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _database;
        [SetUp]
        public void SetUp()
        {
            _database = new Database();
        }


        [TearDown]
        public void TearDown()
        {
            _database = null;
        }
        [Test]
        public void AddElementTest()
        {
            const int numberToAddDatabase = 5;
            const int index = 0;
            const int countElementInDatabase = 1;
            _database.Add(numberToAddDatabase);
            int[] getDatabaseAddNumber = _database.Fetch();


            Assert.AreEqual(countElementInDatabase, _database.Count);
            Assert.AreEqual(numberToAddDatabase, getDatabaseAddNumber[index]);
        }

        [Test]
        public void AddThrowException()
        {
            _database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => _database.Add(17));
        }
        [Test]
        public void RemoveMethodRemoveLastElement_Database()
        {
            _database = new Database(1, 2);

            _database.Remove();

            int[] result = _database.Fetch();

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, _database.Count);
            Assert.AreEqual(1, result.Length);
        }
        [Test]
        public void RemoveElementToEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => _database.Remove());
        }
        [Test]
        public void CreadeDatabase10Element()
        {
            _database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Assert.AreEqual(10, _database.Count);
        }
        [Test]
        public void FechTestReturn()
        {
            _database = new Database(1, 2, 3, 4, 5);
            int[] ints = new int[] { 1, 2, 3, 4, 5 };
            Assert.AreEqual(ints, _database.Fetch());

        }


    }
}
