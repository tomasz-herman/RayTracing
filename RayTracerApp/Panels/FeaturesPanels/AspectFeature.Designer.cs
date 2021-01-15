
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
            this.aspectLabel = new System.Windows.Forms.Label();
            this.aspectRatioUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // aspectLabel
            // 
            this.aspectLabel.AutoSize = true;
            this.aspectLabel.Location = new System.Drawing.Point(30, 30);
            this.aspectLabel.Name = "aspectLabel";
            this.aspectLabel.Size = new System.Drawing.Size(46, 15);
            this.aspectLabel.TabIndex = 2;
            this.aspectLabel.Text = "Aspect:";
            // 
            // aspectRatioUpDown
            // 
            this.aspectRatioUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aspectRatioUpDown.DecimalPlaces = 2;
            this.aspectRatioUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aspectRatioUpDown.Location = new System.Drawing.Point(200, 28);
            this.aspectRatioUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspectRatioUpDown.Name = "aspectRatioUpDown";
            this.aspectRatioUpDown.Size = new System.Drawing.Size(75, 23);
            this.aspectRatioUpDown.TabIndex = 3;
            this.aspectRatioUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aspectRatioUpDown.ValueChanged += new System.EventHandler(this.aspectRatioUpDown_ValueChanged);
            // 
            // AspectFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aspectRatioUpDown);
            this.Controls.Add(this.aspectLabel);
            this.Name = "AspectFeature";
            this.Size = new System.Drawing.Size(300, 100);
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aspectLabel;
        private System.Windows.Forms.NumericUpDown aspectRatioUpDown;
    }
}
