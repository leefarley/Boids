using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Boids
{
    /// <summary>
    /// A simple 2D vector class that defines some simple operations. Uses
    /// an integer as the underlying data store.
    /// </summary>
    public class Vector2
    {
        private int x;
        /// <summary>
        /// X component of vector.
        /// </summary>
        public int X 
        {
            get { return x; }
            set { x = value; }
        }

        private int y;
        /// <summary>
        /// Y component of vector
        /// </summary>
        public int Y 
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Create a new vector with x,y set to 0.
        /// </summary>
        public Vector2()
        {
            x = y = 0;
        }

        /// <summary>
        /// Create a new vector with x,y specified.
        /// </summary>
        /// <param name="x">X component</param>
        /// <param name="y">Y component</param>
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Overload equality operator.
        /// </summary>
        public static Boolean operator ==(Vector2 a, Vector2 b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }

        /// <summary>
        /// Overload inequality operator
        /// </summary>
        public static Boolean operator !=(Vector2 a, Vector2 b)
        {
            return (a.X != b.X) || (a.Y != b.Y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator +(Vector2 a, Point b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Point b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2 operator *(Vector2 a, int b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }

        public static Vector2 operator /(Vector2 a, int b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X / b.X, a.Y / b.Y);
        }

        public override string ToString()
        {
            return String.Format("Vector2: ({0}, {1})", x, y);
        }

        /// <summary>
        /// Convert the vector to a point, which can be used in .NET libraries.
        /// </summary>
        /// <returns>a new System.Drawing.Point object.</returns>
        public Point ToPoint()
        {
            return new Point(x, y);
        }

        /// <summary>
        /// Get vector length.
        /// </summary>
        /// <returns></returns>
        public double length()
        {
            return Math.Sqrt((x * x) + (y * y));
        }

        /// <summary>
        /// Normalise the vector to a new length. Preserved the vector direction but
        /// changes the length or magnitude.
        /// Note: This function will do nothing if the vectors current length is 0.
        /// </summary>
        /// <param name="newLength">The new length you want.</param>
        public void normalizeToLength(Double newLength)
        {
            Double length = this.length();
            if (length != 0.0)
            {
                Double mx = (((Double)x) / (length)) * newLength;
                Double my = (((Double)y) / (length)) * newLength;

                x = (int)mx;
                y = (int)my;
            }
        }
    }
}
