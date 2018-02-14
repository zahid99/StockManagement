using System;
using System.Windows.Forms;
using StockManagementSystem.Gateway;
using StockManagementSystem.Manager;

namespace StockManagementSystem.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userNameTextBox.Text = "Zahid";
            passwordTextBox.Text = "zahid";
            UserLoginManager aUserLoginManager=new UserLoginManager();
            if (aUserLoginManager.IsExist(userNameTextBox.Text,passwordTextBox.Text))
            {
                MainForm2 mainFormUi = new MainForm2();
                mainFormUi.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User Name OR Password Wrong");
            }
            

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
