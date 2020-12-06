
namespace RayTracerApp.Controls
{
    partial class FeaturesPanel
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
            this.sphereFeaturesControl = new RayTracerApp.Controls.Features.SphereFeaturesControl();
            this.cubeFeaturesControl = new RayTracerApp.Controls.Features.CubeFeaturesControl();
            this.SuspendLayout();
            // 
            // sphereFeaturesControl
            // 
            this.sphereFeaturesControl.Location = new System.Drawing.Point(18, 15);
            this.sphereFeaturesControl.Name = "sphereFeaturesControl";
            this.sphereFeaturesControl.Size = new System.Drawing.Size(191, 202);
            this.sphereFeaturesControl.TabIndex = 0;
            this.sphereFeaturesControl.Visible = false;
            // 
            // cubeFeaturesControl
            // 
            this.cubeFeaturesControl.Location = new System.Drawing.Point(3, 15);
            this.cubeFeaturesControl.Name = "cubeFeaturesControl";
            this.cubeFeaturesControl.Size = new System.Drawing.Size(206, 160);
            this.cubeFeaturesControl.TabIndex = 1;
            // 
            // FeaturesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cubeFeaturesControl);
            this.Controls.Add(this.sphereFeaturesControl);
            this.Name = "FeaturesPanel";
            this.Size = new System.Drawing.Size(225, 304);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.NumericUpDown radiusUpDown;
        private Features.SphereFeaturesControl sphereFeaturesControl;
        private Features.CubeFeaturesControl cubeFeaturesControl;
    }
}
