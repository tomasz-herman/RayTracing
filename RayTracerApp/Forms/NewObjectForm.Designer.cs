
namespace RayTracerApp.Forms
{
    partial class NewObjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewObjectForm));
            this.objectSelectionPanel = new RayTracerApp.Panels.ObjectSelectionPanel();
            this.featuresPanel = new RayTracerApp.Panels.FeaturesPanel();
            this.positionPanel = new RayTracerApp.Panels.PositionPanel();
            this.materialPanel = new RayTracerApp.Panels.MaterialPanel();
            this.SuspendLayout();
            // 
            // middlePreviousButton
            // 
            this.middlePreviousButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.middlePreviousButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.middlePreviousButton.UseVisualStyleBackColor = false;
            // 
            // leftCancelButton
            // 
            this.leftCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.leftCancelButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.leftCancelButton.UseVisualStyleBackColor = false;
            // 
            // middleCancelButton
            // 
            this.middleCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.middleCancelButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.middleCancelButton.UseVisualStyleBackColor = false;
            // 
            // rightFinishButton
            // 
            this.rightFinishButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.rightFinishButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.rightFinishButton.UseVisualStyleBackColor = false;
            // 
            // topLabel
            // 
            this.topLabel.ForeColor = System.Drawing.Color.Gainsboro;
            // 
            // rightNextButton
            // 
            this.rightNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.rightNextButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.rightNextButton.UseVisualStyleBackColor = false;
            // 
            // objectSelectionPanel
            // 
            resources.ApplyResources(this.objectSelectionPanel, "objectSelectionPanel");
            this.objectSelectionPanel.BackColor = System.Drawing.Color.Transparent;
            this.objectSelectionPanel.Controller = null;
            this.objectSelectionPanel.Name = "objectSelectionPanel";
            // 
            // featuresPanel
            // 
            resources.ApplyResources(this.featuresPanel, "featuresPanel");
            this.featuresPanel.BackColor = System.Drawing.Color.Transparent;
            this.featuresPanel.Controller = null;
            this.featuresPanel.Name = "featuresPanel";
            // 
            // positionPanel
            // 
            resources.ApplyResources(this.positionPanel, "positionPanel");
            this.positionPanel.BackColor = System.Drawing.Color.Transparent;
            this.positionPanel.Controller = null;
            this.positionPanel.Name = "positionPanel";
            // 
            // materialPanel
            // 
            resources.ApplyResources(this.materialPanel, "materialPanel");
            this.materialPanel.BackColor = System.Drawing.Color.Transparent;
            this.materialPanel.Controller = null;
            this.materialPanel.Name = "materialPanel";
            // 
            // NewObjectForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.materialPanel);
            this.Controls.Add(this.positionPanel);
            this.Controls.Add(this.featuresPanel);
            this.Controls.Add(this.objectSelectionPanel);
            this.Name = "NewObjectForm";
            this.Controls.SetChildIndex(this.rightNextButton, 0);
            this.Controls.SetChildIndex(this.middlePreviousButton, 0);
            this.Controls.SetChildIndex(this.leftCancelButton, 0);
            this.Controls.SetChildIndex(this.topLabel, 0);
            this.Controls.SetChildIndex(this.rightFinishButton, 0);
            this.Controls.SetChildIndex(this.middleCancelButton, 0);
            this.Controls.SetChildIndex(this.objectSelectionPanel, 0);
            this.Controls.SetChildIndex(this.featuresPanel, 0);
            this.Controls.SetChildIndex(this.positionPanel, 0);
            this.Controls.SetChildIndex(this.materialPanel, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.ObjectSelectionPanel objectSelectionPanel;
        private Panels.FeaturesPanel featuresPanel;
        private Panels.PositionPanel positionPanel;
        private Panels.MaterialPanel materialPanel;
    }
}