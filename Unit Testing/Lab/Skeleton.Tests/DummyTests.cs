using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test1()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.That(dummy.Health, Is.EqualTo(5), "Dummy heltht is not down after TakeAttackMethod");
        }
        [Test]
        public void Test2()
        {
            Dummy dummy = new Dummy(0, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
        }

        [Test]
        public void Test3()
        {
            Dummy dummy = new Dummy(0, 100);

            int exp = dummy.GiveExperience();
            Assert.That(exp, Is.EqualTo(100), "Dummy not retur experiance after dead!");
        }
        [Test]
        public void Test4()
        {
            Dummy dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Dummy return exp befor dead!");
        }
    }
}