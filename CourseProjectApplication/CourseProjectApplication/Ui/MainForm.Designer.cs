namespace CourseProjectApplication.Ui
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.UsersTab = new System.Windows.Forms.TabPage();
            this.locationsListLabel = new System.Windows.Forms.Label();
            this.AccessibleLocationsList = new System.Windows.Forms.ListView();
            this.LoadUsersButton = new System.Windows.Forms.Button();
            this.registeredUsersLabel = new System.Windows.Forms.Label();
            this.UsersList = new System.Windows.Forms.ListView();
            this.LocationsTab = new System.Windows.Forms.TabPage();
            this.EditSecRolesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AddLocationNameBox = new System.Windows.Forms.TextBox();
            this.AddLocationButton = new System.Windows.Forms.Button();
            this.LoadLocationsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LocationsList = new System.Windows.Forms.ListView();
            this.EditVoiceSamples = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.UsersTab.SuspendLayout();
            this.LocationsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.UsersTab);
            this.MainTabControl.Controls.Add(this.LocationsTab);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(776, 426);
            this.MainTabControl.TabIndex = 0;
            // 
            // UsersTab
            // 
            this.UsersTab.Controls.Add(this.EditVoiceSamples);
            this.UsersTab.Controls.Add(this.locationsListLabel);
            this.UsersTab.Controls.Add(this.AccessibleLocationsList);
            this.UsersTab.Controls.Add(this.LoadUsersButton);
            this.UsersTab.Controls.Add(this.registeredUsersLabel);
            this.UsersTab.Controls.Add(this.UsersList);
            this.UsersTab.Location = new System.Drawing.Point(4, 22);
            this.UsersTab.Name = "UsersTab";
            this.UsersTab.Padding = new System.Windows.Forms.Padding(3);
            this.UsersTab.Size = new System.Drawing.Size(768, 400);
            this.UsersTab.TabIndex = 0;
            this.UsersTab.Text = "Users";
            this.UsersTab.UseVisualStyleBackColor = true;
            // 
            // locationsListLabel
            // 
            this.locationsListLabel.AutoSize = true;
            this.locationsListLabel.Location = new System.Drawing.Point(279, 12);
            this.locationsListLabel.Name = "locationsListLabel";
            this.locationsListLabel.Size = new System.Drawing.Size(103, 13);
            this.locationsListLabel.TabIndex = 4;
            this.locationsListLabel.Text = "Accessible locations";
            // 
            // AccessibleLocationsList
            // 
            this.AccessibleLocationsList.Location = new System.Drawing.Point(282, 33);
            this.AccessibleLocationsList.Name = "AccessibleLocationsList";
            this.AccessibleLocationsList.Size = new System.Drawing.Size(270, 361);
            this.AccessibleLocationsList.TabIndex = 3;
            this.AccessibleLocationsList.UseCompatibleStateImageBehavior = false;
            this.AccessibleLocationsList.View = System.Windows.Forms.View.List;
            // 
            // LoadUsersButton
            // 
            this.LoadUsersButton.Location = new System.Drawing.Point(97, 7);
            this.LoadUsersButton.Name = "LoadUsersButton";
            this.LoadUsersButton.Size = new System.Drawing.Size(75, 23);
            this.LoadUsersButton.TabIndex = 2;
            this.LoadUsersButton.Text = "Load users";
            this.LoadUsersButton.UseVisualStyleBackColor = true;
            this.LoadUsersButton.Click += new System.EventHandler(this.LoadUsersButton_Click);
            // 
            // registeredUsersLabel
            // 
            this.registeredUsersLabel.AutoSize = true;
            this.registeredUsersLabel.Location = new System.Drawing.Point(3, 12);
            this.registeredUsersLabel.Name = "registeredUsersLabel";
            this.registeredUsersLabel.Size = new System.Drawing.Size(86, 13);
            this.registeredUsersLabel.TabIndex = 1;
            this.registeredUsersLabel.Text = "Registered users";
            // 
            // UsersList
            // 
            this.UsersList.Location = new System.Drawing.Point(6, 33);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(270, 361);
            this.UsersList.TabIndex = 0;
            this.UsersList.UseCompatibleStateImageBehavior = false;
            this.UsersList.View = System.Windows.Forms.View.List;
            this.UsersList.SelectedIndexChanged += new System.EventHandler(this.UsersList_SelectedIndexChanged);
            // 
            // LocationsTab
            // 
            this.LocationsTab.Controls.Add(this.EditSecRolesButton);
            this.LocationsTab.Controls.Add(this.label2);
            this.LocationsTab.Controls.Add(this.AddLocationNameBox);
            this.LocationsTab.Controls.Add(this.AddLocationButton);
            this.LocationsTab.Controls.Add(this.LoadLocationsButton);
            this.LocationsTab.Controls.Add(this.label1);
            this.LocationsTab.Controls.Add(this.LocationsList);
            this.LocationsTab.Location = new System.Drawing.Point(4, 22);
            this.LocationsTab.Name = "LocationsTab";
            this.LocationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.LocationsTab.Size = new System.Drawing.Size(768, 400);
            this.LocationsTab.TabIndex = 1;
            this.LocationsTab.Text = "Locations";
            this.LocationsTab.UseVisualStyleBackColor = true;
            // 
            // EditSecRolesButton
            // 
            this.EditSecRolesButton.Location = new System.Drawing.Point(415, 88);
            this.EditSecRolesButton.Name = "EditSecRolesButton";
            this.EditSecRolesButton.Size = new System.Drawing.Size(294, 23);
            this.EditSecRolesButton.TabIndex = 9;
            this.EditSecRolesButton.Text = "Edit security rules";
            this.EditSecRolesButton.UseVisualStyleBackColor = true;
            this.EditSecRolesButton.Click += new System.EventHandler(this.EditSecRolesButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "- location name";
            // 
            // AddLocationNameBox
            // 
            this.AddLocationNameBox.Location = new System.Drawing.Point(415, 33);
            this.AddLocationNameBox.Name = "AddLocationNameBox";
            this.AddLocationNameBox.Size = new System.Drawing.Size(209, 20);
            this.AddLocationNameBox.TabIndex = 7;
            // 
            // AddLocationButton
            // 
            this.AddLocationButton.Location = new System.Drawing.Point(415, 59);
            this.AddLocationButton.Name = "AddLocationButton";
            this.AddLocationButton.Size = new System.Drawing.Size(294, 23);
            this.AddLocationButton.TabIndex = 6;
            this.AddLocationButton.Text = "Add location";
            this.AddLocationButton.UseVisualStyleBackColor = true;
            this.AddLocationButton.Click += new System.EventHandler(this.AddLocationButton_Click);
            // 
            // LoadLocationsButton
            // 
            this.LoadLocationsButton.Location = new System.Drawing.Point(100, 7);
            this.LoadLocationsButton.Name = "LoadLocationsButton";
            this.LoadLocationsButton.Size = new System.Drawing.Size(75, 23);
            this.LoadLocationsButton.TabIndex = 5;
            this.LoadLocationsButton.Text = "Load locations";
            this.LoadLocationsButton.UseVisualStyleBackColor = true;
            this.LoadLocationsButton.Click += new System.EventHandler(this.LoadLocationsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Locations";
            // 
            // LocationsList
            // 
            this.LocationsList.Location = new System.Drawing.Point(9, 33);
            this.LocationsList.Name = "LocationsList";
            this.LocationsList.Size = new System.Drawing.Size(400, 361);
            this.LocationsList.TabIndex = 3;
            this.LocationsList.UseCompatibleStateImageBehavior = false;
            this.LocationsList.View = System.Windows.Forms.View.List;
            // 
            // EditVoiceSamples
            // 
            this.EditVoiceSamples.Enabled = false;
            this.EditVoiceSamples.Location = new System.Drawing.Point(646, 371);
            this.EditVoiceSamples.Name = "EditVoiceSamples";
            this.EditVoiceSamples.Size = new System.Drawing.Size(116, 23);
            this.EditVoiceSamples.TabIndex = 5;
            this.EditVoiceSamples.Text = "Голосовые данные";
            this.EditVoiceSamples.UseVisualStyleBackColor = true;
            this.EditVoiceSamples.Click += new System.EventHandler(this.EditVoiceSamples_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MainForm";
            this.Text = "SecSystem";
            this.MainTabControl.ResumeLayout(false);
            this.UsersTab.ResumeLayout(false);
            this.UsersTab.PerformLayout();
            this.LocationsTab.ResumeLayout(false);
            this.LocationsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage UsersTab;
        private System.Windows.Forms.Label registeredUsersLabel;
        private System.Windows.Forms.ListView UsersList;
        private System.Windows.Forms.TabPage LocationsTab;
        private System.Windows.Forms.Button LoadUsersButton;
        private System.Windows.Forms.Label locationsListLabel;
        private System.Windows.Forms.ListView AccessibleLocationsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AddLocationNameBox;
        private System.Windows.Forms.Button AddLocationButton;
        private System.Windows.Forms.Button LoadLocationsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LocationsList;
        private System.Windows.Forms.Button EditSecRolesButton;
        private System.Windows.Forms.Button EditVoiceSamples;
    }
}

