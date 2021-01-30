
namespace RayTracerApp.Panels.FeaturesPanels
{
    partial class DoubleAspectFeature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoubleAspectFeature));
            this.aspect2UpDown = new System.Windows.Forms.NumericUpDown();
            this.aspect1UpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aspect2UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspect1UpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // aspect2UpDown
            // 
            resources.ApplyResources(this.aspect2UpDown, "aspect2UpDown");
            this.aspect2UpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.aspect2UpDown.DecimalPlaces = 2;
            this.aspect2UpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.aspect2UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aspect2UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspect2UpDown.Name = "aspect2UpDown";
            this.aspect2UpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aspect2UpDown.ValueChanged += new System.EventHandler(this.aspect2UpDown_ValueChanged);
            // 
            // aspect1UpDown
            // 
            resources.ApplyResources(this.aspect1UpDown, "aspect1UpDown");
            this.aspect1UpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.aspect1UpDown.DecimalPlaces = 2;
            this.aspect1UpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.aspect1UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aspect1UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspect1UpDown.Name = "aspect1UpDown";
            this.aspect1UpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aspect1UpDown.ValueChanged += new System.EventHandler(this.aspect1UpDown_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Name = "label1";
            // 
            // DoubleAspectFeature
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.aspect2UpDown);
            this.Controls.Add(this.aspect1UpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DoubleAspectFeature";
            ((System.ComponentModel.ISupportInitialize)(this.aspect2UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspect1UpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown aspect2UpDown;
        private System.Windows.Forms.NumericUpDown aspect1UpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
