
namespace RayTracerApp.Controls.Features
{
    partial class CustomModelFeatureControl
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
            this.loadFromFileButton = new System.Windows.Forms.Button();
            this.loadFromFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadFromFileButton.Location = new System.Drawing.Point(171, 28);
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(44, 23);
            this.loadFromFileButton.TabIndex = 0;
            this.loadFromFileButton.Text = "...";
            this.loadFromFileButton.UseVisualStyleBackColor = true;
            this.loadFromFileButton.Click += new System.EventHandler(this.loadFromFileButton_Click);
            // 
            // loadFromFileLabel
            // 
            this.loadFromFileLabel.AutoSize = true;
            this.loadFromFileLabel.Location = new System.Drawing.Point(17, 32);
            this.loadFromFileLabel.Name = "loadFromFileLabel";
            this.loadFromFileLabel.Size = new System.Drawing.Size(63, 15);
            this.loadFromFileLabel.TabIndex = 1;
            this.loadFromFileLabel.Text = "From file...";
            // 
            // CustomModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadFromFileLabel);
            this.Controls.Add(this.loadFromFileButton);
            this.Name = "CustomModelControl";
            this.Size = new System.Drawing.Size(230, 268);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadFromFileButton;
        private System.Windows.Forms.Label loadFromFileLabel;
    }
}
