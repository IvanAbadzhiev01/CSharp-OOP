namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Ivan", 10, 100);
        }
        [TearDown]
        public void TearDown()
        {
            warrior = null;
        }
        [Test]
        public void CreateWarrior()
        {
            Assert.AreEqual("Ivan", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }
        [Test]

        [TestCase(" ")]
        [TestCase(null)]
        public void CreteWarriorInvalidName(string name)
        {
            const string exceptionMessage = "Name should not be empty or whitespace!";

            ArgumentException ax = Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 100));

            Assert.AreEqual(exceptionMessage, ax.Message);
        }
        [Test]

        [TestCase(-1)]
        [TestCase(0)]
        public void CreteWarriorInvalidDamage(int damage)
        {
            const string exceptionMessage = "Damage value should be positive!";

            ArgumentException ax = Assert.Throws<ArgumentException>(() => new Warrior("Ivan", damage, 100));

            Assert.AreEqual(exceptionMessage, ax.Message);
        }
        [Test]


        public void CreteWarriorInvalidHp()
        {
            const string exceptionMessage = "HP should not be negative!";

            ArgumentException ax = Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 10, -1));

            Assert.AreEqual(exceptionMessage, ax.Message);
        }

        [Test]
        public void TestAttackShouldThrowIfHPLessThan30()
        {
            const string exceptionMessage = "Your HP is too low in order to attack other warriors!";
            Warrior atc = new Warrior("Mtko", 10, 20);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => atc.Attack(warrior));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }
        [Test]
        public void TestAttackShouldThrowIfHPLessThan30Deffender()
        {
            const int MIN_ATTACK_HP = 30;
            string exceptionMessage = $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!";
            Warrior dfe = new Warrior("Mtko", 10, 10);
            //warrior = new Warrior("Ivan", 10, 10);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(dfe));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public void TestAttackEnemyWitnSmallHp()
        {
            //const int MIN_ATTACK_HP = 30;
            string exceptionMessage = "You are trying to attack too strong enemy";
            Warrior atc = new Warrior("Mtko", 10, 100);
            warrior = new Warrior("Ivan", 110, 100);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => atc.Attack(warrior));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public void TestAttackEnemyWitnBigestDamage()
        {

            Warrior atc = new Warrior("Mtko", 110, 100);

            atc.Attack(warrior);

            Assert.AreEqual(0, warrior.HP);
        }

        [Test]
        public void TestAttack()
        {

            Warrior atc = new Warrior("Mtko", 10, 100);

            atc.Attack(warrior);

            Assert.AreEqual(90, warrior.HP);
        }

        [Test]
        public void TestAttack2()
        {

            Warrior atc = new Warrior("Mtko", 10, 100);

            atc.Attack(warrior);

            Assert.AreEqual(90, atc.HP);
        }
    }
}