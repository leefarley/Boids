using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Boids.Tests
{
    class Flock_Test
    {
        Flock flock;
        int flockSize;
        List<Interfaces.BoidRule_Interface> rules;

        [SetUp]
        public void SetUp()
        {
            flockSize = 5;
            Random rand = new Random();
            rules = new List<Interfaces.BoidRule_Interface>();
            flock = new Flock(flockSize, rand, rules, 500, 500);
        }

        [Test]
        public void FlockIsNotNull_Test()
        {
            Assert.IsNotNull(flock);
        }

        [Test]
        public void FlockHasRightAmountOfBoids_Test()
        {
            Assert.AreEqual(flockSize, flock.FlockSize);
        }

        [Test]
        public void FlockAddedsABoid_Test()
        {
            flock.addBoid();
            Assert.AreEqual(flockSize+1, flock.FlockSize);
        }

        [Test]
        public void FlockCannotHaveLessThanThree_Test()
        {
            for (int i = 0; i < flockSize; i++)
            {
                flock.removeBoid(); 
            }
            
            Assert.AreEqual(3, flock.FlockSize);
        }

        [Test]
        public void FlockCannotHaveMoreThanTwenty_Test()
        {
            for (int i = 0; i < 25; i++)
            {
                flock.addBoid();
            }

            Assert.AreEqual(20, flock.FlockSize);
        }

        [Test]
        public void FlockRemovesABoid_Test()
        {
            flock.removeBoid();
            Assert.AreEqual(flockSize - 1, flock.FlockSize);
        }

        [Test]
        public void FlockSimulate_Test()
        {
            Vector2 position = flock.getBoids().First().Position;
            position += flock.getBoids().First().Velocity;
            flock.SimulateFlock();
            Assert.AreEqual(position.X,flock.getBoids().First().Position.X);
            Assert.AreEqual(position.Y, flock.getBoids().First().Position.Y);
        }

        [Test]
        public void FlockSimulateWithRules_Test()
        {
            Vector2 position = flock.getBoids().First().Position;
            position += flock.getBoids().First().Velocity;
            rules.Add(new Rules.CentreOfFlock_Rule());
            rules.Add(new Rules.DistanceFromBoids_Rule());
            rules.Add(new Rules.MatchVelocity_Rule());
            rules.Add(new Rules.LimitSpeed_Rule());
            
            flock.SimulateFlock();
            Assert.AreNotEqual(position, flock.getBoids().First().Position);
        }

        [Test]
        public void FlockSimulateDisableRules_Test()
        {
            Vector2 position = flock.getBoids().First().Position;
            rules.Add(new Rules.CentreOfFlock_Rule { enabled = false});
            rules.Add(new Rules.DistanceFromBoids_Rule { enabled = false });
            rules.Add(new Rules.MatchVelocity_Rule { enabled = false });
            position += flock.getBoids().First().Velocity;
            flock.SimulateFlock();
            Assert.AreEqual(position.X, flock.getBoids().First().Position.X);
            Assert.AreEqual(position.Y, flock.getBoids().First().Position.Y);
        }

        [Test]
        public void FlockIsDerivedFromFlockInterface_Test()
        {
            Interfaces.Flock_Interface interfaceBoid = flock;
            Assert.AreSame(interfaceBoid, flock);
        }
    }
}
