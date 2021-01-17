
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.gammaCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.samplesUpDown = new System.Windows.Forms.NumericUpDown();
            this.updateUpDown = new System.Windows.Forms.NumericUpDown();
            this.bloomUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.recursionCheckbox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.recLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.automaticCheckBox = new System.Windows.Forms.CheckBox();
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
            this.label17 = new System.Windows.Forms.Label();
            this.lensRadiusUpDown = new System.Windows.Forms.NumericUpDown();
            this.focusDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.autoFocusCheckBox = new System.Windows.Forms.CheckBox();
            this.fovUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.finishButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloomUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recLevelUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.lensCameraLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lensRadiusUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focusDistanceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.gammaCheckBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.samplesUpDown, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.updateUpDown, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.bloomUpDown, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.recursionCheckbox, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.label16, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label18, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.recLevelUpDown, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.automaticCheckBox, 1, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_CellPaint);
            // 
            // gammaCheckBox
            // 
            resources.ApplyResources(this.gammaCheckBox, "gammaCheckBox");
            this.gammaCheckBox.Name = "gammaCheckBox";
            this.gammaCheckBox.UseVisualStyleBackColor = true;
            this.gammaCheckBox.CheckedChanged += new System.EventHandler(this.gammaCheckBox_CheckedChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // samplesUpDown
            // 
            resources.ApplyResources(this.samplesUpDown, "samplesUpDown");
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
            this.samplesUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.samplesUpDown.ValueChanged += new System.EventHandler(this.samplesUpDown_ValueChanged);
            // 
            // updateUpDown
            // 
            resources.ApplyResources(this.updateUpDown, "updateUpDown");
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
            this.updateUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.updateUpDown.ValueChanged += new System.EventHandler(this.updateUpDown_ValueChanged);
            // 
            // bloomUpDown
            // 
            resources.ApplyResources(this.bloomUpDown, "bloomUpDown");
            this.bloomUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.bloomUpDown.Name = "bloomUpDown";
            this.bloomUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.bloomUpDown.ValueChanged += new System.EventHandler(this.bloomUpDown_ValueChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // recursionCheckbox
            // 
            resources.ApplyResources(this.recursionCheckbox, "recursionCheckbox");
            this.recursionCheckbox.Name = "recursionCheckbox";
            this.recursionCheckbox.UseVisualStyleBackColor = true;
            this.recursionCheckbox.CheckedChanged += new System.EventHandler(this.recursionCheckbox_CheckedChanged);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // recLevelUpDown
            // 
            resources.ApplyResources(this.recLevelUpDown, "recLevelUpDown");
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
            this.recLevelUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.recLevelUpDown.ValueChanged += new System.EventHandler(this.recLevelUpDown_ValueChanged);
            // 
            // automaticCheckBox
            // 
            resources.ApplyResources(this.automaticCheckBox, "automaticCheckBox");
            this.automaticCheckBox.Name = "automaticCheckBox";
            this.automaticCheckBox.UseVisualStyleBackColor = true;
            this.automaticCheckBox.CheckedChanged += new System.EventHandler(this.automaticCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.fovUpDown, 1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_CellPaint);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.randomRadioButton);
            this.panel2.Controls.Add(this.centerRadioButton);
            this.panel2.Controls.Add(this.jitteredRadioButton);
            this.panel2.Name = "panel2";
            // 
            // randomRadioButton
            // 
            resources.ApplyResources(this.randomRadioButton, "randomRadioButton");
            this.randomRadioButton.Name = "randomRadioButton";
            this.randomRadioButton.UseVisualStyleBackColor = true;
            this.randomRadioButton.CheckedChanged += new System.EventHandler(this.randomRadioButton_CheckedChanged);
            // 
            // centerRadioButton
            // 
            resources.ApplyResources(this.centerRadioButton, "centerRadioButton");
            this.centerRadioButton.Name = "centerRadioButton";
            this.centerRadioButton.UseVisualStyleBackColor = true;
            this.centerRadioButton.CheckedChanged += new System.EventHandler(this.centerRadioButton_CheckedChanged);
            // 
            // jitteredRadioButton
            // 
            resources.ApplyResources(this.jitteredRadioButton, "jitteredRadioButton");
            this.jitteredRadioButton.Checked = true;
            this.jitteredRadioButton.Name = "jitteredRadioButton";
            this.jitteredRadioButton.TabStop = true;
            this.jitteredRadioButton.UseVisualStyleBackColor = true;
            this.jitteredRadioButton.CheckedChanged += new System.EventHandler(this.jitteredRadioButton_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lensCameraLayoutPanel, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.ortographicCameraRadioButton);
            this.panel1.Controls.Add(this.lensCameraRadioButton);
            this.panel1.Controls.Add(this.perspectiveCameraRadioButton);
            this.panel1.Name = "panel1";
            // 
            // ortographicCameraRadioButton
            // 
            resources.ApplyResources(this.ortographicCameraRadioButton, "ortographicCameraRadioButton");
            this.ortographicCameraRadioButton.Name = "ortographicCameraRadioButton";
            this.ortographicCameraRadioButton.UseVisualStyleBackColor = true;
            this.ortographicCameraRadioButton.CheckedChanged += new System.EventHandler(this.ortographicCameraRadioButton_CheckedChanged);
            // 
            // lensCameraRadioButton
            // 
            resources.ApplyResources(this.lensCameraRadioButton, "lensCameraRadioButton");
            this.lensCameraRadioButton.Name = "lensCameraRadioButton";
            this.lensCameraRadioButton.UseVisualStyleBackColor = true;
            this.lensCameraRadioButton.CheckedChanged += new System.EventHandler(this.lensCameraRadioButton_CheckedChanged);
            // 
            // perspectiveCameraRadioButton
            // 
            resources.ApplyResources(this.perspectiveCameraRadioButton, "perspectiveCameraRadioButton");
            this.perspectiveCameraRadioButton.Name = "perspectiveCameraRadioButton";
            this.perspectiveCameraRadioButton.UseVisualStyleBackColor = true;
            this.perspectiveCameraRadioButton.CheckedChanged += new System.EventHandler(this.perspectiveCameraRadioButton_CheckedChanged);
            // 
            // lensCameraLayoutPanel
            // 
            resources.ApplyResources(this.lensCameraLayoutPanel, "lensCameraLayoutPanel");
            this.lensCameraLayoutPanel.Controls.Add(this.label17, 0, 2);
            this.lensCameraLayoutPanel.Controls.Add(this.lensRadiusUpDown, 1, 0);
            this.lensCameraLayoutPanel.Controls.Add(this.focusDistanceUpDown, 1, 1);
            this.lensCameraLayoutPanel.Controls.Add(this.label14, 0, 0);
            this.lensCameraLayoutPanel.Controls.Add(this.label15, 0, 1);
            this.lensCameraLayoutPanel.Controls.Add(this.autoFocusCheckBox, 1, 2);
            this.lensCameraLayoutPanel.Name = "lensCameraLayoutPanel";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // lensRadiusUpDown
            // 
            resources.ApplyResources(this.lensRadiusUpDown, "lensRadiusUpDown");
            this.lensRadiusUpDown.DecimalPlaces = 2;
            this.lensRadiusUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lensRadiusUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.lensRadiusUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lensRadiusUpDown.Name = "lensRadiusUpDown";
            this.lensRadiusUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.lensRadiusUpDown.ValueChanged += new System.EventHandler(this.lensRadiusUpDown_ValueChanged);
            // 
            // focusDistanceUpDown
            // 
            resources.ApplyResources(this.focusDistanceUpDown, "focusDistanceUpDown");
            this.focusDistanceUpDown.DecimalPlaces = 2;
            this.focusDistanceUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.focusDistanceUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.focusDistanceUpDown.Name = "focusDistanceUpDown";
            this.focusDistanceUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.focusDistanceUpDown.ValueChanged += new System.EventHandler(this.focusDistanceUpDown_ValueChanged);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // autoFocusCheckBox
            // 
            resources.ApplyResources(this.autoFocusCheckBox, "autoFocusCheckBox");
            this.autoFocusCheckBox.Name = "autoFocusCheckBox";
            this.autoFocusCheckBox.UseVisualStyleBackColor = true;
            this.autoFocusCheckBox.CheckedChanged += new System.EventHandler(this.autoFocusCheckBox_CheckedChanged);
            // 
            // fovUpDown
            // 
            resources.ApplyResources(this.fovUpDown, "fovUpDown");
            this.fovUpDown.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.fovUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fovUpDown.Name = "fovUpDown";
            this.fovUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.fovUpDown.ValueChanged += new System.EventHandler(this.fovUpDown_ValueChanged);
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
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            // 
            // finishButton
            // 
            resources.ApplyResources(this.finishButton, "finishButton");
            this.finishButton.Name = "finishButton";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloomUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recLevelUpDown)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel lensCameraLayoutPanel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown lensRadiusUpDown;
        private System.Windows.Forms.NumericUpDown focusDistanceUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown recLevelUpDown;
        private System.Windows.Forms.NumericUpDown recursionLevelUpDown;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox autoFocusCheckBox;
        private System.Windows.Forms.CheckBox gammaCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox automaticCheckBox;
    }
}