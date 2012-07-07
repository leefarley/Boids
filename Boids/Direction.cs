using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boids
{
    /// <summary>
    /// This class is responsible for storing the vector to push boids in a particular direction
    /// </summary>
    class Direction : Interfaces.Direction_Interface
    {
        /// <summary>
        /// The direction that the vector will push the boids
        /// </summary>
        public string directionName { get; private set; }
        /// <summary>
        /// The Vector that will be augment the boids direction
        /// </summary>
        public Vector2 direction { get; private set; }

        /// <summary>
        /// this constructor insitializes all of the attributes will custom values
        /// </summary>
        /// <param name="directionName"></param>
        /// <param name="direction"></param>
        public Direction(string directionName, Vector2 direction)
        {
            this.directionName = directionName;
            this.direction = direction;
        }

        /// <summary>
        /// returns the name of the direction for list controls e.g. combobox
        /// </summary>
        /// <returns>string DirectionName</returns>
        public override string ToString()
        {
            return directionName;
        }

    }
}
