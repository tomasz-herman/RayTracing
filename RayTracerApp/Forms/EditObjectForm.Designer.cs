
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
            this.featuresPanel = new RayTracerApp.Panels.FeaturesPanel();
            this.positionPanel = new RayTracerApp.Panels.PositionPanel();
            this.materialPanel = new RayTracerApp.Panels.MaterialPanel();
            this.SuspendLayout();
            // 
            // featuresPanel
            // 
            this.featuresPanel.Controller = null;
            this.featuresPanel.Location = new System.Drawing.Point(0, 26);
            this.featuresPanel.Name = "featuresPanel";
            this.featuresPanel.Size = new System.Drawing.Size(484, 594);
            this.featuresPanel.TabIndex = 6;
            // 
            // positionPanel
            // 
            this.positionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionPanel.Controller = null;
            this.positionPanel.Location = new System.Drawing.Point(0, 26);
            this.positionPanel.Name = "positionPanel";
            this.positionPanel.Size = new System.Drawing.Size(484, 594);
            this.positionPanel.TabIndex = 7;
            // 
            // materialPanel
            // 
            this.materialPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialPanel.Controller = null;
            this.materialPanel.Location = new System.Drawing.Point(0, 26);
            this.materialPanel.Name = "materialPanel";
            this.materialPanel.Size = new System.Drawing.Size(484, 594);
            this.materialPanel.TabIndex = 8;
            // 
            // EditObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.materialPanel);
            this.Controls.Add(this.positionPanel);
            this.Controls.Add(this.featuresPanel);
            this.Name = "EditObjectForm";
            this.Text = "Edycja obiektu";
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