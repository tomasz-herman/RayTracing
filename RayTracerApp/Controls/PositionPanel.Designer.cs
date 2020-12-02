
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.zUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.zUpDown);
            this.groupBox1.Controls.Add(this.yUpDown);
            this.groupBox1.Controls.Add(this.xUpDown);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // xUpDown
            // 
            this.xUpDown.DecimalPlaces = 2;
            this.xUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xUpDown.Location = new System.Drawing.Point(185, 13);
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
            // yUpDown
            // 
            this.yUpDown.DecimalPlaces = 2;
            this.yUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yUpDown.Location = new System.Drawing.Point(185, 42);
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
            // zUpDown
            // 
            this.zUpDown.DecimalPlaces = 2;
            this.zUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zUpDown.Location = new System.Drawing.Point(185, 71);
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
            // PositionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PositionPanel";
            this.Size = new System.Drawing.Size(258, 330);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown zUpDown;
        private System.Windows.Forms.NumericUpDown yUpDown;
        private System.Windows.Forms.NumericUpDown xUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
