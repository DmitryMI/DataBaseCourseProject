using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseProjectApplication.SecSystem;

namespace CourseProjectApplication.Ui
{
    public partial class EditAccessRule : Form
    {
        private ISecSystem _secSystem;
        private IList<Location> _locations;

        public EditAccessRule(ISecSystem secSystem, SecLevel secLevel = null)
        {
            InitializeComponent();
            _secSystem = secSystem;


            EnsureLoginState();
            LoadAllLocations();
            
            if (secLevel != null)
            {
                SecLevelBox.Items.Add(secLevel);
                SecLevelBox.SelectedIndex = 0;
                SecLevelBox.Enabled = false;

                LoadAccessibleLocations(secLevel.Id);
            }
            else
            {
                LoadSecLevels();
            }
        }

        private void LoadSecLevels()
        {
            var list = _secSystem.GetSecLevels();
            foreach (SecLevel secLevel in list)
            {
                SecLevelBox.Items.Add(secLevel);
            }
        }

        private void LoadAccessibleLocations(int levelId)
        {
            var list = _secSystem.GetSecLevelLocations(levelId);
            AccessibleLocationsList.Items.Clear();
            foreach (Location loc in list)
            {
                ListViewItemWithId item = new ListViewItemWithId(loc.Id, loc.Id + ". " + loc.Name);
                AccessibleLocationsList.Items.Add(item);
            }
        }

        private void LoadAvailableLocations(int levelId)
        {
            AvailibleLocationBox.Items.Clear();
            foreach (Location loc in _locations)
            {
                if (!HasId(loc.Id, AccessibleLocationsList.Items))
                    AvailibleLocationBox.Items.Add(loc);
            }
        }

        private bool HasId(int id, ICollection collection)
        {
            foreach (ListViewItemWithId item in collection)
            {
                if (item.Id == id)
                    return true;
            }

            return false;
        }

        private void LoadAllLocations()
        {
            _locations = _secSystem.GetLocations();
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

        private void EditAccessRule_Load(object sender, EventArgs e)
        {

        }

        private T GetFromBox<T>(ComboBox box, string str) where T: class
        {
            foreach (var item in box.Items)
            {
                if (item.ToString().Equals(str))
                    return (T)item;
            }

            return null;
        }

        private void SecLevelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void OnSecLevelTextChanged()
        {
            string text = SecLevelBox.Text;
            SecLevel secLevel = GetFromBox<SecLevel>(SecLevelBox, text);

            if (secLevel != null)
            {
                int secLevelId = secLevel.Id;

                LoadAccessibleLocations(secLevelId);
                LoadAvailableLocations(secLevelId);
            }
        }

        private void SecLevelBox_TextChanged(object sender, EventArgs e)
        {
            OnSecLevelTextChanged();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string textLocation = AvailibleLocationBox.Text;
                Location location = GetFromBox<Location>(AvailibleLocationBox, textLocation);
                if(location == null)
                    return;
                

                string textSecLevel = SecLevelBox.Text;
                SecLevel secLevel = GetFromBox<SecLevel>(SecLevelBox, textSecLevel);

                if (secLevel == null)
                    return;

                _secSystem.AddAccessibleLocation(secLevel, location);

                LoadAccessibleLocations(secLevel.Id);
                LoadAvailableLocations(secLevel.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string textSecLevel = SecLevelBox.Text;
                SecLevel secLevel = GetFromBox<SecLevel>(SecLevelBox, textSecLevel);
                if (secLevel == null)
                    return;

                foreach (ListViewItemWithId selectedItem in AccessibleLocationsList.SelectedItems)
                {
                    int locationId = selectedItem.Id;
                    _secSystem.RemoveAccessibleLocation(secLevel, locationId);
                }
                

                LoadAccessibleLocations(secLevel.Id);
                LoadAvailableLocations(secLevel.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
