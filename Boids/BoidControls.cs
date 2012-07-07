using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Boids
{
    /// <summary>
    /// This class is responsible for displaying controls to alter the simulation
    /// </summary>
    public partial class BoidControls : UserControl
    {
        Boids_Factory boids;

        /// <summary>
        /// sets up the control. adding all rule controls to the datagridview 
        /// and changeing the size to accomodate the extra components
        /// </summary>
        /// <param name="boids"></param>
        public BoidControls(Boids_Factory boids)
        {
            InitializeComponent();
            this.boids = boids;
            nudFlockCount.Value = 1;
            int tmp = boids.getControls(flowLayoutPanel1);
            this.Height += 36 * tmp;
            flowLayoutPanel1.Height += 36 * tmp;
        }

        /// <summary>
        /// This method is responsible for adding or removing flocks depending 
        /// on the value of the numericUpDown for flock size
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        private void nudFlockCount_ValueChanged(object sender, EventArgs e)
        {
            while (boids.flockCount != nudFlockCount.Value)
            {
                if (boids.flockCount < nudFlockCount.Value)
                {
                    boids.newFlock();
                }
                else
                {
                    boids.removeFlock();
                }
            }
        }

        /// <summary>
        /// This method is responsible for altering the amount of boids in a flock
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void nudFlockSize_ValueChanged(object sender, EventArgs e)
        {
            int flocksize = (int)nudFlockSize.Value;
            boids.flockSizeChange(flocksize);
        }

        /// <summary>
        /// This actionhandler is responsible for setting the simulation to constantly run.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            BoidMovementTimer.Enabled = true;
            btnRunSimulation.Enabled = false;
            btnStopSimulation.Enabled = true;
            btnSimulateStep.Enabled = false;
        }

        /// <summary>
        /// This actionhandler is responsible for stopping the simulation from constantly running.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnStopSimulation_Click(object sender, EventArgs e)
        {
            BoidMovementTimer.Enabled = false;
            btnRunSimulation.Enabled = true;
            btnStopSimulation.Enabled = false;
            btnSimulateStep.Enabled = true;
        }

        /// <summary>
        /// This action handler is responsible for running a step of the 
        /// simulation on the tick of a timer
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void BoidMovementTimer_Tick(object sender, EventArgs e)
        {
            boids.step();
        }

        /// <summary>
        /// This action handler is responsible for running a step of 
        /// the simulation on a user click of btnSimulateStep
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnSimulateStep_Click(object sender, EventArgs e)
        {
            boids.step();
        }




    }
}
