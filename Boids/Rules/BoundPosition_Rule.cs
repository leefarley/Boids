using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Boids.Rules
{
    /// <summary>
    /// This Rule is responsible for bounding a boid when he reaches the edge of the screen
    /// </summary>
    class BoundPosition_Rule : Interfaces.BoidRule_Interface
    {
        public int Xmax { get; set; }
        public int Ymax { get; set; }
        int boundMargin;


       public List<Interfaces.Boid_Interface> boidList { get; set; }
       public bool enabled { get; set; }
       public Control controlPanel { get; set; }


        /// <summary>
        /// The constructor is responsible for setting the size of the map and creating the Control to control the rule
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
       public BoundPosition_Rule()
       {
            this.boidList = new List<Interfaces.Boid_Interface>();
            this.enabled = true;
            Xmax = 500;
            Ymax = 500;
            boundMargin = 15;

           //create the contol for this rule
            controlPanel = new Panel
            {
                Width = 220,
                Height = 29
            };

            controlPanel.Controls.Add(new Label { Location = new System.Drawing.Point(3, 5), Text = "Bound Rule" });
            CheckBox cbCentre = new CheckBox { Location = new System.Drawing.Point(124, 3), Checked = true };
            TrackBar tbBoundPos = new TrackBar { Location = new System.Drawing.Point(140, 3), Minimum = 0, Maximum = 30, Value = boundMargin, Width = 87 };
            cbCentre.CheckedChanged += new EventHandler(control_CheckedChanged);
            tbBoundPos.ValueChanged += new EventHandler(control_ValueChanged);
            controlPanel.Controls.Add(tbBoundPos);
            controlPanel.Controls.Add(cbCentre);
            
       }

       /// <summary>
       /// implement rule is responsible for implementing a rule on a single boid
       /// </summary>
       /// <param name="boid">Boid_interface</param>
       /// <returns>Vector2</returns>
        public Vector2 implementRule(Interfaces.Boid_Interface b)
        {
            int vlim = 5;

            Vector2 vector = new Vector2();

            if (b.Position.X < boundMargin)
                vector.X = vlim;
            else if (b.Position.X > (Xmax - boundMargin))
                vector.X = -vlim;

            if (b.Position.Y < boundMargin)
                vector.Y = vlim;
            else if (b.Position.Y > (Ymax - boundMargin))
                vector.Y = -vlim;

            return vector;
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
                boundMargin = Convert.ToInt32(tbValue.Value);
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
