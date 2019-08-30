namespace CourseProjectApplication
{
    partial class LoginForm
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
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.UserIdBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.OkBox = new System.Windows.Forms.Button();
            this.CancelBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.AutoSize = true;
            this.UserIdLabel.Location = new System.Drawing.Point(12, 9);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(38, 13);
            this.UserIdLabel.TabIndex = 0;
            this.UserIdLabel.Text = "UserId";
            // 
            // UserIdBox
            // 
            this.UserIdBox.Location = new System.Drawing.Point(15, 25);
            this.UserIdBox.Name = "UserIdBox";
            this.UserIdBox.Size = new System.Drawing.Size(186, 20);
            this.UserIdBox.TabIndex = 1;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(15, 68);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(186, 20);
            this.PasswordBox.TabIndex = 3;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 52);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Password";
            // 
            // OkBox
            // 
            this.OkBox.Location = new System.Drawing.Point(126, 145);
            this.OkBox.Name = "OkBox";
            this.OkBox.Size = new System.Drawing.Size(75, 23);
            this.OkBox.TabIndex = 4;
            this.OkBox.Text = "OK";
            this.OkBox.UseVisualStyleBackColor = true;
            this.OkBox.Click += new System.EventHandler(this.OkBox_Click);
            // 
            // CancelBox
            // 
            this.CancelBox.Location = new System.Drawing.Point(12, 145);
            this.CancelBox.Name = "CancelBox";
            this.CancelBox.Size = new System.Drawing.Size(75, 23);
            this.CancelBox.TabIndex = 5;
            this.CancelBox.Text = "Cancel";
            this.CancelBox.UseVisualStyleBackColor = true;
            this.CancelBox.Click += new System.EventHandler(this.CancelBox_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 180);
            this.Controls.Add(this.CancelBox);
            this.Controls.Add(this.OkBox);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserIdBox);
            this.Controls.Add(this.UserIdLabel);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserIdLabel;
        private System.Windows.Forms.TextBox UserIdBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button OkBox;
        private System.Windows.Forms.Button CancelBox;
    }
}