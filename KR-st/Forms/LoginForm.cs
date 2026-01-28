using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR.Forms
{
    public partial class LoginForm : Form
    {
        public string CurrentUser;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var allUsers = new List<string> { "Татьяна", "Виктория", "Диана" };
            if (!allUsers.Contains(NameField.Text))
                ErrorLabel.Visible = true;
            else
            {
                CurrentUser = NameField.Text;
                if (ActiveForm != null) ActiveForm.Close();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NameField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
