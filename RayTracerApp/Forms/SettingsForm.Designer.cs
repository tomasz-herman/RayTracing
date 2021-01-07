
namespace RayTracerApp.Forms
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.samplesUpDown = new System.Windows.Forms.NumericUpDown();
            this.updateUpDown = new System.Windows.Forms.NumericUpDown();
            this.bloomUpDown = new System.Windows.Forms.NumericUpDown();
            this.recursionCheckbox = new System.Windows.Forms.CheckBox();
            this.gammaUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.randomRadioButton = new System.Windows.Forms.RadioButton();
            this.centerRadioButton = new System.Windows.Forms.RadioButton();
            this.jitteredRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ortographicCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.lensCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.perspectiveCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.lensCameraLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.lensRadiusUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.fovUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.recLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloomUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.lensCameraLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lensRadiusUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDistanceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recLevelUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 586);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 287);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ray Tracer";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label16, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.samplesUpDown, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.updateUpDown, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.bloomUpDown, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.gammaUpDown, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.recursionCheckbox, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.recLevelUpDown, 1, 5);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(587, 256);
            this.tableLayoutPanel4.TabIndex = 0;
            this.tableLayoutPanel4.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_CellPaint);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 181);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ray tracing by recursion levels (unoptimal)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Samples";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Update frequency";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(93, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "Gamma correction";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "Bloom";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // samplesUpDown
            // 
            this.samplesUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.samplesUpDown.Location = new System.Drawing.Point(380, 9);
            this.samplesUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.samplesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.samplesUpDown.Name = "samplesUpDown";
            this.samplesUpDown.Size = new System.Drawing.Size(120, 23);
            this.samplesUpDown.TabIndex = 6;
            this.samplesUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.samplesUpDown.ValueChanged += new System.EventHandler(this.samplesUpDown_ValueChanged);
            // 
            // updateUpDown
            // 
            this.updateUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.updateUpDown.Location = new System.Drawing.Point(380, 51);
            this.updateUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.updateUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updateUpDown.Name = "updateUpDown";
            this.updateUpDown.Size = new System.Drawing.Size(120, 23);
            this.updateUpDown.TabIndex = 7;
            this.updateUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.updateUpDown.ValueChanged += new System.EventHandler(this.updateUpDown_ValueChanged);
            // 
            // bloomUpDown
            // 
            this.bloomUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bloomUpDown.Location = new System.Drawing.Point(380, 135);
            this.bloomUpDown.Name = "bloomUpDown";
            this.bloomUpDown.Size = new System.Drawing.Size(120, 23);
            this.bloomUpDown.TabIndex = 11;
            this.bloomUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.bloomUpDown.ValueChanged += new System.EventHandler(this.bloomUpDown_ValueChanged);
            // 
            // recursionCheckbox
            // 
            this.recursionCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recursionCheckbox.AutoSize = true;
            this.recursionCheckbox.Location = new System.Drawing.Point(432, 182);
            this.recursionCheckbox.Name = "recursionCheckbox";
            this.recursionCheckbox.Size = new System.Drawing.Size(15, 14);
            this.recursionCheckbox.TabIndex = 10;
            this.recursionCheckbox.UseVisualStyleBackColor = true;
            this.recursionCheckbox.CheckedChanged += new System.EventHandler(this.recursionCheckbox_CheckedChanged);
            // 
            // gammaUpDown
            // 
            this.gammaUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gammaUpDown.Location = new System.Drawing.Point(380, 93);
            this.gammaUpDown.Name = "gammaUpDown";
            this.gammaUpDown.Size = new System.Drawing.Size(120, 23);
            this.gammaUpDown.TabIndex = 12;
            this.gammaUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.gammaUpDown.ValueChanged += new System.EventHandler(this.gammaUpDown_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.fovUpDown, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(590, 259);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_CellPaint);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.randomRadioButton);
            this.panel2.Controls.Add(this.centerRadioButton);
            this.panel2.Controls.Add(this.jitteredRadioButton);
            this.panel2.Location = new System.Drawing.Point(298, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 81);
            this.panel2.TabIndex = 5;
            // 
            // randomRadioButton
            // 
            this.randomRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randomRadioButton.AutoSize = true;
            this.randomRadioButton.Location = new System.Drawing.Point(0, 54);
            this.randomRadioButton.Name = "randomRadioButton";
            this.randomRadioButton.Size = new System.Drawing.Size(70, 19);
            this.randomRadioButton.TabIndex = 2;
            this.randomRadioButton.Text = "Random";
            this.randomRadioButton.UseVisualStyleBackColor = true;
            this.randomRadioButton.CheckedChanged += new System.EventHandler(this.randomRadioButton_CheckedChanged);
            // 
            // centerRadioButton
            // 
            this.centerRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.centerRadioButton.AutoSize = true;
            this.centerRadioButton.Location = new System.Drawing.Point(0, 29);
            this.centerRadioButton.Name = "centerRadioButton";
            this.centerRadioButton.Size = new System.Drawing.Size(60, 19);
            this.centerRadioButton.TabIndex = 1;
            this.centerRadioButton.Text = "Center";
            this.centerRadioButton.UseVisualStyleBackColor = true;
            this.centerRadioButton.CheckedChanged += new System.EventHandler(this.centerRadioButton_CheckedChanged);
            // 
            // jitteredRadioButton
            // 
            this.jitteredRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jitteredRadioButton.AutoSize = true;
            this.jitteredRadioButton.Checked = true;
            this.jitteredRadioButton.Location = new System.Drawing.Point(0, 4);
            this.jitteredRadioButton.Name = "jitteredRadioButton";
            this.jitteredRadioButton.Size = new System.Drawing.Size(63, 19);
            this.jitteredRadioButton.TabIndex = 0;
            this.jitteredRadioButton.TabStop = true;
            this.jitteredRadioButton.Text = "Jittered";
            this.jitteredRadioButton.UseVisualStyleBackColor = true;
            this.jitteredRadioButton.CheckedChanged += new System.EventHandler(this.jitteredRadioButton_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Camera type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Field of view";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Sampling";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lensCameraLayoutPanel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(298, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(289, 80);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ortographicCameraRadioButton);
            this.panel1.Controls.Add(this.lensCameraRadioButton);
            this.panel1.Controls.Add(this.perspectiveCameraRadioButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 74);
            this.panel1.TabIndex = 2;
            // 
            // ortographicCameraRadioButton
            // 
            this.ortographicCameraRadioButton.AutoSize = true;
            this.ortographicCameraRadioButton.Location = new System.Drawing.Point(0, 54);
            this.ortographicCameraRadioButton.Name = "ortographicCameraRadioButton";
            this.ortographicCameraRadioButton.Size = new System.Drawing.Size(89, 19);
            this.ortographicCameraRadioButton.TabIndex = 2;
            this.ortographicCameraRadioButton.Text = "Ortographic";
            this.ortographicCameraRadioButton.UseVisualStyleBackColor = true;
            this.ortographicCameraRadioButton.CheckedChanged += new System.EventHandler(this.ortographicCameraRadioButton_CheckedChanged);
            // 
            // lensCameraRadioButton
            // 
            this.lensCameraRadioButton.AutoSize = true;
            this.lensCameraRadioButton.Location = new System.Drawing.Point(0, 29);
            this.lensCameraRadioButton.Name = "lensCameraRadioButton";
            this.lensCameraRadioButton.Size = new System.Drawing.Size(49, 19);
            this.lensCameraRadioButton.TabIndex = 1;
            this.lensCameraRadioButton.Text = "Lens";
            this.lensCameraRadioButton.UseVisualStyleBackColor = true;
            this.lensCameraRadioButton.CheckedChanged += new System.EventHandler(this.lensCameraRadioButton_CheckedChanged);
            // 
            // perspectiveCameraRadioButton
            // 
            this.perspectiveCameraRadioButton.AutoSize = true;
            this.perspectiveCameraRadioButton.Location = new System.Drawing.Point(0, 4);
            this.perspectiveCameraRadioButton.Name = "perspectiveCameraRadioButton";
            this.perspectiveCameraRadioButton.Size = new System.Drawing.Size(85, 19);
            this.perspectiveCameraRadioButton.TabIndex = 0;
            this.perspectiveCameraRadioButton.Text = "Perspective";
            this.perspectiveCameraRadioButton.UseVisualStyleBackColor = true;
            this.perspectiveCameraRadioButton.CheckedChanged += new System.EventHandler(this.perspectiveCameraRadioButton_CheckedChanged);
            // 
            // lensCameraLayoutPanel
            // 
            this.lensCameraLayoutPanel.ColumnCount = 2;
            this.lensCameraLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lensCameraLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lensCameraLayoutPanel.Controls.Add(this.label15, 0, 1);
            this.lensCameraLayoutPanel.Controls.Add(this.lensRadiusUpDown, 1, 0);
            this.lensCameraLayoutPanel.Controls.Add(this.focusDistanceUpDown, 1, 1);
            this.lensCameraLayoutPanel.Controls.Add(this.label14, 0, 0);
            this.lensCameraLayoutPanel.Location = new System.Drawing.Point(147, 3);
            this.lensCameraLayoutPanel.Name = "lensCameraLayoutPanel";
            this.lensCameraLayoutPanel.RowCount = 2;
            this.lensCameraLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lensCameraLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lensCameraLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.lensCameraLayoutPanel.Size = new System.Drawing.Size(139, 74);
            this.lensCameraLayoutPanel.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 30);
            this.label15.TabIndex = 8;
            this.label15.Text = "Focus distance";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lensRadiusUpDown
            // 
            this.lensRadiusUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lensRadiusUpDown.DecimalPlaces = 2;
            this.lensRadiusUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lensRadiusUpDown.Location = new System.Drawing.Point(72, 7);
            this.lensRadiusUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lensRadiusUpDown.Name = "lensRadiusUpDown";
            this.lensRadiusUpDown.Size = new System.Drawing.Size(64, 23);
            this.lensRadiusUpDown.TabIndex = 5;
            this.lensRadiusUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.lensRadiusUpDown.ValueChanged += new System.EventHandler(this.lensRadiusUpDown_ValueChanged);
            // 
            // focusDistanceUpDown
            // 
            this.focusDistanceUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.focusDistanceUpDown.DecimalPlaces = 2;
            this.focusDistanceUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.focusDistanceUpDown.Location = new System.Drawing.Point(72, 44);
            this.focusDistanceUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.focusDistanceUpDown.Name = "focusDistanceUpDown";
            this.focusDistanceUpDown.Size = new System.Drawing.Size(64, 23);
            this.focusDistanceUpDown.TabIndex = 6;
            this.focusDistanceUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.focusDistanceUpDown.ValueChanged += new System.EventHandler(this.focusDistanceUpDown_ValueChanged);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "Radius";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fovUpDown
            // 
            this.fovUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fovUpDown.Location = new System.Drawing.Point(382, 117);
            this.fovUpDown.Maximum = new decimal(new int[] {
            170,
            0,
            0,
            0});
            this.fovUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.fovUpDown.Name = "fovUpDown";
            this.fovUpDown.Size = new System.Drawing.Size(120, 23);
            this.fovUpDown.TabIndex = 4;
            this.fovUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.fovUpDown.ValueChanged += new System.EventHandler(this.fovUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "label5";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(102, 225);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 15);
            this.label16.TabIndex = 13;
            this.label16.Text = "Recursion leves";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recLevelUpDown
            // 
            this.recLevelUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recLevelUpDown.Location = new System.Drawing.Point(380, 221);
            this.recLevelUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.recLevelUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.recLevelUpDown.Name = "recLevelUpDown";
            this.recLevelUpDown.Size = new System.Drawing.Size(120, 23);
            this.recLevelUpDown.TabIndex = 14;
            this.recLevelUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.recLevelUpDown.ValueChanged += new System.EventHandler(this.recLevelUpDown_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 586);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloomUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.lensCameraLayoutPanel.ResumeLayout(false);
            this.lensCameraLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lensRadiusUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDistanceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recLevelUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton randomRadioButton;
        private System.Windows.Forms.RadioButton centerRadioButton;
        private System.Windows.Forms.RadioButton jitteredRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton ortographicCameraRadioButton;
        private System.Windows.Forms.RadioButton lensCameraRadioButton;
        private System.Windows.Forms.RadioButton perspectiveCameraRadioButton;
        private System.Windows.Forms.NumericUpDown fovUpDown;
        private System.Windows.Forms.NumericUpDown samplesUpDown;
        private System.Windows.Forms.NumericUpDown updateUpDown;
        private System.Windows.Forms.CheckBox recursionCheckbox;
        private System.Windows.Forms.NumericUpDown bloomUpDown;
        private System.Windows.Forms.NumericUpDown gammaUpDown;
        private System.Windows.Forms.TableLayoutPanel lensCameraLayoutPanel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown lensRadiusUpDown;
        private System.Windows.Forms.NumericUpDown focusDistanceUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown recLevelUpDown;
        private System.Windows.Forms.NumericUpDown recursionLevelUpDown;
    }
}