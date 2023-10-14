namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using static NUnit.Framework.Constraints.Tolerance;
    using System.Reflection.Metadata;

    [TestFixture]
    public class ExtendedDatabaseTests
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
        public void TestAddMethodAddPerson()
        {
            const int expectedLengt = 1;
            Person person = new Person(980913, "Ivan");
            _database.Add(person);
            int lengtDatabase = _database.Count;
            Assert.That(expectedLengt, Is.EqualTo(lengtDatabase));
        }
        [Test]
        public void TestAddMethodToThrowExceptionToAddMore16thPerson()
        {
            string exceptionExpectedMessage = "Array's capacity must be exactly 16 integers!";
            Person[] persons =
            {
                new Person(1,"Ivan1"),
                new Person(2,"Ivan2"),
                new Person(3,"Ivan3"),
                new Person(4,"Ivan4"),
                new Person(5,"Ivan5"),
                new Person(6,"Ivan6"),
                new Person(7,"Ivan7"),
                new Person(8,"Ivan8"),
                new Person(9,"Ivam9"),
                new Person(10,"Ivan10"),
                new Person(11,"Ivan11"),
                new Person(12,"Ivan12"),
                new Person(13,"Ivan13"),
                new Person(14,"Ivan14"),
                new Person(15,"Ivan15"),
                new Person(16, "Ivan16")
            };

            _database = new Database(persons);

            Person lastPersonAdd = new Person(17, "Ivan17");

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _database.Add(lastPersonAdd));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));
        }
        [Test]
        public void TestAddMethodToAddPersonWithSameNames()
        {
            string exceptionExpectedMessage = "There is already user with this username!";
            Person person = new Person(1, "Ivan");
            _database = new Database(person);

            Person personWithsameName = new Person(2, "Ivan");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _database.Add(personWithsameName));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));
        }

        [Test]
        public void TestAddMethodToAddPersonWithSameId()
        {
            string exceptionExpectedMessage = "There is already user with this Id!";
            Person person = new Person(1, "Ivan1");
            _database = new Database(person);

            Person personWithSameId = new Person(1, "Ivan2");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _database.Add(personWithSameId));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));
        }

        [Test]
        public void TestAddRangeMethodToAcceptMore16ThParams()
        {
            string exceptionExpectedMessage = "Provided data length should be in range [0..16]!";
            Person[] persons =
            {
                new Person(1,"Ivan1"),
                new Person(2,"Ivan2"),
                new Person(3,"Ivan3"),
                new Person(4,"Ivan4"),
                new Person(5,"Ivan5"),
                new Person(6,"Ivan6"),
                new Person(7,"Ivan7"),
                new Person(8,"Ivan8"),
                new Person(9,"Ivam9"),
                new Person(10,"Ivan10"),
                new Person(11,"Ivan11"),
                new Person(12,"Ivan12"),
                new Person(13,"Ivan13"),
                new Person(14,"Ivan14"),
                new Person(15,"Ivan15"),
                new Person(16, "Ivan16"),
                new Person(17, "Ivan17")
        };





            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Database(persons));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));
        }

        [Test]
        public void TestAddRangeMethodAddPersons()
        {
            const int expectedLengt = 5;
            Person[] persons =
                {
                new Person(1, "Ivan1"),
                new Person(2, "Ivan2"),
                new Person(3, "Ivan3"),
                new Person(4, "Ivan4"),
                new Person(5, "Ivan5")
                };
            _database = new Database(persons);
            int lengtDatabase = _database.Count;
            Assert.That(expectedLengt, Is.EqualTo(lengtDatabase));
        }
        [Test]
        public void TestRemoveOnEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => _database.Remove());
        }
        [Test]
        public void TestRemoveMethodRemvePerson()
        {
            const int expectedCount = 1;
            Person[] persons =
                {
                new Person(1, "Ivan1"),
                new Person(2, "Ivan2")
                };

            _database = new Database(persons);

            _database.Remove();

            Assert.That(expectedCount, Is.EqualTo(_database.Count));

        }

        [Test]
        public void TestFindByUsernameGetPerson()
        {
            _database = new Database(new Person(1, "Ivan"), new Person(2, "GoShow"));
            Person personIvan = new Person(1, "Ivan");
            Person personGoShow = new Person(2, "GoShow");
            Person expectedPersonIvan = _database.FindByUsername("Ivan");
            Person expectedPersonGoShow = _database.FindByUsername("GoShow");
            Assert.That(personIvan.UserName, Is.EqualTo(expectedPersonIvan.UserName));
            Assert.That(personGoShow.UserName, Is.EqualTo(expectedPersonGoShow.UserName));

        }
        [Test]
        public void TestFindByUsernameGetEmptyPerson()
        {
            string exceptionExpectedMessage = "No user is present by this username!";
            const string notExistUsernameInDatabase = "Pesho";
            _database = new Database(new Person(1, "Ivan"), new Person(2, "GoShow"));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _database.FindByUsername(notExistUsernameInDatabase));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));


        }

        [Test]
        public void TestFindByUsernameEmptyData()
        {
            string exceptionExpectedMessage = "Value cannot be null. (Parameter 'Username parameter is null!')";

            string EmptyString = string.Empty;

            _database = new Database(new Person(1, "Ivan"), new Person(2, "GoShow"));

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _database.FindByUsername(EmptyString));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));


        }

        [Test]
        public void TestFindByIdGetPerson()
        {
            _database = new Database(new Person(1, "Ivan"), new Person(2, "GoShow"));
            Person personIvan = new Person(1, "Ivan");
            Person personGoShow = new Person(2, "GoShow");
            Person expectedPersonIvan = _database.FindById(1);
            Person expectedPersonGoShow = _database.FindById(2);
            Assert.That(personIvan.Id, Is.EqualTo(expectedPersonIvan.Id));
            Assert.That(personGoShow.Id, Is.EqualTo(expectedPersonGoShow.Id));

        }

        [Test]
        public void TestFindByIdGetEmptyPerson()
        {
            string exceptionExpectedMessage = "No user is present by this ID!";
            const int notExistIdInDatabase = 3;
            _database = new Database(new Person(1, "Ivan"), new Person(2, "GoShow"));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _database.FindById(notExistIdInDatabase));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));
        }

        [Test]
        public void TestFindByIdNegativeId()
        {
            string exceptionExpectedMessage = "Specified argument was out of the range of valid values. (Parameter 'Id should be a positive number!')";

            const int negativeNumber = -1;

            _database = new Database(new Person(1, "Ivan"), new Person(2, "GoShow"));

            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => _database.FindById(negativeNumber));

            Assert.That(exceptionExpectedMessage, Is.EqualTo(ex.Message));


        }
        [Test]
        public void TestPersonInitilaze()
        {
            const int expectedId = 1;
            const string expectedUserName = "Ivan";
            Person person = new Person(1, "Ivan");

            Assert.That(expectedId, Is.EqualTo(person.Id));
            Assert.That(expectedUserName, Is.EqualTo(person.UserName));
        }

    }
}