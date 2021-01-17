
namespace RayTracerApp.Forms
{
    partial class EditObjectForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditObjectForm));
            this.featuresPanel = new RayTracerApp.Panels.FeaturesPanel();
            this.positionPanel = new RayTracerApp.Panels.PositionPanel();
            this.materialPanel = new RayTracerApp.Panels.MaterialPanel();
            this.SuspendLayout();
            // 
            // middlePreviousButton
            // 
            resources.ApplyResources(this.middlePreviousButton, "middlePreviousButton");
            // 
            // leftCancelButton
            // 
            resources.ApplyResources(this.leftCancelButton, "leftCancelButton");
            // 
            // middleCancelButton
            // 
            resources.ApplyResources(this.middleCancelButton, "middleCancelButton");
            // 
            // rightFinishButton
            // 
            resources.ApplyResources(this.rightFinishButton, "rightFinishButton");
            // 
            // topLabel
            // 
            resources.ApplyResources(this.topLabel, "topLabel");
            // 
            // rightNextButton
            // 
            resources.ApplyResources(this.rightNextButton, "rightNextButton");
            // 
            // featuresPanel
            // 
            this.featuresPanel.Controller = null;
            resources.ApplyResources(this.featuresPanel, "featuresPanel");
            this.featuresPanel.Name = "featuresPanel";
            // 
            // positionPanel
            // 
            resources.ApplyResources(this.positionPanel, "positionPanel");
            this.positionPanel.Controller = null;
            this.positionPanel.Name = "positionPanel";
            // 
            // materialPanel
            // 
            resources.ApplyResources(this.materialPanel, "materialPanel");
            this.materialPanel.Controller = null;
            this.materialPanel.Name = "materialPanel";
            // 
            // EditObjectForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialPanel);
            this.Controls.Add(this.positionPanel);
            this.Controls.Add(this.featuresPanel);
            this.Name = "EditObjectForm";
            this.Controls.SetChildIndex(this.rightNextButton, 0);
            this.Controls.SetChildIndex(this.middlePreviousButton, 0);
            this.Controls.SetChildIndex(this.leftCancelButton, 0);
            this.Controls.SetChildIndex(this.topLabel, 0);
            this.Controls.SetChildIndex(this.rightFinishButton, 0);
            this.Controls.SetChildIndex(this.middleCancelButton, 0);
            this.Controls.SetChildIndex(this.featuresPanel, 0);
            this.Controls.SetChildIndex(this.positionPanel, 0);
            this.Controls.SetChildIndex(this.materialPanel, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.FeaturesPanel featuresPanel;
        private Panels.PositionPanel positionPanel;
        private Panels.MaterialPanel materialPanel;
    }
}