
namespace RayTracerApp.Panels
{
    partial class MaterialPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.refractiveIndexUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.refractiveTexture = new System.Windows.Forms.Label();
            this.refractiveColor = new System.Windows.Forms.Button();
            this.refractiveFile = new System.Windows.Forms.Button();
            this.refractiveShareUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.reflectiveDisturbanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.reflectiveTexture = new System.Windows.Forms.Label();
            this.reflectiveColor = new System.Windows.Forms.Button();
            this.reflectiveFile = new System.Windows.Forms.Button();
            this.reflectiveShareUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.ampUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.emissiveTexture = new System.Windows.Forms.Label();
            this.emissiveColor = new System.Windows.Forms.Button();
            this.emissiveFile = new System.Windows.Forms.Button();
            this.emissiveShareUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.diffuseTexture = new System.Windows.Forms.Label();
            this.diffuseColor = new System.Windows.Forms.Button();
            this.diffuseFile = new System.Windows.Forms.Button();
            this.diffuseShareUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refractiveIndexUpDown)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refractiveShareUpDown)).BeginInit();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectiveDisturbanceUpDown)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectiveShareUpDown)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ampUpDown)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emissiveShareUpDown)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diffuseShareUpDown)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel11, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // tableLayoutPanel12
            // 
            resources.ApplyResources(this.tableLayoutPanel12, "tableLayoutPanel12");
            this.tableLayoutPanel12.Controls.Add(this.refractiveIndexUpDown, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel13, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.refractiveShareUpDown, 0, 1);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            // 
            // refractiveIndexUpDown
            // 
            resources.ApplyResources(this.refractiveIndexUpDown, "refractiveIndexUpDown");
            this.refractiveIndexUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.refractiveIndexUpDown.DecimalPlaces = 2;
            this.refractiveIndexUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.refractiveIndexUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.refractiveIndexUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.refractiveIndexUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.refractiveIndexUpDown.Name = "refractiveIndexUpDown";
            this.refractiveIndexUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.refractiveIndexUpDown.ValueChanged += new System.EventHandler(this.refractiveIndexUpDown_ValueChanged);
            // 
            // tableLayoutPanel13
            // 
            resources.ApplyResources(this.tableLayoutPanel13, "tableLayoutPanel13");
            this.tableLayoutPanel13.Controls.Add(this.refractiveTexture, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.refractiveColor, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.refractiveFile, 2, 0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            // 
            // refractiveTexture
            // 
            resources.ApplyResources(this.refractiveTexture, "refractiveTexture");
            this.refractiveTexture.Name = "refractiveTexture";
            // 
            // refractiveColor
            // 
            resources.ApplyResources(this.refractiveColor, "refractiveColor");
            this.refractiveColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.refractiveColor.Name = "refractiveColor";
            this.refractiveColor.UseVisualStyleBackColor = false;
            this.refractiveColor.Click += new System.EventHandler(this.refractiveColor_Click);
            // 
            // refractiveFile
            // 
            resources.ApplyResources(this.refractiveFile, "refractiveFile");
            this.refractiveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.refractiveFile.Name = "refractiveFile";
            this.refractiveFile.UseVisualStyleBackColor = false;
            this.refractiveFile.Click += new System.EventHandler(this.refractiveFile_Click);
            // 
            // refractiveShareUpDown
            // 
            resources.ApplyResources(this.refractiveShareUpDown, "refractiveShareUpDown");
            this.refractiveShareUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.refractiveShareUpDown.DecimalPlaces = 2;
            this.refractiveShareUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.refractiveShareUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.refractiveShareUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.refractiveShareUpDown.Name = "refractiveShareUpDown";
            this.refractiveShareUpDown.ValueChanged += new System.EventHandler(this.refractiveShareUpDown_ValueChanged);
            // 
            // tableLayoutPanel11
            // 
            resources.ApplyResources(this.tableLayoutPanel11, "tableLayoutPanel11");
            this.tableLayoutPanel11.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.Gainsboro;
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.Color.Gainsboro;
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.Color.Gainsboro;
            this.label17.Name = "label17";
            // 
            // tableLayoutPanel9
            // 
            resources.ApplyResources(this.tableLayoutPanel9, "tableLayoutPanel9");
            this.tableLayoutPanel9.Controls.Add(this.reflectiveDisturbanceUpDown, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.reflectiveShareUpDown, 0, 1);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            // 
            // reflectiveDisturbanceUpDown
            // 
            resources.ApplyResources(this.reflectiveDisturbanceUpDown, "reflectiveDisturbanceUpDown");
            this.reflectiveDisturbanceUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.reflectiveDisturbanceUpDown.DecimalPlaces = 2;
            this.reflectiveDisturbanceUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.reflectiveDisturbanceUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.reflectiveDisturbanceUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.reflectiveDisturbanceUpDown.Name = "reflectiveDisturbanceUpDown";
            this.reflectiveDisturbanceUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.reflectiveDisturbanceUpDown.ValueChanged += new System.EventHandler(this.reflectiveDisturbanceUpDown_ValueChanged);
            // 
            // tableLayoutPanel10
            // 
            resources.ApplyResources(this.tableLayoutPanel10, "tableLayoutPanel10");
            this.tableLayoutPanel10.Controls.Add(this.reflectiveTexture, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.reflectiveColor, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.reflectiveFile, 2, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            // 
            // reflectiveTexture
            // 
            resources.ApplyResources(this.reflectiveTexture, "reflectiveTexture");
            this.reflectiveTexture.Name = "reflectiveTexture";
            // 
            // reflectiveColor
            // 
            resources.ApplyResources(this.reflectiveColor, "reflectiveColor");
            this.reflectiveColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.reflectiveColor.Name = "reflectiveColor";
            this.reflectiveColor.UseVisualStyleBackColor = false;
            this.reflectiveColor.Click += new System.EventHandler(this.reflectiveColor_Click);
            // 
            // reflectiveFile
            // 
            resources.ApplyResources(this.reflectiveFile, "reflectiveFile");
            this.reflectiveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.reflectiveFile.Name = "reflectiveFile";
            this.reflectiveFile.UseVisualStyleBackColor = false;
            this.reflectiveFile.Click += new System.EventHandler(this.reflectiveFile_Click);
            // 
            // reflectiveShareUpDown
            // 
            resources.ApplyResources(this.reflectiveShareUpDown, "reflectiveShareUpDown");
            this.reflectiveShareUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.reflectiveShareUpDown.DecimalPlaces = 2;
            this.reflectiveShareUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.reflectiveShareUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.reflectiveShareUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.reflectiveShareUpDown.Name = "reflectiveShareUpDown";
            this.reflectiveShareUpDown.ValueChanged += new System.EventHandler(this.reflectiveShareUpDown_ValueChanged);
            // 
            // tableLayoutPanel8
            // 
            resources.ApplyResources(this.tableLayoutPanel8, "tableLayoutPanel8");
            this.tableLayoutPanel8.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Gainsboro;
            this.label14.Name = "label14";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Gainsboro;
            this.label12.Name = "label12";
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.ampUpDown, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.emissiveShareUpDown, 0, 1);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // ampUpDown
            // 
            resources.ApplyResources(this.ampUpDown, "ampUpDown");
            this.ampUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ampUpDown.DecimalPlaces = 2;
            this.ampUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.ampUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ampUpDown.Name = "ampUpDown";
            this.ampUpDown.ValueChanged += new System.EventHandler(this.ampUpDown_ValueChanged);
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.emissiveTexture, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.emissiveColor, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.emissiveFile, 2, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // emissiveTexture
            // 
            resources.ApplyResources(this.emissiveTexture, "emissiveTexture");
            this.emissiveTexture.Name = "emissiveTexture";
            // 
            // emissiveColor
            // 
            resources.ApplyResources(this.emissiveColor, "emissiveColor");
            this.emissiveColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.emissiveColor.Name = "emissiveColor";
            this.emissiveColor.UseVisualStyleBackColor = false;
            this.emissiveColor.Click += new System.EventHandler(this.emissiveColor_Click);
            // 
            // emissiveFile
            // 
            resources.ApplyResources(this.emissiveFile, "emissiveFile");
            this.emissiveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.emissiveFile.Name = "emissiveFile";
            this.emissiveFile.UseVisualStyleBackColor = false;
            this.emissiveFile.Click += new System.EventHandler(this.emissiveFile_Click);
            // 
            // emissiveShareUpDown
            // 
            resources.ApplyResources(this.emissiveShareUpDown, "emissiveShareUpDown");
            this.emissiveShareUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.emissiveShareUpDown.DecimalPlaces = 2;
            this.emissiveShareUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.emissiveShareUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.emissiveShareUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.emissiveShareUpDown.Name = "emissiveShareUpDown";
            this.emissiveShareUpDown.ValueChanged += new System.EventHandler(this.emissiveShareUpDown_ValueChanged);
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Name = "label4";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Name = "label9";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.diffuseShareUpDown, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.diffuseTexture, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.diffuseColor, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.diffuseFile, 2, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // diffuseTexture
            // 
            resources.ApplyResources(this.diffuseTexture, "diffuseTexture");
            this.diffuseTexture.Name = "diffuseTexture";
            // 
            // diffuseColor
            // 
            resources.ApplyResources(this.diffuseColor, "diffuseColor");
            this.diffuseColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.diffuseColor.Name = "diffuseColor";
            this.diffuseColor.UseVisualStyleBackColor = false;
            this.diffuseColor.Click += new System.EventHandler(this.diffuseColor_Click);
            // 
            // diffuseFile
            // 
            resources.ApplyResources(this.diffuseFile, "diffuseFile");
            this.diffuseFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.diffuseFile.Name = "diffuseFile";
            this.diffuseFile.UseVisualStyleBackColor = false;
            this.diffuseFile.Click += new System.EventHandler(this.diffuseFile_Click);
            // 
            // diffuseShareUpDown
            // 
            resources.ApplyResources(this.diffuseShareUpDown, "diffuseShareUpDown");
            this.diffuseShareUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.diffuseShareUpDown.DecimalPlaces = 2;
            this.diffuseShareUpDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.diffuseShareUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.diffuseShareUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.diffuseShareUpDown.Name = "diffuseShareUpDown";
            this.diffuseShareUpDown.ValueChanged += new System.EventHandler(this.diffuseShareUpDown_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Name = "label1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Name = "label2";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Name = "label7";
            // 
            // MaterialPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MaterialPanel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refractiveIndexUpDown)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refractiveShareUpDown)).EndInit();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reflectiveDisturbanceUpDown)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reflectiveShareUpDown)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ampUpDown)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emissiveShareUpDown)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diffuseShareUpDown)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.NumericUpDown refractiveIndexUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label refractiveTexture;
        private System.Windows.Forms.Button refractiveColor;
        private System.Windows.Forms.Button refractiveFile;
        private System.Windows.Forms.NumericUpDown refractiveShareUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.NumericUpDown reflectiveDisturbanceUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label reflectiveTexture;
        private System.Windows.Forms.Button reflectiveColor;
        private System.Windows.Forms.Button reflectiveFile;
        private System.Windows.Forms.NumericUpDown reflectiveShareUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label emissiveTexture;
        private System.Windows.Forms.Button emissiveColor;
        private System.Windows.Forms.Button emissiveFile;
        private System.Windows.Forms.NumericUpDown emissiveShareUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label diffuseTexture;
        private System.Windows.Forms.Button diffuseColor;
        private System.Windows.Forms.Button diffuseFile;
        private System.Windows.Forms.NumericUpDown diffuseShareUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown ampUpDown;
        private System.Windows.Forms.Label label4;
    }
}
