using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Boids.Rules
{
    /// <summary>
    /// This class is responsible for limiting the speed of a boid.
    /// </summary>
    class LimitSpeed_Rule :Interfaces.BoidRule_Interface
    {
        int vlim;
        public List<Interfaces.Boid_Interface> boidList { get; set; }
        public bool enabled { get; set; }
        public Control controlPanel { get; set; }

        /// <summary>
        /// This constructor is responsible for creating the controls to be displayed.
        /// </summary>
        public LimitSpeed_Rule()
        {
            vlim = 12;
            enabled = true;
            // create the rules controls
            controlPanel = new Panel
            {
                Width = 220,
                Height = 29
            };
            controlPanel.Controls.Add(new Label { Location = new System.Drawing.Point(3, 5), Text = "Limit Speed" });
            TrackBar tbSpeed = new TrackBar { Location = new System.Drawing.Point(140, 3), Minimum = 5, Maximum = 20, Value = vlim, Width = 87 };
            CheckBox cbEnable = new CheckBox { Location = new System.Drawing.Point(124, 3), Checked = true };
            tbSpeed.ValueChanged += new EventHandler(control_ValueChanged);
            cbEnable.CheckedChanged += new EventHandler(control_CheckedChanged);
            controlPanel.Controls.Add(tbSpeed);
            controlPanel.Controls.Add(cbEnable);
        }

        /// <summary>
        /// implement rule is responsible for implementing a rule on a single boid
        /// </summary>
        /// <param name="boid">Boid_interface</param>
        /// <returns>Vector2</returns>
        public Vector2 implementRule(Interfaces.Boid_Interface b)
        {
            
            Vector2 v = b.Velocity;

            if (b.Velocity.X > vlim)
                b.Velocity.X = vlim;
            if (b.Velocity.X < -vlim)
                b.Velocity.X = -vlim;
            if (b.Velocity.Y > vlim)
                b.Velocity.Y = vlim;
            if (b.Velocity.Y < -vlim)
                b.Velocity.Y = -vlim;

            return v;
        }

        /// <summary>
        /// responsible for adding the rules control to another control
        /// </summary>
        /// <param name="control">Control</param>
        public void addRuleControl(System.Windows.Forms.Control control)
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
                vlim = Convert.ToInt32(tbValue.Value);
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
