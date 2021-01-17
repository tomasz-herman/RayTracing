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
            this.Text = Properties.Strings.RayTracing;
            InitializeProgressBar();
            this.gLControl.Location = new System.Drawing.Point(0, 20);
            this.gLControl.Name = "gLControl";
            this.gLControl.Size = new System.Drawing.Size(500, 300);
            this.gLControl.TabIndex = 0;
            this.gLControl.VSync = true;
            this.gLControl.Load += new System.EventHandler(this.GLControl_Load);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormClosed += MainForm_FormClosed;

            this.Resize += this.OnResize;
            this.Controls.Add(this.gLControl);

            InitializeToolstrip();
            InitializeNewEditDeleteMenu();
            InitializeNewEditMenu();
            this.ResumeLayout(false);
        }

        private void InitializeProgressBar()
        {
            this.progressBar = new ProgressBar();
            this.progressBar.Anchor = AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            this.progressBar.Width = Width/2;
            this.progressBar.Height = 20;
            this.progressBar.Location = new System.Drawing.Point((Width-progressBar.Width)/2, (int)(Height - progressBar.Height*3.5f));
            this.progressBar.Maximum = 100;
            this.progressBar.Step = 1;
            this.progressBar.Value = 0;
            this.progressBar.Visible = false;
            this.Controls.Add(this.progressBar);
        }

        private void InitializeNewEditDeleteMenu()
        {
            int width = 150;
            this.addItem1 = new ToolStripMenuItem();
            this.addItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addItem1.Text = Properties.Strings.AddObject;
            this.addItem1.Name = "AddObject1";
            this.addItem1.Size = new System.Drawing.Size(width, 22);
            this.addItem1.Click += AddItem_Click;

            this.editItem1 = new ToolStripMenuItem();
            this.editItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editItem1.Text = Properties.Strings.EditObject;
            this.editItem1.Name = "EditObject1";
            this.editItem1.Size = new System.Drawing.Size(width, 22);
            this.editItem1.Click += EditItem_Click;

            this.deleteItem1 = new ToolStripMenuItem();
            this.deleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteItem1.Text = Properties.Strings.DeleteObject;
            this.deleteItem1.Name = "DeleteObject1";
            this.deleteItem1.Size = new System.Drawing.Size(width, 22);
            this.deleteItem1.Click += DeleteItem_Click;

            this.newDeleteStrip = new ContextMenuStrip(components);
            this.newDeleteStrip.SuspendLayout();
            this.newDeleteStrip.AutoSize = false;
            this.newDeleteStrip.Name = "newDeleteMenu";
            this.newDeleteStrip.TabIndex = 2;
            this.newDeleteStrip.Text = "newDeleteMenu";
            this.newDeleteStrip.Items.Add(addItem1);
            this.newDeleteStrip.Items.Add(editItem1);
            this.newDeleteStrip.Items.Add(deleteItem1);

            this.newDeleteStrip.Size = new System.Drawing.Size(width+1, 70);

            this.newDeleteStrip.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeNewEditMenu()
        {
            int width = 150;
            this.addItem2 = new ToolStripMenuItem();
            this.addItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addItem2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addItem2.Text = Properties.Strings.AddObject;
            this.addItem2.Name = "AddObject2";
            this.addItem2.Size = new System.Drawing.Size(width, 22);
            this.addItem2.Click += AddItem_Click;

            this.editItem2 = new ToolStripMenuItem();
            this.editItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editItem2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editItem2.Text = Properties.Strings.EditObject;
            this.editItem2.Name = "EditObject2";
            this.editItem2.Size = new System.Drawing.Size(width, 22);
            this.editItem2.Click += EditItem_Click;

            this.newEditStrip = new ContextMenuStrip(components);
            this.newEditStrip.SuspendLayout();
            this.newEditStrip.AutoSize = false;
            this.newEditStrip.Name = "newEditMenu";
            this.newEditStrip.TabIndex = 3;
            this.newEditStrip.Text = "newEditMenu";
            this.newEditStrip.Items.Add(addItem2);
            this.newEditStrip.Items.Add(editItem2);

            this.newEditStrip.Size = new System.Drawing.Size(width+1, 48);

            this.newEditStrip.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitializeToolstrip()
        {
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.newObjectButton = new System.Windows.Forms.ToolStripButton();
            this.editObjectButton = new System.Windows.Forms.ToolStripButton();
            this.deleteObjectButton = new System.Windows.Forms.ToolStripButton();
            this.saveImageToFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveSceneButton = new System.Windows.Forms.ToolStripButton();
            this.loadSceneButton = new System.Windows.Forms.ToolStripButton();
            this.clearSceneButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();

            this.ddButton = new ToolStripDropDownButton();
            this.ddButton.Text = Properties.Strings.EditScene;
            
            this.sceneDdButton = new ToolStripDropDownButton();
            this.sceneDdButton.Text = "Scene";

            this.ddButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newObjectButton,
                this.editObjectButton,
                this.deleteObjectButton
            });
            
            this.sceneDdButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.loadSceneButton,
                this.saveSceneButton,
                this.clearSceneButton
            });

            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.ddButton,
                this.settingsButton,
                this.saveImageToFileButton,
                this.sceneDdButton
            });

            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";

            this.saveImageToFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveImageToFileButton.Name = "saveImageToFile";
            this.saveImageToFileButton.Text = Properties.Strings.SaveImage;
            this.saveImageToFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveImageToFileButton.Click += new System.EventHandler(this.SaveImage_Click);

            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Text = Properties.Strings.Settings;
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);

            this.newObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newObjectButton.Name = "newObjectButton";
            this.newObjectButton.Text = Properties.Strings.AddObject;
            this.newObjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newObjectButton.Click += new System.EventHandler(this.newObjectButton_Click);

            this.editObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editObjectButton.Name = "editObjectButton";
            this.editObjectButton.Text = Properties.Strings.EditObject;
            this.editObjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editObjectButton.Click += new System.EventHandler(this.editObjectButton_Click);

            this.deleteObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteObjectButton.Name = "deleteObjectButton";
            this.deleteObjectButton.Text = Properties.Strings.DeleteObject;
            this.deleteObjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteObjectButton.Click += new System.EventHandler(this.deleteObjectButton_Click);
            
            this.saveSceneButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveSceneButton.Name = "saveSceneButton";
            this.saveSceneButton.Text = "Save scene";
            this.saveSceneButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveSceneButton.Click += new System.EventHandler(this.saveSceneButton_Click);

            this.loadSceneButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadSceneButton.Name = "loadSceneButton";
            this.loadSceneButton.Text = "Load scene";
            this.loadSceneButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadSceneButton.Click += new System.EventHandler(this.loadSceneButton_Click);
            
            this.clearSceneButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearSceneButton.Name = "clearSceneButton";
            this.clearSceneButton.Text = "Clear scene";
            this.clearSceneButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clearSceneButton.Click += new System.EventHandler(this.clearSceneButton_Click);

            this.Controls.Add(this.toolStrip);

            this.toolStrip.ResumeLayout(false);
            this.PerformLayout();
        }

        private ToolStrip toolStrip;
        private ToolStripButton settingsButton;
        private ToolStripButton newObjectButton;
        private ToolStripButton editObjectButton;
        private ToolStripButton deleteObjectButton;
        private ToolStripButton saveImageToFileButton;
        private ToolStripButton saveSceneButton;
        private ToolStripButton loadSceneButton;
        private ToolStripButton clearSceneButton;
        private OpenTK.GLControl gLControl = new GLControl(new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8));
        private ToolStripDropDownButton ddButton;
        private ToolStripDropDownButton sceneDdButton;
        private ContextMenuStrip newDeleteStrip;
        private ToolStripMenuItem addItem1;
        private ToolStripMenuItem editItem1;
        private ToolStripMenuItem deleteItem1;
        private ToolStripMenuItem addItem2;
        private ToolStripMenuItem editItem2;
        private ContextMenuStrip newEditStrip;
        private ProgressBar progressBar;

        #endregion
    }
}