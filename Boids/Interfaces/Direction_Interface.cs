using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boids.Interfaces
{
    interface Direction_Interface
    {
        string directionName { get; }
        Vector2 direction { get; }
    }
}
