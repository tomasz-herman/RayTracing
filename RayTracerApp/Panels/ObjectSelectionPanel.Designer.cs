﻿
namespace RayTracerApp.Panels
{
    partial class ObjectSelectionPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectSelectionPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.planeRadioButton = new System.Windows.Forms.RadioButton();
            this.customModelRadioButton = new System.Windows.Forms.RadioButton();
            this.cylinderRadioButton = new System.Windows.Forms.RadioButton();
            this.cuboidRadioButton = new System.Windows.Forms.RadioButton();
            this.sphereRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.rectangleRadioButton);
            this.panel1.Controls.Add(this.planeRadioButton);
            this.panel1.Controls.Add(this.customModelRadioButton);
            this.panel1.Controls.Add(this.cylinderRadioButton);
            this.panel1.Controls.Add(this.cuboidRadioButton);
            this.panel1.Controls.Add(this.sphereRadioButton);
            this.panel1.Name = "panel1";
            // 
            // rectangleRadioButton
            // 
            resources.ApplyResources(this.rectangleRadioButton, "rectangleRadioButton");
            this.rectangleRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.rectangleRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.rectangleRadioButton.Name = "rectangleRadioButton";
            this.rectangleRadioButton.UseVisualStyleBackColor = false;
            this.rectangleRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // planeRadioButton
            // 
            resources.ApplyResources(this.planeRadioButton, "planeRadioButton");
            this.planeRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.planeRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.planeRadioButton.Name = "planeRadioButton";
            this.planeRadioButton.UseVisualStyleBackColor = false;
            this.planeRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // customModelRadioButton
            // 
            resources.ApplyResources(this.customModelRadioButton, "customModelRadioButton");
            this.customModelRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.customModelRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.customModelRadioButton.Name = "customModelRadioButton";
            this.customModelRadioButton.UseVisualStyleBackColor = false;
            this.customModelRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cylinderRadioButton
            // 
            resources.ApplyResources(this.cylinderRadioButton, "cylinderRadioButton");
            this.cylinderRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.cylinderRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.cylinderRadioButton.Name = "cylinderRadioButton";
            this.cylinderRadioButton.UseVisualStyleBackColor = false;
            this.cylinderRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cuboidRadioButton
            // 
            resources.ApplyResources(this.cuboidRadioButton, "cuboidRadioButton");
            this.cuboidRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.cuboidRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.cuboidRadioButton.Name = "cuboidRadioButton";
            this.cuboidRadioButton.UseVisualStyleBackColor = false;
            this.cuboidRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // sphereRadioButton
            // 
            resources.ApplyResources(this.sphereRadioButton, "sphereRadioButton");
            this.sphereRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.sphereRadioButton.Checked = true;
            this.sphereRadioButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.sphereRadioButton.Name = "sphereRadioButton";
            this.sphereRadioButton.TabStop = true;
            this.sphereRadioButton.UseVisualStyleBackColor = false;
            this.sphereRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // ObjectSelectionPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "ObjectSelectionPanel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rectangleRadioButton;
        private System.Windows.Forms.RadioButton planeRadioButton;
        private System.Windows.Forms.RadioButton customModelRadioButton;
        private System.Windows.Forms.RadioButton cylinderRadioButton;
        private System.Windows.Forms.RadioButton cuboidRadioButton;
        private System.Windows.Forms.RadioButton sphereRadioButton;
    }
}
