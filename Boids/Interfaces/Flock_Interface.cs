using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Boids.Interfaces
{
    /// <summary>
    /// Interface for a flock of boids.
    /// </summary>
    public interface Flock_Interface
    {
        /// <summary>
        /// Get the color to draw the individual boids.
        /// </summary>
        Color BoidColor
        { get; set; }

        /// <summary>
        /// Get the number of Boids in the flock. Setting this should
        /// create or remove Boids as required to make the flock the 
        /// given size.
        /// </summary>
        int FlockSize
        { get; }

        /// <summary>
        /// Get all the boids.
        /// </summary>
        /// <returns>An enumerable of boids.</returns>
        IEnumerable<Boid_Interface> getBoids();

        /// <summary>
        /// Simulate all boids in this flock one step forwards.
        /// </summary>
        void SimulateFlock();
    }
}
