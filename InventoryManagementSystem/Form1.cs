using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class FormLogin : Form
    {

        SqlConnection
            connect = new SqlConnection("Server=localhost; Database=Inventory;Trusted_Connection=True");


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
            RegisterFormApp frm = new RegisterFormApp();
            frm.ShowDialog();

            this.Hide();
        }

        private void chShowPasswordLogin_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordLogin.PasswordChar = chShowPasswordLogin.Checked ? '\0' : '*';
        }

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT COUNT(*) FROM users WHERE username = @usern AND password = @pass AND status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@usern", txtUsernameLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtPasswordLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", "Active");

                        int rowCount = (int)cmd.ExecuteScalar();

                        if (rowCount > 0)
                        {
                            string selectRole = "SELECT role FROM users WHERE username = @usern AND password = @pass";

                            using (SqlCommand getRole = new SqlCommand(selectRole, connect))
                            {
                                getRole.Parameters.AddWithValue("@usern", txtUsernameLogin.Text.Trim());
                                getRole.Parameters.AddWithValue("@pass", txtPasswordLogin.Text.Trim());

                                string userRole = getRole.ExecuteScalar() as string;

                                MessageBox.Show("Login Successful", "Information",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (userRole == "Admin")
                                {
                                    MainForm mainForm = new MainForm();
                                    mainForm.Show();

                                    this.Hide();
                                }
                                else if(userRole == "Cashier")
                                {
                                    CashierMainForm cMainForm = new CashierMainForm();
                                    cMainForm.Show();

                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username/Password or there's no admin's approval", "Error Message",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed : " + ex, "Error Message",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
    }
}
