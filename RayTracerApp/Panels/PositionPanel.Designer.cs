
namespace RayTracerApp.Panels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.zUpDown = new System.Windows.Forms.NumericUpDown();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rollUpDown = new System.Windows.Forms.NumericUpDown();
            this.yawUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pitchUpDown = new System.Windows.Forms.NumericUpDown();
            this.scaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rollUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yawUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.scaleUpDown, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.zUpDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.yUpDown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.xUpDown, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // zUpDown
            // 
            resources.ApplyResources(this.zUpDown, "zUpDown");
            this.zUpDown.DecimalPlaces = 2;
            this.zUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.zUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.zUpDown.Name = "zUpDown";
            this.zUpDown.ValueChanged += new System.EventHandler(this.zUpDown_ValueChanged);
            // 
            // yUpDown
            // 
            resources.ApplyResources(this.yUpDown, "yUpDown");
            this.yUpDown.DecimalPlaces = 2;
            this.yUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.yUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.ValueChanged += new System.EventHandler(this.yUpDown_ValueChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // xUpDown
            // 
            resources.ApplyResources(this.xUpDown, "xUpDown");
            this.xUpDown.DecimalPlaces = 2;
            this.xUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.xUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.ValueChanged += new System.EventHandler(this.xUpDown_ValueChanged);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.rollUpDown, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.yawUpDown, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.pitchUpDown, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // rollUpDown
            // 
            resources.ApplyResources(this.rollUpDown, "rollUpDown");
            this.rollUpDown.DecimalPlaces = 2;
            this.rollUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.rollUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rollUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.rollUpDown.Name = "rollUpDown";
            this.rollUpDown.ValueChanged += new System.EventHandler(this.rollUpDown_ValueChanged);
            // 
            // yawUpDown
            // 
            resources.ApplyResources(this.yawUpDown, "yawUpDown");
            this.yawUpDown.DecimalPlaces = 2;
            this.yawUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.yawUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.yawUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.yawUpDown.Name = "yawUpDown";
            this.yawUpDown.ValueChanged += new System.EventHandler(this.yawUpDown_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // pitchUpDown
            // 
            resources.ApplyResources(this.pitchUpDown, "pitchUpDown");
            this.pitchUpDown.DecimalPlaces = 2;
            this.pitchUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pitchUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.pitchUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.pitchUpDown.Name = "pitchUpDown";
            this.pitchUpDown.ValueChanged += new System.EventHandler(this.pitchUpDown_ValueChanged);
            // 
            // scaleUpDown
            // 
            resources.ApplyResources(this.scaleUpDown, "scaleUpDown");
            this.scaleUpDown.DecimalPlaces = 2;
            this.scaleUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.scaleUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.scaleUpDown.Name = "scaleUpDown";
            this.scaleUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleUpDown.ValueChanged += new System.EventHandler(this.scaleUpDown_ValueChanged);
            // 
            // PositionPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PositionPanel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rollUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yawUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pitchUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown zUpDown;
        private System.Windows.Forms.NumericUpDown yUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown xUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown rollUpDown;
        private System.Windows.Forms.NumericUpDown yawUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown pitchUpDown;
        private System.Windows.Forms.NumericUpDown scaleUpDown;
    }
}
