using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Boids.Tests.Rule_Tests
{
    class DistancefromBoids_Test
    {
        Rules.DistanceFromBoids_Rule rule;
        Boid boid;
        List<Interfaces.Boid_Interface> boids;
        [SetUp]
        public void Setup()
        {
            rule = new Rules.DistanceFromBoids_Rule();
            boid = new Boid(new Vector2(), new Vector2());
            boids = new List<Interfaces.Boid_Interface>();
            boids.Add(boid);
        }

        [Test]
        public void Test_Constructor()
        {
            rule = new Rules.DistanceFromBoids_Rule();
        }

        [Test]
        public void Test_ReturnsAObject()
        {
            Assert.IsNotNull(rule.implementRule(boid));
        }
    }
}
