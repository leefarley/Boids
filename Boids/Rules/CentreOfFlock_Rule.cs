using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boids;
using System.Windows.Forms;

namespace Boids.Rules
{
    /// <summary>
    /// this is the first rule of a boid
    /// responsible for directing a boid to fly towards the centre of mass of naighbouring boids
    /// </summary>
    class CentreOfFlock_Rule : Interfaces.BoidRule_Interface
    {

        public List<Interfaces.Boid_Interface> boidList { get;  set; }
        public bool enabled { get; set; }
        public Control controlPanel { get; set; }
        public int centerStrength { get; set; }


        /// <summary>
        /// Constructor is responsible for setting up the rules control.
        /// </summary>
        public CentreOfFlock_Rule()
        {
            this.boidList = new List<Interfaces.Boid_Interface>();
            this.enabled = true;
            centerStrength = 100;


            controlPanel = new Panel
            {
                Width = 220,
                Height = 29
            };

            controlPanel.Controls.Add(new Label { Location = new System.Drawing.Point(3, 5), Text = "Centre Rule" });
            CheckBox cbCentre = new CheckBox { Location = new System.Drawing.Point(124, 3), Checked = true };
            TrackBar tbCenter = new TrackBar { Location = new System.Drawing.Point(140, 3), Minimum = 50, Maximum = 150, Value = centerStrength, Width = 87 };
            cbCentre.CheckedChanged += new EventHandler(control_CheckedChanged);
            tbCenter.ValueChanged += new EventHandler(control_ValueChanged);
            controlPanel.Controls.Add(tbCenter);
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
            //find the center of the rest of the flock
            foreach (Interfaces.Boid_Interface boid in boidList)
            {
                if (b != boid)
                    temp += boid.Position;
            }
            temp = temp / (boidList.Count - 1);
            //return a vector that is moving toward the centre of the flock
            return (temp - b.Position) / centerStrength;
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
                centerStrength = Convert.ToInt32(tbValue.Value);
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
                {
                    enabled = true;
                }
                else
                {
                    enabled = false;
                }
            }
        }

    }
}
