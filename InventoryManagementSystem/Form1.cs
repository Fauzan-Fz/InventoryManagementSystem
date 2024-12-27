using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerform = new RegisterForm();
            registerform.Show();

            this.Hide();
        }

        private void chShowPasswordLogin_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordLogin.PasswordChar = chShowPasswordLogin.Checked ? '\0' : '*';
        }
    }
}
