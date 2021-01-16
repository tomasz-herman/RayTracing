
namespace RayTracerApp.Panels.FeaturesPanels
{
    partial class CustomModelFeature
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
            this.label1 = new System.Windows.Forms.Label();
            this.customModelButton = new System.Windows.Forms.Button();
            this.predefinedModelComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From file...";
            // 
            // customModelButton
            // 
            this.customModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customModelButton.Location = new System.Drawing.Point(182, 69);
            this.customModelButton.Name = "customModelButton";
            this.customModelButton.Size = new System.Drawing.Size(93, 23);
            this.customModelButton.TabIndex = 1;
            this.customModelButton.Text = "...";
            this.customModelButton.UseVisualStyleBackColor = true;
            this.customModelButton.Click += new System.EventHandler(this.customModelButton_Click);
            // 
            // predefinedModelComboBox
            // 
            this.predefinedModelComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.predefinedModelComboBox.FormattingEnabled = true;
            this.predefinedModelComboBox.Items.AddRange(new object[] {
            "birch tree",
            "mountain",
            "mug",
            "lamp",
            "tank",
            "teapot",
            "trex"});
            this.predefinedModelComboBox.Location = new System.Drawing.Point(182, 28);
            this.predefinedModelComboBox.Name = "predefinedModelComboBox";
            this.predefinedModelComboBox.Size = new System.Drawing.Size(93, 23);
            this.predefinedModelComboBox.TabIndex = 2;
            this.predefinedModelComboBox.SelectedIndexChanged += new System.EventHandler(this.predefinedModelComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Predefined model";
            // 
            // CustomModelFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.predefinedModelComboBox);
            this.Controls.Add(this.customModelButton);
            this.Controls.Add(this.label1);
            this.Name = "CustomModelFeature";
            this.Size = new System.Drawing.Size(300, 376);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button customModelButton;
        private System.Windows.Forms.ComboBox predefinedModelComboBox;
        private System.Windows.Forms.Label label2;
    }
}
