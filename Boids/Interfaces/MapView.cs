using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boids.Interfaces
{
    /// <summary>
    /// An interface for all map views.
    /// </summary>
    public interface MapView
    {
        /// <summary>
        /// Draw a number of boid flocks.
        /// </summary>
        /// <param name="flocks">Any enumerable collection of flock objects.</param>
        void drawBoids(IEnumerable<Flock_Interface> flocks);

    }
}
