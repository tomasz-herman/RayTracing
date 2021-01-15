
namespace RayTracerApp.Panels.FeaturesPanels
{
    partial class DoubleAspectFeature
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
            this.aspect2UpDown = new System.Windows.Forms.NumericUpDown();
            this.aspect1UpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aspect2UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspect1UpDown)).BeginInit();
            this.SuspendLayout();
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
            this.aspect2UpDown.Location = new System.Drawing.Point(200, 58);
            this.aspect2UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspect2UpDown.Name = "aspect2UpDown";
            this.aspect2UpDown.Size = new System.Drawing.Size(75, 23);
            this.aspect2UpDown.TabIndex = 7;
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
            this.aspect1UpDown.Location = new System.Drawing.Point(200, 28);
            this.aspect1UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.aspect1UpDown.Name = "aspect1UpDown";
            this.aspect1UpDown.Size = new System.Drawing.Size(75, 23);
            this.aspect1UpDown.TabIndex = 6;
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
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Aspect 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Aspect 1:";
            // 
            // DoubleAspectFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aspect2UpDown);
            this.Controls.Add(this.aspect1UpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DoubleAspectFeature";
            this.Size = new System.Drawing.Size(300, 100);
            ((System.ComponentModel.ISupportInitialize)(this.aspect2UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspect1UpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown aspect2UpDown;
        private System.Windows.Forms.NumericUpDown aspect1UpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
