
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomModelFeature));
            this.label1 = new System.Windows.Forms.Label();
            this.customModelButton = new System.Windows.Forms.Button();
            this.predefinedModelComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // customModelButton
            // 
            resources.ApplyResources(this.customModelButton, "customModelButton");
            this.customModelButton.Name = "customModelButton";
            this.customModelButton.UseVisualStyleBackColor = true;
            this.customModelButton.Click += new System.EventHandler(this.customModelButton_Click);
            // 
            // predefinedModelComboBox
            // 
            resources.ApplyResources(this.predefinedModelComboBox, "predefinedModelComboBox");
            this.predefinedModelComboBox.FormattingEnabled = true;
            this.predefinedModelComboBox.Items.AddRange(new object[] {
            resources.GetString("predefinedModelComboBox.Items"),
            resources.GetString("predefinedModelComboBox.Items1"),
            resources.GetString("predefinedModelComboBox.Items2"),
            resources.GetString("predefinedModelComboBox.Items3"),
            resources.GetString("predefinedModelComboBox.Items4"),
            resources.GetString("predefinedModelComboBox.Items5"),
            resources.GetString("predefinedModelComboBox.Items6"),
            resources.GetString("predefinedModelComboBox.Items7")});
            this.predefinedModelComboBox.Name = "predefinedModelComboBox";
            this.predefinedModelComboBox.SelectedIndexChanged += new System.EventHandler(this.predefinedModelComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CustomModelFeature
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.predefinedModelComboBox);
            this.Controls.Add(this.customModelButton);
            this.Controls.Add(this.label1);
            this.Name = "CustomModelFeature";
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
