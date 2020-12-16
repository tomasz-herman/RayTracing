using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RayTracerApp.Controls
{
    partial class NewModelPanel
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
            this.NewModelBox = new System.Windows.Forms.GroupBox();
            this.ModelButton = new System.Windows.Forms.RadioButton();
            this.SphereButton = new System.Windows.Forms.RadioButton();
            this.CubeButton = new System.Windows.Forms.RadioButton();
            this.NewModelBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewModelBox
            // 
            this.NewModelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewModelBox.Controls.Add(this.ModelButton);
            this.NewModelBox.Controls.Add(this.SphereButton);
            this.NewModelBox.Controls.Add(this.CubeButton);
            this.NewModelBox.Location = new System.Drawing.Point(0, 0);
            this.NewModelBox.Name = "NewModelBox";
            this.NewModelBox.Size = new System.Drawing.Size(233, 152);
            this.NewModelBox.TabIndex = 0;
            this.NewModelBox.TabStop = false;
            // 
            // ModelButton
            // 
            this.ModelButton.AutoSize = true;
            this.ModelButton.Location = new System.Drawing.Point(6, 69);
            this.ModelButton.Name = "ModelButton";
            this.ModelButton.Size = new System.Drawing.Size(104, 19);
            this.ModelButton.TabIndex = 2;
            this.ModelButton.TabStop = true;
            this.ModelButton.Text = "Custom model";
            this.ModelButton.UseVisualStyleBackColor = true;
            this.ModelButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // SphereButton
            // 
            this.SphereButton.AutoSize = true;
            this.SphereButton.Location = new System.Drawing.Point(6, 44);
            this.SphereButton.Name = "SphereButton";
            this.SphereButton.Size = new System.Drawing.Size(61, 19);
            this.SphereButton.TabIndex = 1;
            this.SphereButton.TabStop = true;
            this.SphereButton.Text = "Sphere";
            this.SphereButton.UseVisualStyleBackColor = true;
            this.SphereButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // CubeButton
            // 
            this.CubeButton.AutoSize = true;
            this.CubeButton.Location = new System.Drawing.Point(6, 19);
            this.CubeButton.Name = "CubeButton";
            this.CubeButton.Size = new System.Drawing.Size(53, 19);
            this.CubeButton.TabIndex = 0;
            this.CubeButton.TabStop = true;
            this.CubeButton.Text = "Cube";
            this.CubeButton.UseVisualStyleBackColor = true;
            this.CubeButton.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // NewModelPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NewModelBox);
            this.Name = "NewModelPanel";
            this.Size = new System.Drawing.Size(233, 152);
            this.NewModelBox.ResumeLayout(false);
            this.NewModelBox.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private GroupBox NewModelBox;
        private RadioButton ModelButton;
        private RadioButton SphereButton;
        private RadioButton CubeButton;
    }
}