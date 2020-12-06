using System.ComponentModel;

namespace RayTracerApp.Controls
{
    partial class MaterialPanel
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
            this.separator1 = new System.Windows.Forms.Label();
            this.textureLabel = new System.Windows.Forms.Label();
            this.textureEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.pathToTextureLabel = new System.Windows.Forms.Label();
            this.chooseTextureButton = new System.Windows.Forms.Button();
            this.ambientLabel = new System.Windows.Forms.Label();
            this.ambientButton = new System.Windows.Forms.Button();
            this.diffuseButton = new System.Windows.Forms.Button();
            this.diffuseLabel = new System.Windows.Forms.Label();
            this.specularButton = new System.Windows.Forms.Button();
            this.specularLabel = new System.Windows.Forms.Label();
            this.specularExpTrackBar = new System.Windows.Forms.TrackBar();
            this.specularExpLabel = new System.Windows.Forms.Label();
            this.separator2 = new System.Windows.Forms.Label();
            this.emissiveLabel = new System.Windows.Forms.Label();
            this.reflectiveLabel = new System.Windows.Forms.Label();
            this.refractiveLabel = new System.Windows.Forms.Label();
            this.refractiveIndexLabel = new System.Windows.Forms.Label();
            this.emissiveButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.specularExpTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // separator1
            // 
            this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator1.Location = new System.Drawing.Point(0, 58);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(295, 2);
            this.separator1.TabIndex = 0;
            // 
            // textureLabel
            // 
            this.textureLabel.AutoSize = true;
            this.textureLabel.Location = new System.Drawing.Point(0, 9);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(48, 15);
            this.textureLabel.TabIndex = 1;
            this.textureLabel.Text = "Texture:";
            // 
            // textureEnableCheckBox
            // 
            this.textureEnableCheckBox.AutoSize = true;
            this.textureEnableCheckBox.Location = new System.Drawing.Point(9, 36);
            this.textureEnableCheckBox.Name = "textureEnableCheckBox";
            this.textureEnableCheckBox.Size = new System.Drawing.Size(61, 19);
            this.textureEnableCheckBox.TabIndex = 2;
            this.textureEnableCheckBox.Text = "Enable";
            this.textureEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // pathToTextureLabel
            // 
            this.pathToTextureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pathToTextureLabel.AutoSize = true;
            this.pathToTextureLabel.Location = new System.Drawing.Point(155, 37);
            this.pathToTextureLabel.Name = "pathToTextureLabel";
            this.pathToTextureLabel.Size = new System.Drawing.Size(89, 15);
            this.pathToTextureLabel.TabIndex = 3;
            this.pathToTextureLabel.Text = "path/to/texture";
            // 
            // chooseTextureButton
            // 
            this.chooseTextureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseTextureButton.Location = new System.Drawing.Point(250, 33);
            this.chooseTextureButton.Name = "chooseTextureButton";
            this.chooseTextureButton.Size = new System.Drawing.Size(29, 23);
            this.chooseTextureButton.TabIndex = 4;
            this.chooseTextureButton.Text = "...";
            this.chooseTextureButton.UseVisualStyleBackColor = true;
            // 
            // ambientLabel
            // 
            this.ambientLabel.AutoSize = true;
            this.ambientLabel.Location = new System.Drawing.Point(9, 71);
            this.ambientLabel.Name = "ambientLabel";
            this.ambientLabel.Size = new System.Drawing.Size(56, 15);
            this.ambientLabel.TabIndex = 5;
            this.ambientLabel.Text = "Ambient:";
            // 
            // ambientButton
            // 
            this.ambientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ambientButton.Location = new System.Drawing.Point(155, 67);
            this.ambientButton.Name = "ambientButton";
            this.ambientButton.Size = new System.Drawing.Size(124, 23);
            this.ambientButton.TabIndex = 6;
            this.ambientButton.Text = "button1";
            this.ambientButton.UseVisualStyleBackColor = true;
            // 
            // diffuseButton
            // 
            this.diffuseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.diffuseButton.Location = new System.Drawing.Point(155, 94);
            this.diffuseButton.Name = "diffuseButton";
            this.diffuseButton.Size = new System.Drawing.Size(124, 23);
            this.diffuseButton.TabIndex = 8;
            this.diffuseButton.Text = "button1";
            this.diffuseButton.UseVisualStyleBackColor = true;
            // 
            // diffuseLabel
            // 
            this.diffuseLabel.AutoSize = true;
            this.diffuseLabel.Location = new System.Drawing.Point(9, 98);
            this.diffuseLabel.Name = "diffuseLabel";
            this.diffuseLabel.Size = new System.Drawing.Size(47, 15);
            this.diffuseLabel.TabIndex = 7;
            this.diffuseLabel.Text = "Diffuse:";
            // 
            // specularButton
            // 
            this.specularButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.specularButton.Location = new System.Drawing.Point(155, 123);
            this.specularButton.Name = "specularButton";
            this.specularButton.Size = new System.Drawing.Size(124, 23);
            this.specularButton.TabIndex = 10;
            this.specularButton.Text = "button1";
            this.specularButton.UseVisualStyleBackColor = true;
            // 
            // specularLabel
            // 
            this.specularLabel.AutoSize = true;
            this.specularLabel.Location = new System.Drawing.Point(9, 127);
            this.specularLabel.Name = "specularLabel";
            this.specularLabel.Size = new System.Drawing.Size(55, 15);
            this.specularLabel.TabIndex = 9;
            this.specularLabel.Text = "Specular:";
            // 
            // specularExpTrackBar
            // 
            this.specularExpTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.specularExpTrackBar.Location = new System.Drawing.Point(155, 152);
            this.specularExpTrackBar.Name = "specularExpTrackBar";
            this.specularExpTrackBar.Size = new System.Drawing.Size(124, 45);
            this.specularExpTrackBar.TabIndex = 11;
            // 
            // specularExpLabel
            // 
            this.specularExpLabel.AutoSize = true;
            this.specularExpLabel.Location = new System.Drawing.Point(10, 152);
            this.specularExpLabel.Name = "specularExpLabel";
            this.specularExpLabel.Size = new System.Drawing.Size(108, 15);
            this.specularExpLabel.TabIndex = 12;
            this.specularExpLabel.Text = "Specular exponent:";
            // 
            // separator2
            // 
            this.separator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator2.Location = new System.Drawing.Point(0, 191);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(295, 2);
            this.separator2.TabIndex = 13;
            // 
            // emissiveLabel
            // 
            this.emissiveLabel.AutoSize = true;
            this.emissiveLabel.Location = new System.Drawing.Point(10, 211);
            this.emissiveLabel.Name = "emissiveLabel";
            this.emissiveLabel.Size = new System.Drawing.Size(55, 15);
            this.emissiveLabel.TabIndex = 14;
            this.emissiveLabel.Text = "Emissive:";
            // 
            // reflectiveLabel
            // 
            this.reflectiveLabel.AutoSize = true;
            this.reflectiveLabel.Location = new System.Drawing.Point(9, 239);
            this.reflectiveLabel.Name = "reflectiveLabel";
            this.reflectiveLabel.Size = new System.Drawing.Size(61, 15);
            this.reflectiveLabel.TabIndex = 15;
            this.reflectiveLabel.Text = "Reflective:";
            // 
            // refractiveLabel
            // 
            this.refractiveLabel.AutoSize = true;
            this.refractiveLabel.Location = new System.Drawing.Point(8, 269);
            this.refractiveLabel.Name = "refractiveLabel";
            this.refractiveLabel.Size = new System.Drawing.Size(62, 15);
            this.refractiveLabel.TabIndex = 16;
            this.refractiveLabel.Text = "Refractive:";
            // 
            // refractiveIndexLabel
            // 
            this.refractiveIndexLabel.AutoSize = true;
            this.refractiveIndexLabel.Location = new System.Drawing.Point(10, 303);
            this.refractiveIndexLabel.Name = "refractiveIndexLabel";
            this.refractiveIndexLabel.Size = new System.Drawing.Size(94, 15);
            this.refractiveIndexLabel.TabIndex = 17;
            this.refractiveIndexLabel.Text = "Refractive index:";
            // 
            // emissiveButton
            // 
            this.emissiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emissiveButton.Location = new System.Drawing.Point(155, 211);
            this.emissiveButton.Name = "emissiveButton";
            this.emissiveButton.Size = new System.Drawing.Size(124, 23);
            this.emissiveButton.TabIndex = 18;
            this.emissiveButton.Text = "button1";
            this.emissiveButton.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(155, 239);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(124, 45);
            this.trackBar1.TabIndex = 19;
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.Location = new System.Drawing.Point(155, 269);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(124, 45);
            this.trackBar2.TabIndex = 20;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(206, 301);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(73, 23);
            this.numericUpDown1.TabIndex = 21;
            // 
            // MaterialPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.emissiveButton);
            this.Controls.Add(this.refractiveIndexLabel);
            this.Controls.Add(this.refractiveLabel);
            this.Controls.Add(this.reflectiveLabel);
            this.Controls.Add(this.emissiveLabel);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.specularExpLabel);
            this.Controls.Add(this.specularExpTrackBar);
            this.Controls.Add(this.specularButton);
            this.Controls.Add(this.specularLabel);
            this.Controls.Add(this.diffuseButton);
            this.Controls.Add(this.diffuseLabel);
            this.Controls.Add(this.ambientButton);
            this.Controls.Add(this.ambientLabel);
            this.Controls.Add(this.chooseTextureButton);
            this.Controls.Add(this.pathToTextureLabel);
            this.Controls.Add(this.textureEnableCheckBox);
            this.Controls.Add(this.textureLabel);
            this.Controls.Add(this.separator1);
            this.Name = "MaterialPanel";
            this.Size = new System.Drawing.Size(294, 385);
            ((System.ComponentModel.ISupportInitialize)(this.specularExpTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label separator1;
        private System.Windows.Forms.Label textureLabel;
        private System.Windows.Forms.CheckBox textureEnableCheckBox;
        private System.Windows.Forms.Label pathToTextureLabel;
        private System.Windows.Forms.Button chooseTextureButton;
        private System.Windows.Forms.Label ambientLabel;
        private System.Windows.Forms.Button ambientButton;
        private System.Windows.Forms.Button diffuseButton;
        private System.Windows.Forms.Label diffuseLabel;
        private System.Windows.Forms.Button specularButton;
        private System.Windows.Forms.Label specularLabel;
        private System.Windows.Forms.TrackBar specularExpTrackBar;
        private System.Windows.Forms.Label specularExpLabel;
        private System.Windows.Forms.Label separator2;
        private System.Windows.Forms.Label emissiveLabel;
        private System.Windows.Forms.Label reflectiveLabel;
        private System.Windows.Forms.Label refractiveLabel;
        private System.Windows.Forms.Label refractiveIndexLabel;
        private System.Windows.Forms.Button emissiveButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}