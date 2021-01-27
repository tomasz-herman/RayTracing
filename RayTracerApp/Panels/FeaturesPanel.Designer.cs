
namespace RayTracerApp.Panels
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
            this.customModelFeature = new RayTracerApp.Panels.FeaturesPanels.CustomModelFeature();
            this.doubleAspectFeature = new RayTracerApp.Panels.FeaturesPanels.DoubleAspectFeature();
            this.aspectFeature = new RayTracerApp.Panels.FeaturesPanels.AspectFeature();
            this.SuspendLayout();
            // 
            // customModelFeature
            // 
            this.customModelFeature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customModelFeature.Controller = null;
            this.customModelFeature.Location = new System.Drawing.Point(0, 0);
            this.customModelFeature.Name = "customModelFeature";
            this.customModelFeature.Size = new System.Drawing.Size(381, 108);
            this.customModelFeature.TabIndex = 0;
            // 
            // doubleAspectFeature
            // 
            this.doubleAspectFeature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleAspectFeature.Controller = null;
            this.doubleAspectFeature.Location = new System.Drawing.Point(0, 0);
            this.doubleAspectFeature.Name = "doubleAspectFeature";
            this.doubleAspectFeature.Size = new System.Drawing.Size(381, 85);
            this.doubleAspectFeature.TabIndex = 1;
            // 
            // aspectFeature
            // 
            this.aspectFeature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aspectFeature.Controller = null;
            this.aspectFeature.Location = new System.Drawing.Point(0, 0);
            this.aspectFeature.Name = "aspectFeature";
            this.aspectFeature.Size = new System.Drawing.Size(381, 85);
            this.aspectFeature.TabIndex = 2;
            // 
            // FeaturesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.aspectFeature);
            this.Controls.Add(this.doubleAspectFeature);
            this.Controls.Add(this.customModelFeature);
            this.Name = "FeaturesPanel";
            this.Size = new System.Drawing.Size(381, 427);
            this.VisibleChanged += new System.EventHandler(this.FeaturesPanel_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private FeaturesPanels.CustomModelFeature customModelFeature;
        private FeaturesPanels.DoubleAspectFeature doubleAspectFeature;
        private FeaturesPanels.AspectFeature aspectFeature;
    }
}
