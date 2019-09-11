using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using CourseProjectApplication.SecSystem;

namespace CourseProjectApplication.Ui
{
    public partial class MainForm : Form
    {
        private ISecSystem _secSystem = SecSystemBuilder.GetInstance();

        public MainForm()
        {
            InitializeComponent();
        }

        private bool LoginFromGui()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.Success)
            {
                string userId = loginForm.UserIdValue;
                string password = loginForm.PasswordValue;
                LoginFromData(userId, password);
                return _secSystem.LoginSuccessful;
            }
            else
            {
                return false;
            }
        }

        private bool EnsureLoginState()
        {
            if (_secSystem == null || !_secSystem.LoginSuccessful)
            {
                return LoginFromGui();
            }

            return true;
        }

        private void LoginFromData(string uid, string pwd)
        {
            _secSystem = SecSystemBuilder.GetInstance();
            _secSystem.LoginAs(uid, pwd);

            if (!_secSystem.LoginSuccessful)
            {
                MessageBox.Show("Login failed!", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsersButton_Click(object sender, EventArgs e)
        {
            UpdateUserList();
        }

        private void UpdateUserList()
        {
            if (!EnsureLoginState())
            {
                return;
            }

            var userList = _secSystem.GetUsers();

            UsersList.Items.Clear();

            foreach (var user in userList)
            {
                SecLevel secLevel = _secSystem.GetSecLevelById(user.SecLevelId);
                var secLevelName = secLevel.Name;

                var item = new ListViewItemWithId(user.Id, user.FirstName + " " + user.LastName + " ---- " + secLevelName);

                UsersList.Items.Add(item);
            }
        }

        private void ProcessUserSelection()
        {
            if (UsersList.SelectedItems.Count != 1)
            {
                EditVoiceSamples.Enabled = false;
            }
            else
            {
                EditVoiceSamples.Enabled = true;
            }

            if(UsersList.SelectedItems.Count < 1)
                return;

            AccessibleLocationsList.Items.Clear();

            //ListViewItemWithId selected = (ListViewItemWithId)UsersList.SelectedItems[0];
            foreach (ListViewItemWithId item in UsersList.SelectedItems)
            {
                IList<Location> list = _secSystem.GetAccessibleLocations(item.Id);
                foreach (var loc in list)
                {
                    if (!ContainsId(AccessibleLocationsList.Items, loc.Id))
                    {
                        ListViewItemWithId locItem = new ListViewItemWithId(loc.Id, loc.Name);
                        AccessibleLocationsList.Items.Add(locItem);
                    }
                }
            }
        }

        private bool ContainsId(ICollection listView, int id)
        {
            foreach (ListViewItemWithId listItem in listView)
            {
                if (listItem.Id == id)
                    return true;
            }

            return false;
        }

        private void UsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessUserSelection();
        }

        private void UpdateLocationsList()
        {
            if (!EnsureLoginState())
            {
                return;
            }

            var locationList = _secSystem.GetLocations();

            LocationsList.Items.Clear();

            foreach (var loc in locationList)
            {
                var item = new ListViewItemWithId(loc.Id, loc.Id.ToString() + ". " + loc.Name);

                LocationsList.Items.Add(item);
            }
        }

        private void LoadLocationsButton_Click(object sender, EventArgs e)
        {
            UpdateLocationsList();
        }

        private void AddLocationButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(AddLocationNameBox.Text))
            {
                MessageBox.Show("Location name must not be empty!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            Location location = _secSystem.CreateLocation(AddLocationNameBox.Text);
            if (location == null)
            {
                MessageBox.Show("Error with creating location! Check data base connection.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            UpdateLocationsList();
        }

        private void EditSecRolesButton_Click(object sender, EventArgs e)
        {
            EditAccessRule editor = new EditAccessRule(_secSystem, null);
            editor.ShowDialog();
        }

        private void EditVoiceSamples_Click(object sender, EventArgs e)
        {
            if (UsersList.SelectedItems.Count != 1)
                return;

            ListViewItemWithId item = (ListViewItemWithId) UsersList.SelectedItems[0];
            int userId = item.Id;

            VoiceSampleEditor editorForm = new VoiceSampleEditor(userId, _secSystem);
            editorForm.ShowDialog();
        }
    }
}
