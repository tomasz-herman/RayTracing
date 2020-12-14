
namespace RayTracerApp.Forms.Menu
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
            this.featuresPanel = new RayTracerApp.Controls.FeaturesPanel();
            this.positionPanel = new RayTracerApp.Controls.PositionPanel();
            this.materialPanel = new RayTracerApp.Controls.MaterialPanel();
            this.SuspendLayout();
            // 
            // featuresPanel
            // 
            this.featuresPanel.Location = new System.Drawing.Point(0, 28);
            this.featuresPanel.Name = "featuresPanel";
            this.featuresPanel.Size = new System.Drawing.Size(334, 329);
            this.featuresPanel.TabIndex = 11;
            this.materialPanel.Visible = false;
            // 
            // positionPanel
            // 
            this.positionPanel.Location = new System.Drawing.Point(0, 28);
            this.positionPanel.Name = "positionPanel";
            this.positionPanel.Size = new System.Drawing.Size(334, 329);
            this.positionPanel.TabIndex = 12;
            this.materialPanel.Visible = false;
            // 
            // materialPanel
            // 
            this.materialPanel.Location = new System.Drawing.Point(0, 28);
            this.materialPanel.Name = "materialPanel";
            this.materialPanel.Size = new System.Drawing.Size(334, 329);
            this.materialPanel.TabIndex = 13;
            this.materialPanel.Visible = false;
            // 
            // EditObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.materialPanel);
            this.Controls.Add(this.positionPanel);
            this.Controls.Add(this.featuresPanel);
            this.Name = "EditObjectForm";
            this.Text = "EditObjectForm";
            this.Controls.SetChildIndex(this.featuresPanel, 0);
            this.Controls.SetChildIndex(this.positionPanel, 0);
            this.Controls.SetChildIndex(this.materialPanel, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FeaturesPanel featuresPanel;
        private Controls.PositionPanel positionPanel;
        private Controls.MaterialPanel materialPanel;
    }
}