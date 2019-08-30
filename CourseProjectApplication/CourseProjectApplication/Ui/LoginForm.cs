using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectApplication
{
    public partial class LoginForm : Form
    {
        public string UserIdValue { get; private set; }
        public string PasswordValue { get; private set; }
        public bool Success { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void OkPressed()
        {
            if (String.IsNullOrWhiteSpace(UserIdBox.Text))
            {
                MessageBox.Show("UserId cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Success = true;
                UserIdValue = UserIdBox.Text;
                PasswordValue = PasswordBox.Text;

                Close();
            }
        }

        private void OkBox_Click(object sender, EventArgs e)
        {
            OkPressed();
        }

        private void CancelBox_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
