
namespace RayTracerApp.Panels.FeaturesPanels
{
    partial class AspectFeature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AspectFeature));
            this.aspectLabel = new System.Windows.Forms.Label();
            this.aspectRatioUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // aspectLabel
            // 
            resources.ApplyResources(this.aspectLabel, "aspectLabel");
            this.aspectLabel.BackColor = System.Drawing.Color.Transparent;
            this.aspectLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.aspectLabel.Name = "aspectLabel";
            // 
            // aspectRatioUpDown
            // 
            resources.ApplyResources(this.aspectRatioUpDown, "aspectRatioUpDown");
            this.aspectRatioUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.aspectRatioUpDown.DecimalPlaces = 2;
            this.aspectRatioUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.aspectRatioUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aspectRatioUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspectRatioUpDown.Name = "aspectRatioUpDown";
            this.aspectRatioUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aspectRatioUpDown.ValueChanged += new System.EventHandler(this.aspectRatioUpDown_ValueChanged);
            // 
            // AspectFeature
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.aspectRatioUpDown);
            this.Controls.Add(this.aspectLabel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "AspectFeature";
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aspectLabel;
        private System.Windows.Forms.NumericUpDown aspectRatioUpDown;
    }
}
