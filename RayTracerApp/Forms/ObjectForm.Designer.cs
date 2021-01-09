
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
            this.rightNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rightNextButton.Location = new System.Drawing.Point(397, 626);
            this.rightNextButton.Name = "rightNextButton";
            this.rightNextButton.Size = new System.Drawing.Size(75, 23);
            this.rightNextButton.TabIndex = 0;
            this.rightNextButton.TabStop = false;
            this.rightNextButton.Text = "Next";
            this.rightNextButton.UseVisualStyleBackColor = true;
            // 
            // middlePreviousButton
            // 
            this.middlePreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.middlePreviousButton.Location = new System.Drawing.Point(316, 626);
            this.middlePreviousButton.Name = "middlePreviousButton";
            this.middlePreviousButton.Size = new System.Drawing.Size(75, 23);
            this.middlePreviousButton.TabIndex = 1;
            this.middlePreviousButton.TabStop = false;
            this.middlePreviousButton.Text = "Previous";
            this.middlePreviousButton.UseVisualStyleBackColor = true;
            this.middlePreviousButton.Visible = false;
            // 
            // leftCancelButton
            // 
            this.leftCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.leftCancelButton.Location = new System.Drawing.Point(235, 626);
            this.leftCancelButton.Name = "leftCancelButton";
            this.leftCancelButton.Size = new System.Drawing.Size(75, 23);
            this.leftCancelButton.TabIndex = 2;
            this.leftCancelButton.TabStop = false;
            this.leftCancelButton.Text = "Cancel";
            this.leftCancelButton.UseVisualStyleBackColor = true;
            this.leftCancelButton.Visible = false;
            // 
            // middleCancelButton
            // 
            this.middleCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.middleCancelButton.Location = new System.Drawing.Point(316, 626);
            this.middleCancelButton.Name = "middleCancelButton";
            this.middleCancelButton.Size = new System.Drawing.Size(75, 23);
            this.middleCancelButton.TabIndex = 3;
            this.middleCancelButton.TabStop = false;
            this.middleCancelButton.Text = "Cancel";
            this.middleCancelButton.UseVisualStyleBackColor = true;
            // 
            // rightFinishButton
            // 
            this.rightFinishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rightFinishButton.Location = new System.Drawing.Point(397, 626);
            this.rightFinishButton.Name = "rightFinishButton";
            this.rightFinishButton.Size = new System.Drawing.Size(75, 23);
            this.rightFinishButton.TabIndex = 4;
            this.rightFinishButton.TabStop = false;
            this.rightFinishButton.Text = "Finish";
            this.rightFinishButton.UseVisualStyleBackColor = true;
            this.rightFinishButton.Visible = false;
            // 
            // topLabel
            // 
            this.topLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLabel.Location = new System.Drawing.Point(0, 0);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(484, 23);
            this.topLabel.TabIndex = 5;
            this.topLabel.Text = "Add new object...";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.middleCancelButton);
            this.Controls.Add(this.rightFinishButton);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.leftCancelButton);
            this.Controls.Add(this.middlePreviousButton);
            this.Controls.Add(this.rightNextButton);
            this.Name = "ObjectForm";
            this.Text = "ObjectForm";
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