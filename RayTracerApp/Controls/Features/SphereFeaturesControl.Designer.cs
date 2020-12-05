
namespace RayTracerApp.Controls.Features
{
    partial class SphereFeaturesControl
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
            this.radiusUpDown = new System.Windows.Forms.NumericUpDown();
            this.radiusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radiusUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // radiusUpDown
            // 
            this.radiusUpDown.DecimalPlaces = 2;
            this.radiusUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.radiusUpDown.Location = new System.Drawing.Point(119, 29);
            this.radiusUpDown.Name = "radiusUpDown";
            this.radiusUpDown.Size = new System.Drawing.Size(63, 23);
            this.radiusUpDown.TabIndex = 0;
            this.radiusUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radiusUpDown.ValueChanged += new System.EventHandler(this.radiusUpDown_ValueChanged);
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(71, 31);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(45, 15);
            this.radiusLabel.TabIndex = 1;
            this.radiusLabel.Text = "Radius:";
            // 
            // SphereFeaturesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.radiusUpDown);
            this.Name = "SphereFeaturesControl";
            this.Size = new System.Drawing.Size(191, 202);
            ((System.ComponentModel.ISupportInitialize)(this.radiusUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown radiusUpDown;
        private System.Windows.Forms.Label radiusLabel;
    }
}
