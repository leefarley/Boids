using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Boids.Tests
{
    class BoidsFactory_Test
    {
        Boids_Factory factory;

        [SetUp]
        public void SetUp()
        {
            Random rand = new Random();
            BasicMapView map = new BasicMapView(new System.Windows.Forms.Panel());
            factory = new Boids_Factory(rand, map, 500, 500);
        }

        [Test]
        public void FactoryIsNotNull_Test()
        {
            Assert.IsNotNull(factory);
        }

        [Test]
        public void hasOneFlockToBeginWith_Test()
        {
            int flockCount = 1;
            Assert.AreEqual(flockCount,factory.flockCount);
        }

        [Test]
        public void AddingBoids_Test()
        {
            int flockCount = 3;
            factory.flockSizeChange(flockCount);
            ++flockCount;
            factory.flockSizeChange(flockCount);
            Assert.AreEqual(flockCount, factory.flockSize);
        }

        [Test]
        public void RemovingBoids_Test()
        {
            int flockCount = 3;
            factory.flockSizeChange(flockCount);
            --flockCount;
            factory.flockSizeChange(flockCount);
            Assert.AreEqual(flockCount, factory.flockSize);
        }

        [Test]
        public void AddingFlocks_Test()
        {
            int flockCount = 2;
            factory.newFlock();
            Assert.AreEqual(flockCount, factory.flockCount);
        }

        [Test]
        public void RemovingFlocks_Test()
        {
            int flockCount = 1;
            factory.newFlock();
            factory.removeFlock();
            Assert.AreEqual(flockCount, factory.flockCount);
        }

        [Test]
        public void CannotHaveMoreThanFifteenFlocks_Test()
        {
            int flockCount = 15;
            for (int i = 0; i < 16; i++)
            {
                factory.newFlock();
            }
            Assert.AreEqual(flockCount, factory.flockCount);
        }

        [Test]
        public void CannotHaveLessThanOneFlock_Test()
        {
            int flockCount = 1;
            factory.removeFlock();
            Assert.AreEqual(flockCount, factory.flockCount);
        }

        [Test]
        public void SimulationStep_Test()
        {
            factory.step();
            //not sure how i am going to test this one.
        }
    }
}
