using NUnit.Framework;
using System;
using System.Runtime.Serialization.Formatters;

namespace FootballTeam.Tests
{
    public class Tests
    {
        FootballTeam footballTeam;
        [SetUp]
        public void Setup()
        {
            footballTeam = new FootballTeam("Levski", 22);
        }
        [TearDown]
        public void TearDown()
        {
            footballTeam = null;
        }

        [Test]
        public void TestCtorDate()
        {
            const string name = "Levski";
            const int capaciti = 22;
            const int count = 0;
            Assert.That(footballTeam.Name, Is.EqualTo(name));
            Assert.That(footballTeam.Capacity, Is.EqualTo(capaciti));
            Assert.That(footballTeam.Players.Count, Is.EqualTo(count));

        }

        [Test]

        [TestCase(null)]
        public void TestCtorIvalidDataName(string name)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(name, 22));
        }
        [Test]

        [TestCase(14)]
        [TestCase(5)]
        [TestCase(-10)]
        public void TestCtorIvalidDataCapacity(int capaciti)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", capaciti));
        }

        [Test]
        public void TestAddNewPalyer()
        {
            FootballPlayer footballPlayer = new FootballPlayer("Gogo", 7, "Goalkeeper");
            footballTeam.AddNewPlayer(footballPlayer);
            Assert.That(footballTeam.Players.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestAddNewPalyerData()
        {
            FootballPlayer footballPlayer = new FootballPlayer("Gogo", 7, "Goalkeeper");
            footballTeam.AddNewPlayer(footballPlayer);
            Assert.That(footballTeam.Players[0].Name, Is.EqualTo("Gogo"));
            Assert.That(footballTeam.Players[0].PlayerNumber, Is.EqualTo(7));
            Assert.That(footballTeam.Players[0].Position, Is.EqualTo("Goalkeeper"));
        }

        [Test]
        public void TestAddNewPalyerWithInvalidData()
        {
            footballTeam = new FootballTeam("Levski", 15);
            FootballPlayer footballPlayer = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer2 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer3 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer4 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer5 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer6 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer7 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer8 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer9 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer10 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer11 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer12 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer13 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer14 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer15 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer footballPlayer16 = new FootballPlayer("Gogo", 7, "Goalkeeper");
            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(footballPlayer2);
            footballTeam.AddNewPlayer(footballPlayer3);
            footballTeam.AddNewPlayer(footballPlayer4);
            footballTeam.AddNewPlayer(footballPlayer5);
            footballTeam.AddNewPlayer(footballPlayer6);
            footballTeam.AddNewPlayer(footballPlayer7);
            footballTeam.AddNewPlayer(footballPlayer8);
            footballTeam.AddNewPlayer(footballPlayer9);
            footballTeam.AddNewPlayer(footballPlayer10);
            footballTeam.AddNewPlayer(footballPlayer11);
            footballTeam.AddNewPlayer(footballPlayer12);
            footballTeam.AddNewPlayer(footballPlayer13);
            footballTeam.AddNewPlayer(footballPlayer14);
            footballTeam.AddNewPlayer(footballPlayer15);

            string output = footballTeam.AddNewPlayer(footballPlayer16);

            Assert.That(output, Is.EqualTo("No more positions available!"));
        }

        [Test]
        public void testPickUpPlayer()
        {
            FootballPlayer gogo = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer mitko = new FootballPlayer("Mitio", 7, "Goalkeeper");
            FootballPlayer dimcho = new FootballPlayer("Dimcho", 7, "Goalkeeper");

            footballTeam.AddNewPlayer(gogo);
            footballTeam.AddNewPlayer(mitko);
            footballTeam.AddNewPlayer(dimcho);

            FootballPlayer exPlayer = footballTeam.PickPlayer("Gogo");

            Assert.That(gogo, Is.EqualTo(exPlayer));

        }

        [Test]
        public void testPlayerScore()
        {
            FootballPlayer player = new FootballPlayer("Gogo", 7, "Goalkeeper");

            footballTeam.AddNewPlayer(player);

            footballTeam.PlayerScore(7);


            Assert.That(footballTeam.PickPlayer("Gogo").ScoredGoals, Is.EqualTo(1));

        }

        [Test]
        public void testPlayerScoredata()
        {
            FootballPlayer player = new FootballPlayer("Gogo", 7, "Goalkeeper");

            footballTeam.AddNewPlayer(player);

            string output = footballTeam.PlayerScore(7);


            Assert.That(output, Is.EqualTo($"{player.Name} scored and now has {player.ScoredGoals} for this season!"));

        }
        [Test]
        public void testPickUpPlayerWithoutPlayer()
        {

            FootballPlayer exPlayer = footballTeam.PickPlayer("Gogo");

            Assert.AreEqual(exPlayer, null);

        }
        [Test]
        public void testPickUpPlayerWithoutPlayerwithsamename()
        {
            FootballPlayer gogo = new FootballPlayer("Gogo", 7, "Goalkeeper");
            FootballPlayer gogo2 = new FootballPlayer("Gogo", 6, "Goalkeeper");
            FootballPlayer dimcho = new FootballPlayer("Dimcho", 7, "Goalkeeper");

            footballTeam.AddNewPlayer(gogo);
            footballTeam.AddNewPlayer(gogo2);
            footballTeam.AddNewPlayer(dimcho);

            FootballPlayer exPlayer = footballTeam.PickPlayer("Gogo");

            Assert.AreEqual(exPlayer, gogo);

        }
    }
}