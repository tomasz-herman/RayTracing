
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.planeRadioButton = new System.Windows.Forms.RadioButton();
            this.customModelRadioButton = new System.Windows.Forms.RadioButton();
            this.cylinderRadioButton = new System.Windows.Forms.RadioButton();
            this.cubeRadioButton = new System.Windows.Forms.RadioButton();
            this.sphereRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rectangleRadioButton);
            this.panel1.Controls.Add(this.planeRadioButton);
            this.panel1.Controls.Add(this.customModelRadioButton);
            this.panel1.Controls.Add(this.cylinderRadioButton);
            this.panel1.Controls.Add(this.cubeRadioButton);
            this.panel1.Controls.Add(this.sphereRadioButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 415);
            this.panel1.TabIndex = 0;
            // 
            // rectangleRadioButton
            // 
            this.rectangleRadioButton.AutoSize = true;
            this.rectangleRadioButton.Location = new System.Drawing.Point(9, 116);
            this.rectangleRadioButton.Name = "rectangleRadioButton";
            this.rectangleRadioButton.Size = new System.Drawing.Size(77, 19);
            this.rectangleRadioButton.TabIndex = 5;
            this.rectangleRadioButton.Text = "Rectangle";
            this.rectangleRadioButton.UseVisualStyleBackColor = true;
            this.rectangleRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // planeRadioButton
            // 
            this.planeRadioButton.AutoSize = true;
            this.planeRadioButton.Location = new System.Drawing.Point(9, 91);
            this.planeRadioButton.Name = "planeRadioButton";
            this.planeRadioButton.Size = new System.Drawing.Size(54, 19);
            this.planeRadioButton.TabIndex = 4;
            this.planeRadioButton.Text = "Plane";
            this.planeRadioButton.UseVisualStyleBackColor = true;
            this.planeRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // customModelRadioButton
            // 
            this.customModelRadioButton.AutoSize = true;
            this.customModelRadioButton.Location = new System.Drawing.Point(9, 141);
            this.customModelRadioButton.Name = "customModelRadioButton";
            this.customModelRadioButton.Size = new System.Drawing.Size(104, 19);
            this.customModelRadioButton.TabIndex = 3;
            this.customModelRadioButton.Text = "Custom model";
            this.customModelRadioButton.UseVisualStyleBackColor = true;
            this.customModelRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cylinderRadioButton
            // 
            this.cylinderRadioButton.AutoSize = true;
            this.cylinderRadioButton.Location = new System.Drawing.Point(9, 66);
            this.cylinderRadioButton.Name = "cylinderRadioButton";
            this.cylinderRadioButton.Size = new System.Drawing.Size(69, 19);
            this.cylinderRadioButton.TabIndex = 2;
            this.cylinderRadioButton.Text = "Cylinder";
            this.cylinderRadioButton.UseVisualStyleBackColor = true;
            this.cylinderRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // cubeRadioButton
            // 
            this.cubeRadioButton.AutoSize = true;
            this.cubeRadioButton.Location = new System.Drawing.Point(9, 41);
            this.cubeRadioButton.Name = "cubeRadioButton";
            this.cubeRadioButton.Size = new System.Drawing.Size(53, 19);
            this.cubeRadioButton.TabIndex = 1;
            this.cubeRadioButton.Text = "Cube";
            this.cubeRadioButton.UseVisualStyleBackColor = true;
            this.cubeRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // sphereRadioButton
            // 
            this.sphereRadioButton.AutoSize = true;
            this.sphereRadioButton.Checked = true;
            this.sphereRadioButton.Location = new System.Drawing.Point(9, 16);
            this.sphereRadioButton.Name = "sphereRadioButton";
            this.sphereRadioButton.Size = new System.Drawing.Size(61, 19);
            this.sphereRadioButton.TabIndex = 0;
            this.sphereRadioButton.TabStop = true;
            this.sphereRadioButton.Text = "Sphere";
            this.sphereRadioButton.UseVisualStyleBackColor = true;
            this.sphereRadioButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // ObjectSelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ObjectSelectionPanel";
            this.Size = new System.Drawing.Size(350, 415);
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
        private System.Windows.Forms.RadioButton cubeRadioButton;
        private System.Windows.Forms.RadioButton sphereRadioButton;
    }
}
