using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Boids;

namespace Boids.Rules
{
    /// <summary>
    /// This is the Third Boid Rule. 
    /// this is responsible for a boid to try to match velocity with near boids
    /// </summary>
    class MatchVelocity_Rule : Interfaces.BoidRule_Interface
    {
        public List<Interfaces.Boid_Interface> boidList { get; set;}
        public bool enabled { get; set; }
        public Control controlPanel { get; set; }
        public int matchSpeed;


        /// <summary>
        /// Thsi constructor is responsible for creating the Control for the rule.
        /// </summary>
        public MatchVelocity_Rule()
        {
            this.boidList = new List<Interfaces.Boid_Interface>();
            this.enabled = true;
            matchSpeed = 20;

            controlPanel = new Panel
            {
                Width = 220,
                Height = 29
            };

            controlPanel.Controls.Add(new Label { Location = new System.Drawing.Point(3, 5), Text = "Velocity Rule" });
            CheckBox cbCentre = new CheckBox { Location = new System.Drawing.Point(124, 3), Checked = true };
            TrackBar tbVelocity = new TrackBar { Location = new System.Drawing.Point(140, 3), Minimum = 5, Maximum = 35, Value = matchSpeed, Width = 87 };
            tbVelocity.ValueChanged += new EventHandler(control_ValueChanged);
            cbCentre.CheckedChanged += new EventHandler(control_CheckedChanged);
            controlPanel.Controls.Add(tbVelocity);
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
                    temp += boid.Velocity;
            }
            temp = temp / (boidList.Count - 1);
            return (temp - b.Velocity) / matchSpeed;
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
                matchSpeed = Convert.ToInt32(tbValue.Value);
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
