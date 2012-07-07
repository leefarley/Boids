using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Boids
{

    /// <summary>
    /// The flock is responsible for a list of boids
    /// </summary>
    class Flock : Interfaces.Flock_Interface
    {
        const int flockMax = 20;
        const int flockMin = 3;
        Random rand;
        int mapwidth;
        int mapHeight;
        /// <summary>
        /// the constructor is responsible for creating the boids and give them values within the boid area
        /// </summary>
        public Flock(int flockSize, Random rand, List<Interfaces.BoidRule_Interface> rules,int width,int height)
        {
            this.rand = rand;
            boids = new List<Interfaces.Boid_Interface>();
            this.rules = rules;
            mapwidth = width;
            mapHeight = height;
            for (int i = 0; i < flockSize; i++)
            {
                int x = rand.Next(mapwidth);
                int y = rand.Next(mapHeight);
                int speedX = rand.Next(10);
                int speedY = rand.Next(10);
                Boid newBoid = new Boid(new Vector2(x, y), new Vector2(speedX, speedY));
                boids.Add(newBoid);
            }

            BoidColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        /// <summary>
        /// Stores the rules that the flock is to follow.
        /// </summary>
        public List<Interfaces.BoidRule_Interface> rules;

        /// <summary>
        /// Stores the boids that belong to this flock object.
        /// </summary>
        public List<Interfaces.Boid_Interface> boids;


        /// <summary>
        /// Stores the color that boids of this flock are drawn
        /// </summary>
        public System.Drawing.Color BoidColor{ get; set;}

        /// <summary>
        /// the amount of individual boids in the flock
        /// </summary>
        public int FlockSize
        {
            get
            {
                return boids.Count;
            }
        }

        /// <summary>
        /// gets boids that this flock class is responsible for
        /// </summary>
        /// <returns>IEnumerable<Interfaces.Boid_Interface></returns>
        public IEnumerable<Interfaces.Boid_Interface> getBoids()
        {
            return boids;
        }

        /// <summary>
        /// This method is responsible for calculating a new position and vecotor for each boid in the flock
        /// </summary>
        public void SimulateFlock()
        {
            List<Vector2> vectors;
            foreach (Interfaces.BoidRule_Interface rule in rules)
            {
                rule.boidList = boids;
            }

            foreach (Interfaces.Boid_Interface boid in boids)
            {
                vectors = new List<Vector2>();
                foreach (Interfaces.BoidRule_Interface rule in rules)
                {
                    if (rule.enabled)
                    {
                        
                        if (rule is Rules.LimitSpeed_Rule)
                        {
                            rule.implementRule(boid);
                        }
                        else
                        {
                            vectors.Add(rule.implementRule(boid));
                        }
                    }
                }

                Vector2 final = new Vector2();

                foreach (Vector2 vector in vectors)
                {
                    final += vector;
                }
                boid.Velocity += final;

                boid.Position += boid.Velocity;
            }
        }

        /// <summary>
        /// Adds a new boid to the flock
        /// </summary>
        public void addBoid()
        {
            if (FlockSize < flockMax)
            {
                int x = rand.Next(mapwidth);
                int y = rand.Next(mapHeight);
                int speedX = rand.Next(10);
                int speedY = rand.Next(10);
                boids.Add(new Boid(new Vector2(x, y), new Vector2(speedX, speedY)));
            }
        }

        /// <summary>
        /// removes the last boid from the flock
        /// </summary>
        public void removeBoid()
        {
            if (FlockSize > flockMin)
                boids.RemoveAt(boids.Count - 1);
        }
    }
}
