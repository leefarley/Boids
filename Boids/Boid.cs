using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boids
{
    class Boid : Interfaces.Boid_Interface
    {
        /// <summary>
        /// The position to draw the boid.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Current velocity that the Boid is to move by for every step.
        /// </summary>
        public Vector2 Velocity { get; set; }

        

        /// <summary>
        /// Constructor for the boid class.
        /// </summary>
        /// <param name="rules">List<Interfaces.BoidRule_Interface></param>
        /// <param name="position">Vector2</param>
        /// <param name="velocity">Vector2</param>
        public Boid(Vector2 position, Vector2 velocity)
        {
            this.Velocity = velocity;
            this.Position = position;
        }
    }
}
