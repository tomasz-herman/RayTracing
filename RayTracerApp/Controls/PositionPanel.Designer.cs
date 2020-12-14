
namespace RayTracerApp.Controls
{
    partial class PositionPanel
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
            this.translationGroupBox = new System.Windows.Forms.GroupBox();
            this.translationLabel = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.zUpDown = new System.Windows.Forms.NumericUpDown();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.rotationGroupBox = new System.Windows.Forms.GroupBox();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.rollLabel = new System.Windows.Forms.Label();
            this.yawLabel = new System.Windows.Forms.Label();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.rollUpDown = new System.Windows.Forms.NumericUpDown();
            this.yawUpDown = new System.Windows.Forms.NumericUpDown();
            this.pitchUpDown = new System.Windows.Forms.NumericUpDown();
            this.scaleGroupBox = new System.Windows.Forms.GroupBox();
            this.scaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.translationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            this.rotationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rollUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yawUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchUpDown)).BeginInit();
            this.scaleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // translationGroupBox
            // 
            this.translationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translationGroupBox.Controls.Add(this.translationLabel);
            this.translationGroupBox.Controls.Add(this.zLabel);
            this.translationGroupBox.Controls.Add(this.yLabel);
            this.translationGroupBox.Controls.Add(this.xLabel);
            this.translationGroupBox.Controls.Add(this.zUpDown);
            this.translationGroupBox.Controls.Add(this.yUpDown);
            this.translationGroupBox.Controls.Add(this.xUpDown);
            this.translationGroupBox.Location = new System.Drawing.Point(0, 0);
            this.translationGroupBox.Name = "translationGroupBox";
            this.translationGroupBox.Size = new System.Drawing.Size(255, 100);
            this.translationGroupBox.TabIndex = 0;
            this.translationGroupBox.TabStop = false;
            // 
            // translationLabel
            // 
            this.translationLabel.AutoSize = true;
            this.translationLabel.Location = new System.Drawing.Point(6, 44);
            this.translationLabel.Name = "translationLabel";
            this.translationLabel.Size = new System.Drawing.Size(67, 15);
            this.translationLabel.TabIndex = 0;
            this.translationLabel.Text = "Translation:";
            // 
            // zLabel
            // 
            this.zLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zLabel.AutoSize = true;
            this.zLabel.Location = new System.Drawing.Point(159, 73);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(14, 15);
            this.zLabel.TabIndex = 4;
            this.zLabel.Text = "Z";
            // 
            // yLabel
            // 
            this.yLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(159, 44);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 15);
            this.yLabel.TabIndex = 3;
            this.yLabel.Text = "Y";
            // 
            // xLabel
            // 
            this.xLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(159, 15);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 15);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "X";
            // 
            // zUpDown
            // 
            this.zUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zUpDown.DecimalPlaces = 2;
            this.zUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zUpDown.Location = new System.Drawing.Point(179, 71);
            this.zUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.zUpDown.Name = "zUpDown";
            this.zUpDown.Size = new System.Drawing.Size(70, 23);
            this.zUpDown.TabIndex = 2;
            this.zUpDown.ValueChanged += new System.EventHandler(this.zUpDown_ValueChanged);
            // 
            // yUpDown
            // 
            this.yUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yUpDown.DecimalPlaces = 2;
            this.yUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yUpDown.Location = new System.Drawing.Point(179, 42);
            this.yUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.Size = new System.Drawing.Size(70, 23);
            this.yUpDown.TabIndex = 1;
            this.yUpDown.ValueChanged += new System.EventHandler(this.yUpDown_ValueChanged);
            // 
            // xUpDown
            // 
            this.xUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xUpDown.DecimalPlaces = 2;
            this.xUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xUpDown.Location = new System.Drawing.Point(179, 13);
            this.xUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.Size = new System.Drawing.Size(70, 23);
            this.xUpDown.TabIndex = 0;
            this.xUpDown.ValueChanged += new System.EventHandler(this.xUpDown_ValueChanged);
            // 
            // rotationGroupBox
            // 
            this.rotationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationGroupBox.Controls.Add(this.rotationLabel);
            this.rotationGroupBox.Controls.Add(this.rollLabel);
            this.rotationGroupBox.Controls.Add(this.yawLabel);
            this.rotationGroupBox.Controls.Add(this.pitchLabel);
            this.rotationGroupBox.Controls.Add(this.rollUpDown);
            this.rotationGroupBox.Controls.Add(this.yawUpDown);
            this.rotationGroupBox.Controls.Add(this.pitchUpDown);
            this.rotationGroupBox.Location = new System.Drawing.Point(0, 106);
            this.rotationGroupBox.Name = "rotationGroupBox";
            this.rotationGroupBox.Size = new System.Drawing.Size(255, 100);
            this.rotationGroupBox.TabIndex = 0;
            this.rotationGroupBox.TabStop = false;
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(6, 44);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(55, 15);
            this.rotationLabel.TabIndex = 11;
            this.rotationLabel.Text = "Rotation:";
            // 
            // rollLabel
            // 
            this.rollLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rollLabel.AutoSize = true;
            this.rollLabel.Location = new System.Drawing.Point(139, 73);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(27, 15);
            this.rollLabel.TabIndex = 10;
            this.rollLabel.Text = "Roll";
            // 
            // yawLabel
            // 
            this.yawLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yawLabel.AutoSize = true;
            this.yawLabel.Location = new System.Drawing.Point(139, 44);
            this.yawLabel.Name = "yawLabel";
            this.yawLabel.Size = new System.Drawing.Size(28, 15);
            this.yawLabel.TabIndex = 9;
            this.yawLabel.Text = "Yaw";
            // 
            // pitchLabel
            // 
            this.pitchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Location = new System.Drawing.Point(139, 15);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(34, 15);
            this.pitchLabel.TabIndex = 5;
            this.pitchLabel.Text = "Pitch";
            // 
            // rollUpDown
            // 
            this.rollUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rollUpDown.DecimalPlaces = 2;
            this.rollUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rollUpDown.Location = new System.Drawing.Point(179, 71);
            this.rollUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.rollUpDown.Name = "rollUpDown";
            this.rollUpDown.Size = new System.Drawing.Size(70, 23);
            this.rollUpDown.TabIndex = 8;
            this.rollUpDown.ValueChanged += new System.EventHandler(this.rollUpDown_ValueChanged);
            // 
            // yawUpDown
            // 
            this.yawUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yawUpDown.DecimalPlaces = 2;
            this.yawUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yawUpDown.Location = new System.Drawing.Point(179, 42);
            this.yawUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yawUpDown.Name = "yawUpDown";
            this.yawUpDown.Size = new System.Drawing.Size(70, 23);
            this.yawUpDown.TabIndex = 7;
            this.yawUpDown.ValueChanged += new System.EventHandler(this.yawUpDown_ValueChanged);
            // 
            // pitchUpDown
            // 
            this.pitchUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pitchUpDown.DecimalPlaces = 2;
            this.pitchUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pitchUpDown.Location = new System.Drawing.Point(179, 13);
            this.pitchUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.pitchUpDown.Name = "pitchUpDown";
            this.pitchUpDown.Size = new System.Drawing.Size(70, 23);
            this.pitchUpDown.TabIndex = 6;
            this.pitchUpDown.ValueChanged += new System.EventHandler(this.pitchUpDown_ValueChanged);
            // 
            // scaleGroupBox
            // 
            this.scaleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleGroupBox.Controls.Add(this.scaleUpDown);
            this.scaleGroupBox.Controls.Add(this.scaleLabel);
            this.scaleGroupBox.Location = new System.Drawing.Point(0, 212);
            this.scaleGroupBox.Name = "scaleGroupBox";
            this.scaleGroupBox.Size = new System.Drawing.Size(258, 100);
            this.scaleGroupBox.TabIndex = 1;
            this.scaleGroupBox.TabStop = false;
            // 
            // scaleUpDown
            // 
            this.scaleUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleUpDown.DecimalPlaces = 2;
            this.scaleUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleUpDown.Location = new System.Drawing.Point(179, 46);
            this.scaleUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.scaleUpDown.Name = "scaleUpDown";
            this.scaleUpDown.Size = new System.Drawing.Size(70, 23);
            this.scaleUpDown.TabIndex = 8;
            this.scaleUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleUpDown.ValueChanged += new System.EventHandler(this.scaleUpDown_ValueChanged);
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(6, 48);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(37, 15);
            this.scaleLabel.TabIndex = 0;
            this.scaleLabel.Text = "Scale:";
            // 
            // PositionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleGroupBox);
            this.Controls.Add(this.rotationGroupBox);
            this.Controls.Add(this.translationGroupBox);
            this.Name = "PositionPanel";
            this.Size = new System.Drawing.Size(258, 330);
            this.translationGroupBox.ResumeLayout(false);
            this.translationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            this.rotationGroupBox.ResumeLayout(false);
            this.rotationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rollUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yawUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchUpDown)).EndInit();
            this.scaleGroupBox.ResumeLayout(false);
            this.scaleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox translationGroupBox;
        private System.Windows.Forms.NumericUpDown zUpDown;
        private System.Windows.Forms.NumericUpDown yUpDown;
        private System.Windows.Forms.NumericUpDown xUpDown;
        private System.Windows.Forms.GroupBox rotationGroupBox;
        private System.Windows.Forms.GroupBox scaleGroupBox;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.Label yawLabel;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.NumericUpDown rollUpDown;
        private System.Windows.Forms.NumericUpDown yawUpDown;
        private System.Windows.Forms.NumericUpDown pitchUpDown;
        private System.Windows.Forms.Label translationLabel;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.NumericUpDown scaleUpDown;
        private System.Windows.Forms.Label scaleLabel;
    }
}
