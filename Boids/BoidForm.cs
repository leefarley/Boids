using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Boids
{
    /// <summary>
    /// The form is responsible for displaying all of the control components
    /// </summary>
    public partial class BoidForm : Form
    {
        Boids_Factory boids;
        BasicMapView map;
        Graphics g;
        Random rand;
        BoidControls controls;

        /// <summary>
        /// create and add all the controls to the form.
        /// </summary>
        public BoidForm()
        {
            InitializeComponent();
            
            rand = new Random();
            g = CreateGraphics();
            map = new BasicMapView(panel1);

            boids = new Boids_Factory(rand,map,panel1.Width, panel1.Height);
            controls = new BoidControls(boids);
            this.Controls.Add(controls);
        }
    }
}
