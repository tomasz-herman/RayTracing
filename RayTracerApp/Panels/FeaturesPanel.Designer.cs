
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
            this.filePanel = new System.Windows.Forms.Panel();
            this.fromFileLabel = new System.Windows.Forms.Label();
            this.customModelButton = new System.Windows.Forms.Button();
            this.aspectPanel = new System.Windows.Forms.Panel();
            this.aspectLabel = new System.Windows.Forms.Label();
            this.aspectRatioUpDown = new System.Windows.Forms.NumericUpDown();
            this.filePanel.SuspendLayout();
            this.aspectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // filePanel
            // 
            this.filePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePanel.Controls.Add(this.aspectPanel);
            this.filePanel.Controls.Add(this.fromFileLabel);
            this.filePanel.Controls.Add(this.customModelButton);
            this.filePanel.Location = new System.Drawing.Point(0, 0);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(393, 165);
            this.filePanel.TabIndex = 0;
            // 
            // fromFileLabel
            // 
            this.fromFileLabel.AutoSize = true;
            this.fromFileLabel.Location = new System.Drawing.Point(42, 38);
            this.fromFileLabel.Name = "fromFileLabel";
            this.fromFileLabel.Size = new System.Drawing.Size(63, 15);
            this.fromFileLabel.TabIndex = 1;
            this.fromFileLabel.Text = "From file...";
            // 
            // customModelButton
            // 
            this.customModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customModelButton.Location = new System.Drawing.Point(302, 34);
            this.customModelButton.Name = "customModelButton";
            this.customModelButton.Size = new System.Drawing.Size(75, 23);
            this.customModelButton.TabIndex = 0;
            this.customModelButton.Text = "...";
            this.customModelButton.UseVisualStyleBackColor = true;
            this.customModelButton.Click += new System.EventHandler(this.customModelButton_Click);
            // 
            // aspectPanel
            // 
            this.aspectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aspectPanel.Controls.Add(this.aspectLabel);
            this.aspectPanel.Controls.Add(this.aspectRatioUpDown);
            this.aspectPanel.Location = new System.Drawing.Point(0, 0);
            this.aspectPanel.Name = "aspectPanel";
            this.aspectPanel.Size = new System.Drawing.Size(393, 153);
            this.aspectPanel.TabIndex = 0;
            // 
            // aspectLabel
            // 
            this.aspectLabel.AutoSize = true;
            this.aspectLabel.Location = new System.Drawing.Point(42, 68);
            this.aspectLabel.Name = "aspectLabel";
            this.aspectLabel.Size = new System.Drawing.Size(46, 15);
            this.aspectLabel.TabIndex = 1;
            this.aspectLabel.Text = "Aspect:";
            // 
            // aspectRatioUpDown
            // 
            this.aspectRatioUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aspectRatioUpDown.DecimalPlaces = 2;
            this.aspectRatioUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aspectRatioUpDown.Location = new System.Drawing.Point(302, 66);
            this.aspectRatioUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspectRatioUpDown.Name = "aspectRatioUpDown";
            this.aspectRatioUpDown.Size = new System.Drawing.Size(75, 23);
            this.aspectRatioUpDown.TabIndex = 0;
            this.aspectRatioUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aspectRatioUpDown.ValueChanged += new System.EventHandler(this.aspectRatioUpDown_ValueChanged);
            // 
            // FeaturesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filePanel);
            this.Name = "FeaturesPanel";
            this.Size = new System.Drawing.Size(393, 410);
            this.VisibleChanged += new System.EventHandler(this.FeaturesPanel_VisibleChanged);
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            this.aspectPanel.ResumeLayout(false);
            this.aspectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Label fromFileLabel;
        private System.Windows.Forms.Button customModelButton;
        private System.Windows.Forms.Panel aspectPanel;
        private System.Windows.Forms.Label aspectLabel;
        private System.Windows.Forms.NumericUpDown aspectRatioUpDown;
    }
}
