
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
            this.aspect2Panel = new System.Windows.Forms.Panel();
            this.aspect2UpDown = new System.Windows.Forms.NumericUpDown();
            this.aspect1UpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filePanel.SuspendLayout();
            this.aspectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).BeginInit();
            this.aspect2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aspect2UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspect1UpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // filePanel
            // 
            this.filePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePanel.Controls.Add(this.fromFileLabel);
            this.filePanel.Controls.Add(this.customModelButton);
            this.filePanel.Location = new System.Drawing.Point(0, 0);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(393, 70);
            this.filePanel.TabIndex = 0;
            this.filePanel.Visible = false;
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
            this.aspectPanel.Location = new System.Drawing.Point(0, 76);
            this.aspectPanel.Name = "aspectPanel";
            this.aspectPanel.Size = new System.Drawing.Size(393, 32);
            this.aspectPanel.TabIndex = 0;
            this.aspectPanel.Visible = false;
            // 
            // aspectLabel
            // 
            this.aspectLabel.AutoSize = true;
            this.aspectLabel.Location = new System.Drawing.Point(42, 2);
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
            this.aspectRatioUpDown.Location = new System.Drawing.Point(302, 0);
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
            // aspect2Panel
            // 
            this.aspect2Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aspect2Panel.Controls.Add(this.aspect2UpDown);
            this.aspect2Panel.Controls.Add(this.aspect1UpDown);
            this.aspect2Panel.Controls.Add(this.label2);
            this.aspect2Panel.Controls.Add(this.label1);
            this.aspect2Panel.Location = new System.Drawing.Point(0, 114);
            this.aspect2Panel.Name = "aspect2Panel";
            this.aspect2Panel.Size = new System.Drawing.Size(393, 66);
            this.aspect2Panel.TabIndex = 2;
            // 
            // aspect2UpDown
            // 
            this.aspect2UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aspect2UpDown.DecimalPlaces = 2;
            this.aspect2UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aspect2UpDown.Location = new System.Drawing.Point(302, 32);
            this.aspect2UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspect2UpDown.Name = "aspect2UpDown";
            this.aspect2UpDown.Size = new System.Drawing.Size(75, 23);
            this.aspect2UpDown.TabIndex = 3;
            this.aspect2UpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aspect2UpDown.ValueChanged += new System.EventHandler(this.aspect2UpDown_ValueChanged);
            // 
            // aspect1UpDown
            // 
            this.aspect1UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aspect1UpDown.DecimalPlaces = 2;
            this.aspect1UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.aspect1UpDown.Location = new System.Drawing.Point(302, 3);
            this.aspect1UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspect1UpDown.Name = "aspect1UpDown";
            this.aspect1UpDown.Size = new System.Drawing.Size(75, 23);
            this.aspect1UpDown.TabIndex = 2;
            this.aspect1UpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aspect1UpDown.ValueChanged += new System.EventHandler(this.aspect1UpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aspect 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aspect 1:";
            // 
            // FeaturesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aspect2Panel);
            this.Controls.Add(this.aspectPanel);
            this.Controls.Add(this.filePanel);
            this.Name = "FeaturesPanel";
            this.Size = new System.Drawing.Size(393, 410);
            this.VisibleChanged += new System.EventHandler(this.FeaturesPanel_VisibleChanged);
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            this.aspectPanel.ResumeLayout(false);
            this.aspectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aspectRatioUpDown)).EndInit();
            this.aspect2Panel.ResumeLayout(false);
            this.aspect2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aspect2UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspect1UpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Label fromFileLabel;
        private System.Windows.Forms.Button customModelButton;
        private System.Windows.Forms.Panel aspectPanel;
        private System.Windows.Forms.Label aspectLabel;
        private System.Windows.Forms.NumericUpDown aspectRatioUpDown;
        private System.Windows.Forms.Panel aspect2Panel;
        private System.Windows.Forms.NumericUpDown aspect2UpDown;
        private System.Windows.Forms.NumericUpDown aspect1UpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
