using System;
using System.Windows.Forms;
using OpenTK;

namespace RayTracerApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "RayTracing";
            this.gLControl.Location = new System.Drawing.Point(0, 20);
            this.gLControl.Name = "gLControl";
            this.gLControl.Size = new System.Drawing.Size(500, 300);
            this.gLControl.TabIndex = 0;
            this.gLControl.VSync = true;
            this.gLControl.Load += new System.EventHandler(this.GLControl_Load);
            this.Resize += this.OnResize;
            this.Controls.Add(this.gLControl);
            InitializeToolstrip();
            this.ResumeLayout(false);
        }

        private void InitializeToolstrip()
        {
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();

            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.editButton 
            });
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            this.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;

            this.editButton.Name = "editButton";
            this.editButton.Text = "Edit";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);


            this.Controls.Add(this.toolStrip);

            this.toolStrip.ResumeLayout(false);
            this.PerformLayout();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var form = new EditForm();
            form.Show();
        }
        
        private ToolStrip toolStrip;
        private ToolStripButton editButton;
        private OpenTK.GLControl gLControl = new GLControl(new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8));

        #endregion
    }
}