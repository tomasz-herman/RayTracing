
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
            this.customModelFeatureControl = new RayTracerApp.Controls.Features.CustomModelFeatureControl();
            this.SuspendLayout();
            // 
            // customModelFeatureControl
            // 
            this.customModelFeatureControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customModelFeatureControl.Location = new System.Drawing.Point(0, 0);
            this.customModelFeatureControl.Name = "customModelFeatureControl";
            this.customModelFeatureControl.Size = new System.Drawing.Size(212, 266);
            this.customModelFeatureControl.TabIndex = 0;
            // 
            // FeaturesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customModelFeatureControl);
            this.Name = "FeaturesPanel";
            this.Size = new System.Drawing.Size(215, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.NumericUpDown radiusUpDown;
        private Features.CustomModelFeatureControl customModelFeatureControl;
    }
}
