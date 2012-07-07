using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace Boids
{
    /// <summary>
    /// The Boids_Factory is responsible for removing and encapsulating logic from the Boid_Controls
    /// </summary>
    public class Boids_Factory
    {
        const int flockMax = 15;
        const int flockMin = 1;

        Random rand;
        Interfaces.MapView map;
        List<Flock> boidFlocks;
        List<Interfaces.BoidRule_Interface> boidRules;
        int mapWidth;
        int mapHeight;
        public int flockSize { get; private set; }
        public int flockCount{ get{return boidFlocks.Count;} }

        /// <summary>
        /// This is the only constructor for the Boids_Factory which is responsible for initalizing all varibles
        /// </summary>
        /// <param name="newRand">A Random number generator</param>
        /// <param name="newMap">a class that has derived from the MapView Interface</param>
        /// <param name="width">The width of the boids area</param>
        /// <param name="height">The height of the boids area</param>
        public Boids_Factory(Random newRand, Interfaces.MapView newMap, int width, int height)
        {
            rand = newRand;
            map = newMap;
            mapWidth = width;
            mapHeight = height;
            flockSize = 3;
            boidFlocks = new List<Flock>();
            boidRules = new List<Interfaces.BoidRule_Interface>();

            IEnumerable<Type> types = GetAllTypesDerivedFrom(typeof(Interfaces.BoidRule_Interface));

            foreach (Type type in types)
            {
                boidRules.Add(
                    (Interfaces.BoidRule_Interface)Activator.CreateInstance(type)
                 );
            }

            newFlock();
        }

        /// <summary>
        /// responsible for moving all boids to the next location on the form
        /// </summary>
        public void step()
        {
            foreach (Flock flock in boidFlocks)
            {
                flock.SimulateFlock();
            }
            map.drawBoids(boidFlocks);
        }

        


        /// <summary>
        /// is responsible for initalizing an new flock
        /// </summary>
        public void newFlock()
        {
            if (flockCount < flockMax)
            boidFlocks.Add(new Flock(flockSize, rand, boidRules, mapWidth, mapHeight));
        }

        /// <summary>
        /// is responsible for removing the last flock from the flock list
        /// </summary>
        public void removeFlock()
        {
            if (flockCount > flockMin)
                boidFlocks.RemoveAt(boidFlocks.Count -1);
        }


        /// <summary>
        /// responsible for adding a new boid to all the flocks.
        /// </summary>
        private void addBoid()
        {
            foreach (Flock flock in boidFlocks)
            {
                flock.addBoid();
            }

        }

        /// <summary>
        /// responsible for removing a boid from every flock
        /// </summary>
        private void removeBoid()
        {
            foreach (Flock flock in boidFlocks)
            {
                flock.removeBoid();
            }

        }

        /// <summary>
        /// is responsible for ensuring the correct amount of boids in the flock
        /// </summary>
        /// <param name="newFlockSize">int - how many individual boids are in the flock</param>
        public void flockSizeChange(int newFlockSize)
        {
            while (flockSize != newFlockSize)
            {
                if (flockSize < newFlockSize)
                {
                    addBoid();
                    flockSize++;
                }
                else
                {
                    removeBoid();
                    flockSize--;
                }
            }
        }

        /// <summary>
        /// is responsible for adding all the rule controls to a control that is passed in
        /// </summary>
        /// <param name="boidControl">Control - a container to hold all rule controls</param>
        /// <returns>int - how many rule were added to the control</returns>
        public int getControls(Control boidControl)
        {
            foreach (var rule in boidRules)
            {
                rule.addRuleControl(boidControl);
                if (rule is Rules.BoundPosition_Rule)
                {
                     Rules.BoundPosition_Rule myRule = (Rules.BoundPosition_Rule)rule;
                     myRule.Xmax = mapWidth;
                     myRule.Ymax = mapHeight;
                }
            }
            return boidRules.Count;
        }

        /// <summary>
        /// is responsible for getting all of the types that derive from a interface or parent class
        /// </summary>
        /// <param name="type">Type - a class/interface type. user typeof() method to find type</param>
        /// <returns>IEnumerable<Type> all the types that derive from the passed in type</returns>
        public IEnumerable<Type> GetAllTypesDerivedFrom(Type type)
        {
            var types = Assembly.GetAssembly(type).GetTypes();
            return types.Where(type.IsAssignableFrom).Where(curType => curType != type);
        }

    }
}
