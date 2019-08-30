namespace CourseProjectApplication.Ui
{
    partial class EditAccessRule
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
            this.SecLevelBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AccessibleLocationsList = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.AvailibleLocationBox = new System.Windows.Forms.ComboBox();
            this.RemoveAccessibleLocationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SecLevelBox
            // 
            this.SecLevelBox.FormattingEnabled = true;
            this.SecLevelBox.Location = new System.Drawing.Point(12, 30);
            this.SecLevelBox.Name = "SecLevelBox";
            this.SecLevelBox.Size = new System.Drawing.Size(190, 21);
            this.SecLevelBox.TabIndex = 0;
            this.SecLevelBox.SelectedIndexChanged += new System.EventHandler(this.SecLevelBox_SelectedIndexChanged);
            this.SecLevelBox.TextChanged += new System.EventHandler(this.SecLevelBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SecLevel:";
            // 
            // AccessibleLocationsList
            // 
            this.AccessibleLocationsList.Location = new System.Drawing.Point(12, 74);
            this.AccessibleLocationsList.Name = "AccessibleLocationsList";
            this.AccessibleLocationsList.Size = new System.Drawing.Size(190, 208);
            this.AccessibleLocationsList.TabIndex = 2;
            this.AccessibleLocationsList.UseCompatibleStateImageBehavior = false;
            this.AccessibleLocationsList.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Locations:";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(208, 98);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(166, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add location";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AvailibleLocationBox
            // 
            this.AvailibleLocationBox.FormattingEnabled = true;
            this.AvailibleLocationBox.Location = new System.Drawing.Point(208, 74);
            this.AvailibleLocationBox.Name = "AvailibleLocationBox";
            this.AvailibleLocationBox.Size = new System.Drawing.Size(166, 21);
            this.AvailibleLocationBox.TabIndex = 5;
            // 
            // RemoveAccessibleLocationButton
            // 
            this.RemoveAccessibleLocationButton.Location = new System.Drawing.Point(208, 141);
            this.RemoveAccessibleLocationButton.Name = "RemoveAccessibleLocationButton";
            this.RemoveAccessibleLocationButton.Size = new System.Drawing.Size(166, 23);
            this.RemoveAccessibleLocationButton.TabIndex = 6;
            this.RemoveAccessibleLocationButton.Text = "Remove selected location";
            this.RemoveAccessibleLocationButton.UseVisualStyleBackColor = true;
            this.RemoveAccessibleLocationButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditAccessRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 294);
            this.Controls.Add(this.RemoveAccessibleLocationButton);
            this.Controls.Add(this.AvailibleLocationBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AccessibleLocationsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecLevelBox);
            this.Name = "EditAccessRule";
            this.Text = "EditAccessRule";
            this.Load += new System.EventHandler(this.EditAccessRule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SecLevelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView AccessibleLocationsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox AvailibleLocationBox;
        private System.Windows.Forms.Button RemoveAccessibleLocationButton;
    }
}