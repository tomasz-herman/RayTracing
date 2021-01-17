
namespace RayTracerApp.Forms
{
    partial class ObjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectForm));
            this.rightNextButton = new System.Windows.Forms.Button();
            this.middlePreviousButton = new System.Windows.Forms.Button();
            this.leftCancelButton = new System.Windows.Forms.Button();
            this.middleCancelButton = new System.Windows.Forms.Button();
            this.rightFinishButton = new System.Windows.Forms.Button();
            this.topLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rightNextButton
            // 
            resources.ApplyResources(this.rightNextButton, "rightNextButton");
            this.rightNextButton.Name = "rightNextButton";
            this.rightNextButton.TabStop = false;
            this.rightNextButton.UseVisualStyleBackColor = true;
            // 
            // middlePreviousButton
            // 
            resources.ApplyResources(this.middlePreviousButton, "middlePreviousButton");
            this.middlePreviousButton.Name = "middlePreviousButton";
            this.middlePreviousButton.TabStop = false;
            this.middlePreviousButton.UseVisualStyleBackColor = true;
            // 
            // leftCancelButton
            // 
            resources.ApplyResources(this.leftCancelButton, "leftCancelButton");
            this.leftCancelButton.Name = "leftCancelButton";
            this.leftCancelButton.TabStop = false;
            this.leftCancelButton.UseVisualStyleBackColor = true;
            // 
            // middleCancelButton
            // 
            resources.ApplyResources(this.middleCancelButton, "middleCancelButton");
            this.middleCancelButton.Name = "middleCancelButton";
            this.middleCancelButton.TabStop = false;
            this.middleCancelButton.UseVisualStyleBackColor = true;
            // 
            // rightFinishButton
            // 
            resources.ApplyResources(this.rightFinishButton, "rightFinishButton");
            this.rightFinishButton.Name = "rightFinishButton";
            this.rightFinishButton.TabStop = false;
            this.rightFinishButton.UseVisualStyleBackColor = true;
            // 
            // topLabel
            // 
            resources.ApplyResources(this.topLabel, "topLabel");
            this.topLabel.Name = "topLabel";
            // 
            // ObjectForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.middleCancelButton);
            this.Controls.Add(this.rightFinishButton);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.leftCancelButton);
            this.Controls.Add(this.middlePreviousButton);
            this.Controls.Add(this.rightNextButton);
            this.Name = "ObjectForm";
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Button middlePreviousButton;
        protected System.Windows.Forms.Button leftCancelButton;
        protected System.Windows.Forms.Button middleCancelButton;
        protected System.Windows.Forms.Button rightFinishButton;
        protected internal System.Windows.Forms.Label topLabel;
        protected System.Windows.Forms.Button rightNextButton;
    }
}