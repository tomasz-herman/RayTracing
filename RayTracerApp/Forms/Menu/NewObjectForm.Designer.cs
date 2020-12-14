using System.ComponentModel;
using RayTracerApp.Controls;

namespace RayTracerApp.Forms
{
    partial class NewObjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.newModelPanel = new RayTracerApp.Controls.NewModelPanel();
            this.positionPanel = new RayTracerApp.Controls.PositionPanel();
            this.materialPanel = new RayTracerApp.Controls.MaterialPanel();
            this.SuspendLayout();
            // 
            // featuresPanel
            // 
            this.featuresPanel.Location = new System.Drawing.Point(0, 26);
            this.featuresPanel.Name = "featuresPanel";
            this.featuresPanel.Size = new System.Drawing.Size(334, 331);
            this.featuresPanel.TabIndex = 11;
            this.featuresPanel.Visible = false;
            // 
            // newModelPanel
            // 
            this.newModelPanel.Location = new System.Drawing.Point(0, 26);
            this.newModelPanel.Name = "newModelPanel";
            this.newModelPanel.Size = new System.Drawing.Size(334, 331);
            this.newModelPanel.TabIndex = 12;
            // 
            // positionPanel
            // 
            this.positionPanel.Location = new System.Drawing.Point(0, 26);
            this.positionPanel.Name = "positionPanel";
            this.positionPanel.Size = new System.Drawing.Size(334, 331);
            this.positionPanel.TabIndex = 13;
            this.positionPanel.Visible = false;
            // 
            // materialPanel
            // 
            this.materialPanel.Location = new System.Drawing.Point(0, 28);
            this.materialPanel.Name = "materialPanel";
            this.materialPanel.Size = new System.Drawing.Size(334, 329);
            this.materialPanel.TabIndex = 14;
            this.materialPanel.Visible = false;
            // 
            // NewObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.materialPanel);
            this.Controls.Add(this.positionPanel);
            this.Controls.Add(this.newModelPanel);
            this.Controls.Add(this.featuresPanel);
            this.MaximumSize = new System.Drawing.Size(350, 450);
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "NewObjectForm";
            this.Text = "NewObjectForm";
            this.Controls.SetChildIndex(this.featuresPanel, 0);
            this.Controls.SetChildIndex(this.newModelPanel, 0);
            this.Controls.SetChildIndex(this.positionPanel, 0);
            this.Controls.SetChildIndex(this.materialPanel, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private FeaturesPanel featuresPanel;
        private NewModelPanel newModelPanel;
        private PositionPanel positionPanel;
        private MaterialPanel materialPanel;
    }
}