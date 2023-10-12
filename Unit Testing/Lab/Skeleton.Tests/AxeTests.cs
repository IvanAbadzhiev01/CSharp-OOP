using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test1()
        {
            Axe axe = new Axe(100, 100);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            //Assert.AreEqual(4, axe.DurabilityPoints);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(99), "Axe Durability doesn't change after attack.");
        }
        [Test]
        public void Test2()
        {
            Axe axe = new Axe(100, 0);
            Dummy dummy = new Dummy(100, 100);


            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}