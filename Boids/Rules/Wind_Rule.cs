
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Boids.Rules
{
    /// <summary>
    /// This Class is responsible for simulating wind on a boid
    /// </summary>
    class Wind_Rule : Interfaces.BoidRule_Interface
    {
        public List<Interfaces.Boid_Interface> boidList { get; set; }
        public bool enabled { get; set; }
        public Control controlPanel { get;  set; }
        List<Direction> directions;
        Direction windDirection;
        
        /// <summary>
        /// The Control and directions are created to modify this rule.
        /// </summary>
        public Wind_Rule()
        {
            directions = new List<Direction>();
            directions.Add(new Direction("None", new Vector2(0, 0)));
            directions.Add(new Direction("North",new Vector2(0,-1)));
            directions.Add(new Direction("East",new Vector2(1,0)));
            directions.Add(new Direction("South",new Vector2(0,1)));
            directions.Add(new Direction("West", new Vector2(-1,0)));
            enabled = true;
            windDirection = directions.First();
        }

        /// <summary>
        /// implement rule is responsible for implementing a rule on a single boid
        /// </summary>
        /// <param name="boid">Boid_interface</param>
        /// <returns>Vector2</returns>
        public Vector2 implementRule(Interfaces.Boid_Interface b)
        {
            return windDirection.direction;
        }

        /// <summary>
        /// responsible for adding the rules control to another control
        /// </summary>
        /// <param name="control">Control</param>
        public void addRuleControl(System.Windows.Forms.Control control)
        {
            Panel rulePanel = new Panel
            {
                Width = 220,
                Height = 29
            };

            rulePanel.Controls.Add(new Label { Location = new System.Drawing.Point(3, 5), Text = "Wind Rule" });
            ComboBox cbWind = new ComboBox { Location = new System.Drawing.Point(110, 3), Width = 100 };
            cbWind.Items.AddRange(directions.ToArray());
            cbWind.SelectedIndex = 0;
            cbWind.SelectedValueChanged += new EventHandler(control_CheckedChanged);
            rulePanel.Controls.Add(cbWind);
            control.Controls.Add(rulePanel);
        }

        /// <summary>
        /// comboBox event handler for changeingthe direction the boids are pushed toward 
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">EventArgs</param>
        private void control_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox comboBox = sender as ComboBox;
                windDirection = (Direction)comboBox.SelectedItem;
            }
        }
    }
}
