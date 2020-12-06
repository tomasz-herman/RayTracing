using System.ComponentModel;

namespace RayTracerApp.Controls.Features
{
    partial class CubeFeaturesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.edgeLabel = new System.Windows.Forms.Label();
            this.edgeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.edgeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // edgeLabel
            // 
            this.edgeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edgeLabel.AutoSize = true;
            this.edgeLabel.Location = new System.Drawing.Point(113, 39);
            this.edgeLabel.Name = "edgeLabel";
            this.edgeLabel.Size = new System.Drawing.Size(33, 15);
            this.edgeLabel.TabIndex = 0;
            this.edgeLabel.Text = "Edge";
            // 
            // edgeUpDown
            // 
            this.edgeUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edgeUpDown.DecimalPlaces = 2;
            this.edgeUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.edgeUpDown.Location = new System.Drawing.Point(152, 37);
            this.edgeUpDown.Name = "edgeUpDown";
            this.edgeUpDown.Size = new System.Drawing.Size(53, 23);
            this.edgeUpDown.TabIndex = 1;
            this.edgeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edgeUpDown.ValueChanged += new System.EventHandler(this.edgeUpDown_ValueChanged);
            // 
            // CubeFeaturesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edgeUpDown);
            this.Controls.Add(this.edgeLabel);
            this.Name = "CubeFeaturesControl";
            this.Size = new System.Drawing.Size(216, 81);
            ((System.ComponentModel.ISupportInitialize)(this.edgeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label edgeLabel;
        private System.Windows.Forms.NumericUpDown edgeUpDown;
    }
}