using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;

namespace Boids.Tests
{
    class BoidControls_Test
    {
        Panel panel;
        BoidControls control;
        Boids_Factory factory;

        [SetUp]
        public void SetUp()
        {
            panel = new Panel();
            Random rand = new Random();
            BasicMapView map = new BasicMapView(panel);
            factory = new Boids_Factory(rand,map,500,500);
            control = new BoidControls(factory);
        }

        [Test]
        public void ControlIsNotNull_Test()
        {
            Assert.IsNotNull(control);
        }

    }
}
