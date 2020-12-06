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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.newModelPanel = new RayTracerApp.Controls.NewModelPanel();
            this.positionPanel = new RayTracerApp.Controls.PositionPanel();
            this.featuresPanel = new RayTracerApp.Controls.FeaturesPanel();
            this.materialPanel = new RayTracerApp.Controls.MaterialPanel();
            this.topLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(247, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Next";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // newModelPanel
            // 
            this.newModelPanel.Location = new System.Drawing.Point(12, 26);
            this.newModelPanel.Name = "newModelPanel";
            this.newModelPanel.Size = new System.Drawing.Size(242, 152);
            this.newModelPanel.TabIndex = 3;
            // 
            // positionPanel
            // 
            this.positionPanel.Location = new System.Drawing.Point(12, 21);
            this.positionPanel.Name = "positionPanel";
            this.positionPanel.Size = new System.Drawing.Size(258, 301);
            this.positionPanel.TabIndex = 4;
            this.positionPanel.Visible = false;
            // 
            // featuresPanel
            // 
            this.featuresPanel.Location = new System.Drawing.Point(12, 26);
            this.featuresPanel.Name = "featuresPanel";
            this.featuresPanel.Size = new System.Drawing.Size(238, 296);
            this.featuresPanel.TabIndex = 5;
            this.featuresPanel.Visible = false;
            // 
            // materialPanel
            // 
            this.materialPanel.Location = new System.Drawing.Point(12, 21);
            this.materialPanel.Name = "materialPanel";
            this.materialPanel.Size = new System.Drawing.Size(294, 339);
            this.materialPanel.TabIndex = 6;
            this.materialPanel.Visible = false;
            // 
            // topLabel
            // 
            this.topLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLabel.Location = new System.Drawing.Point(0, 0);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(334, 23);
            this.topLabel.TabIndex = 7;
            this.topLabel.Text = "Add new object...";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 411);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.materialPanel);
            this.Controls.Add(this.featuresPanel);
            this.Controls.Add(this.positionPanel);
            this.Controls.Add(this.newModelPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(350, 450);
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "NewObjectForm";
            this.Text = "NewObjectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private NewModelPanel newModelPanel;
        private PositionPanel positionPanel;
        private FeaturesPanel featuresPanel;
        private MaterialPanel materialPanel;
        private System.Windows.Forms.Label topLabel;
    }
}