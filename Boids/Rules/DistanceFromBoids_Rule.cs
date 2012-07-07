using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Boids;

namespace Boids.Rules
{
    /// <summary>
    /// This is the second rule of a boid.
    /// responsible for keeping a small distance from other boids.
    /// </summary>
    class DistanceFromBoids_Rule :Interfaces.BoidRule_Interface
    {

        public List<Interfaces.Boid_Interface> boidList { get; set; }
        public bool enabled { get; set; }
        public Control controlPanel { get; set; }
        public int distance;


        /// <summary>
        /// Constructor is responsible for setting up the rules control.
        /// </summary>
        public DistanceFromBoids_Rule()
        {
            this.boidList = new List<Interfaces.Boid_Interface>();
            this.enabled = true;
            distance = 10;

            controlPanel = new Panel
            {
                Width = 220,
                Height = 29
            };

            controlPanel.Controls.Add(new Label { Location = new System.Drawing.Point(3, 5), Text = "Distance Rule" });
            CheckBox cbCentre = new CheckBox { Location = new System.Drawing.Point(124, 3), Checked = true };
            TrackBar tbDistance = new TrackBar { Location = new System.Drawing.Point(140, 3), Minimum = 5, Maximum = 15, Value = distance, Width = 87 };
            cbCentre.CheckedChanged += new EventHandler(control_CheckedChanged);
            tbDistance.ValueChanged += new EventHandler(control_ValueChanged);
            controlPanel.Controls.Add(tbDistance);
            controlPanel.Controls.Add(cbCentre);
        }


        /// <summary>
        /// implement rule is responsible for implementing a rule on a single boid
        /// </summary>
        /// <param name="boid">Boid_interface</param>
        /// <returns>Vector2</returns>
        public Vector2 implementRule(Interfaces.Boid_Interface b)
        {
            Vector2 temp = new Vector2();
            foreach (Interfaces.Boid_Interface boid in boidList)
            {
                if (b != boid)
                {
                    Vector2 tmp = (boid.Position - b.Position);
                    if ((tmp.X < distance) && (tmp.X > -distance))
                    {
                        if ((tmp.Y < distance) && (tmp.Y > -distance))
                        temp = temp - tmp;
                    }
                }
            }
            return temp;
        }

        /// <summary>
        /// responsible for adding the rules control to another control
        /// </summary>
        /// <param name="control">Control</param>
        public void addRuleControl(Control control)
        {

            control.Controls.Add(controlPanel);
        }


        /// <summary>
        /// Event handler for NumericUpDown to change the rule strength
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        private void control_ValueChanged(object sender, System.EventArgs e)
        {
            if (sender is TrackBar)
            {
                TrackBar tbValue = sender as TrackBar;
                distance = Convert.ToInt32(tbValue.Value);
            }
        }


        /// <summary>
        /// checkbox event handler for enable/disableing the rule
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        private void control_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox checkbox = sender as CheckBox;
                if (checkbox.Checked)
                    enabled = true;
                else
                    enabled = false;
            }
        }
    }
}
