using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Boids.Tests
{
    class Boid_Test
    {
        Boid boid;
        Vector2 velocity;
        Vector2 position;
        [SetUp]
        public void SetUp()
        {
            velocity = new Vector2(10, 10);
            position = new Vector2(10, 10);
            boid = new Boid(position, velocity);
        }

        [Test]
        public void BoidIsNotNull_Test()
        {
            Assert.IsNotNull(boid);
        }

        [Test]
        public void BoidHasCorrectValues_Test()
        {
            Assert.AreEqual(velocity,boid.Velocity);
            Assert.AreEqual(position,boid.Position);
        }

        [Test]
        public void boidIsDerivedFromBoidInterface_Test()
        {
            Interfaces.Boid_Interface interfaceBoid = boid;
            Assert.AreSame(interfaceBoid, boid);
        }
    }
}
