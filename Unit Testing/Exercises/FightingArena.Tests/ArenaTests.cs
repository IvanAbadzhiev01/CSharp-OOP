namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }
        [TearDown]
        public void TearDown()
        {
            arena = null;
        }

        [Test]
        public void TestCreateArena()
        {
            arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void TestEnrollAddWorrior()
        {
            Warrior warrior = new Warrior("Ivan", 10, 100);
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
        }
        [Test]
        public void TestEnrollAddWorriorWithSameName()
        {
            const string exceptionMessage = "Warrior is already enrolled for the fights!";
            Warrior warrior = new Warrior("Ivan", 10, 100);
            Warrior warrior2 = new Warrior("Ivan", 20, 200);
            arena.Enroll(warrior);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }
        [Test]
        public void TestFightMethod()
        {
            const int exceptionDefenderHp = 90;
            Warrior atc = new Warrior("Ivan", 10, 100);
            Warrior def = new Warrior("Misho", 5, 100);
            arena.Enroll(atc);
            arena.Enroll(def);
            arena.Fight(atc.Name, def.Name);

            Assert.AreEqual(exceptionDefenderHp, def.HP);
        }
        [Test]
        public void TestFightMethodWithoutDeffender()
        {
            Warrior def = new Warrior("Misho", 5, 100);
            string exceptionMessage = $"There is no fighter with name {def.Name} enrolled for the fights!";
            Warrior atc = new Warrior("Ivan", 10, 100);
            arena.Enroll(atc);
            //arena.Enroll(def);
            //arena.Fight(atc.Name, def.Name);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Fight(atc.Name, def.Name));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }
        [Test]
        public void TestFightMethodWithoutAttacer()
        {
            Warrior atc = new Warrior("Ivan", 10, 100);
            string exceptionMessage = $"There is no fighter with name {atc.Name} enrolled for the fights!";
            Warrior def = new Warrior("Misho", 5, 100);
            arena.Enroll(def);
            //arena.Enroll(def);
            //arena.Fight(atc.Name, def.Name);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Fight(atc.Name, def.Name));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }
    }
}
