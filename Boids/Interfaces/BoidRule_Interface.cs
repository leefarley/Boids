﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Boids.Interfaces
{
    interface BoidRule_Interface
    {
        /// <summary>
        /// Stores a list of the other boids in the flock
        /// </summary>
        List<Interfaces.Boid_Interface> boidList { get; set; }

        /// <summary>
        /// specifies if the rule is to be implemented by a boid or not.
        /// </summary>
        bool enabled { get; set; }

        /// <summary>
        /// Stroes the control generated by the rule class so it can be passed to a form at a later time
        /// </summary>
        Control controlPanel { get; set; }

        /// <summary>
        /// preforms a calculation on the boids position and returns a vector to augment its velocity/position
        /// </summary>
        /// <param name="b">Boit_Interface the boid to calculate a vecotor for</param>
        /// <returns>Vector2</returns>
        Vector2 implementRule(Boid_Interface b);
        void addRuleControl(Control control);
    }
}