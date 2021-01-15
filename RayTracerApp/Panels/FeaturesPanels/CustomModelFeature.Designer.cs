
namespace RayTracerApp.Panels.FeaturesPanels
{
    partial class CustomModelFeature
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
            this.label1 = new System.Windows.Forms.Label();
            this.customModelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From file...";
            // 
            // customModelButton
            // 
            this.customModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customModelButton.Location = new System.Drawing.Point(200, 26);
            this.customModelButton.Name = "customModelButton";
            this.customModelButton.Size = new System.Drawing.Size(75, 23);
            this.customModelButton.TabIndex = 1;
            this.customModelButton.Text = "...";
            this.customModelButton.UseVisualStyleBackColor = true;
            this.customModelButton.Click += new System.EventHandler(this.customModelButton_Click);
            // 
            // CustomModelFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customModelButton);
            this.Controls.Add(this.label1);
            this.Name = "CustomModelFeature";
            this.Size = new System.Drawing.Size(300, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button customModelButton;
    }
}
