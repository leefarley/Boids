namespace Boids
{
    partial class BoidControls
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.btnStopSimulation = new System.Windows.Forms.Button();
            this.btnSimulateStep = new System.Windows.Forms.Button();
            this.nudFlockCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudFlockSize = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BoidMovementTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudFlockCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlockSize)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRunSimulation.Location = new System.Drawing.Point(31, 5);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(142, 40);
            this.btnRunSimulation.TabIndex = 0;
            this.btnRunSimulation.Text = "Run Simulation";
            this.btnRunSimulation.UseVisualStyleBackColor = true;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // btnStopSimulation
            // 
            this.btnStopSimulation.Enabled = false;
            this.btnStopSimulation.Location = new System.Drawing.Point(31, 6);
            this.btnStopSimulation.Name = "btnStopSimulation";
            this.btnStopSimulation.Size = new System.Drawing.Size(142, 40);
            this.btnStopSimulation.TabIndex = 1;
            this.btnStopSimulation.Text = "Stop Simulation";
            this.btnStopSimulation.UseVisualStyleBackColor = true;
            this.btnStopSimulation.Click += new System.EventHandler(this.btnStopSimulation_Click);
            // 
            // btnSimulateStep
            // 
            this.btnSimulateStep.Location = new System.Drawing.Point(31, 6);
            this.btnSimulateStep.Name = "btnSimulateStep";
            this.btnSimulateStep.Size = new System.Drawing.Size(142, 40);
            this.btnSimulateStep.TabIndex = 2;
            this.btnSimulateStep.Text = "Simulate Step";
            this.btnSimulateStep.UseVisualStyleBackColor = true;
            this.btnSimulateStep.Click += new System.EventHandler(this.btnSimulateStep_Click);
            // 
            // nudFlockCount
            // 
            this.nudFlockCount.Location = new System.Drawing.Point(167, 3);
            this.nudFlockCount.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudFlockCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFlockCount.Name = "nudFlockCount";
            this.nudFlockCount.Size = new System.Drawing.Size(42, 22);
            this.nudFlockCount.TabIndex = 3;
            this.nudFlockCount.Tag = "";
            this.nudFlockCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFlockCount.ValueChanged += new System.EventHandler(this.nudFlockCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Flocks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Boids Per Flock";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nudFlockCount);
            this.panel1.Location = new System.Drawing.Point(3, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 29);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudFlockSize);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 30);
            this.panel2.TabIndex = 9;
            // 
            // nudFlockSize
            // 
            this.nudFlockSize.Location = new System.Drawing.Point(167, 5);
            this.nudFlockSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFlockSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudFlockSize.Name = "nudFlockSize";
            this.nudFlockSize.Size = new System.Drawing.Size(42, 22);
            this.nudFlockSize.TabIndex = 3;
            this.nudFlockSize.Tag = "";
            this.nudFlockSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudFlockSize.ValueChanged += new System.EventHandler(this.nudFlockSize_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(228, 245);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRunSimulation);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 51);
            this.panel3.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSimulateStep);
            this.panel5.Location = new System.Drawing.Point(3, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(220, 51);
            this.panel5.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnStopSimulation);
            this.panel4.Location = new System.Drawing.Point(3, 117);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 51);
            this.panel4.TabIndex = 11;
            // 
            // BoidMovementTimer
            // 
            this.BoidMovementTimer.Interval = 60;
            this.BoidMovementTimer.Tick += new System.EventHandler(this.BoidMovementTimer_Tick);
            // 
            // BoidControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BoidControls";
            this.Size = new System.Drawing.Size(241, 263);
            ((System.ComponentModel.ISupportInitialize)(this.nudFlockCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlockSize)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.Button btnStopSimulation;
        private System.Windows.Forms.Button btnSimulateStep;
        private System.Windows.Forms.NumericUpDown nudFlockCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nudFlockSize;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer BoidMovementTimer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
    }
}
