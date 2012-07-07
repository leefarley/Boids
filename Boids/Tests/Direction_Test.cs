using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Boids.Tests
{
    class Direction_Test
    {
        Direction direction;
        Vector2 directionVector;
        string directionName;
        [SetUp]
        public void Setup()
        {
            directionName = "North";
            directionVector = new Vector2(0,-1);
            direction = new Direction(directionName, directionVector);
        }

        [Test]
        public void directionInit_Test()
        {
            Assert.IsNotNull(direction);
        }

        [Test]
        public void correctToStringOverrides_Test()
        {
            Assert.AreEqual(directionName, direction.ToString());
        }
    }
}
