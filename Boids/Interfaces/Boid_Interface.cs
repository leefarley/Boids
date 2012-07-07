using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Boids;

namespace Boids.Interfaces
{
    public interface Boid_Interface
    {
        /// <summary>
        /// The point of this individual boid in 2D space. The actual point is arbitary, 
        /// and is mapped to the drawing area.
        /// </summary>
        Vector2 Position
        { get; set; }

        /// <summary>
        /// The current velocity of the boid, as a 2D vector.
        /// </summary>
        Vector2 Velocity
        { get; set; }
    }
}
