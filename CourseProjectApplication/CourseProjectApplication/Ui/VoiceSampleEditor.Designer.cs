namespace CourseProjectApplication.Ui
{
    partial class VoiceSampleEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PlaySampleButton = new System.Windows.Forms.Button();
            this.RecordSampleButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RecordingProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "User: ";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLabel.Location = new System.Drawing.Point(78, 13);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(42, 24);
            this.UserLabel.TabIndex = 1;
            this.UserLabel.Text = "N/A";
            // 
            // PlaySampleButton
            // 
            this.PlaySampleButton.Location = new System.Drawing.Point(17, 40);
            this.PlaySampleButton.Name = "PlaySampleButton";
            this.PlaySampleButton.Size = new System.Drawing.Size(213, 23);
            this.PlaySampleButton.TabIndex = 2;
            this.PlaySampleButton.Text = "Play voice sample";
            this.PlaySampleButton.UseVisualStyleBackColor = true;
            this.PlaySampleButton.Click += new System.EventHandler(this.PlaySample_Click);
            // 
            // RecordSampleButton
            // 
            this.RecordSampleButton.Location = new System.Drawing.Point(236, 40);
            this.RecordSampleButton.Name = "RecordSampleButton";
            this.RecordSampleButton.Size = new System.Drawing.Size(213, 23);
            this.RecordSampleButton.TabIndex = 3;
            this.RecordSampleButton.Text = "Record voice sample";
            this.RecordSampleButton.UseVisualStyleBackColor = true;
            this.RecordSampleButton.Click += new System.EventHandler(this.SetSample_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(382, 283);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RecordingProgressBar
            // 
            this.RecordingProgressBar.Location = new System.Drawing.Point(20, 254);
            this.RecordingProgressBar.Name = "RecordingProgressBar";
            this.RecordingProgressBar.Size = new System.Drawing.Size(437, 23);
            this.RecordingProgressBar.TabIndex = 5;
            // 
            // VoiceSampleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 318);
            this.Controls.Add(this.RecordingProgressBar);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RecordSampleButton);
            this.Controls.Add(this.PlaySampleButton);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.label1);
            this.Name = "VoiceSampleEditor";
            this.Text = "VoiceSampleEditor";
            this.Load += new System.EventHandler(this.VoiceSampleEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Button PlaySampleButton;
        private System.Windows.Forms.Button RecordSampleButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ProgressBar RecordingProgressBar;
    }
}