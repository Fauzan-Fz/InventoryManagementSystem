using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class RegisterForm : Form
    {

        SqlConnection 
            connect = new SqlConnection("Server = localhost; Database=Inventory;Trusted_Connection=True");

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();

            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsernameRegister.Text == "" || txtPasswordRegister.Text == "" || txtConfirmPasswordRegister.Text == "")
            {
                MessageBox.Show("Please fill the empty field","Error Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (ConnectionCheck())
                {
                    try
                    {
                        connect.Open();

                        string checkUsername = "SELECT * FROM users WHERE username = @usern";

                        using (SqlCommand cmd = new SqlCommand(checkUsername,connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", txtUsernameRegister.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("'" + txtUsernameRegister.Text.Trim() + "'" + " Is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } 
                            else if (txtPasswordRegister.Text.Length < 8)
                            {
                                MessageBox.Show("Invalid Password, at least 8 characters are needed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if(txtPasswordRegister.Text.Trim() != txtConfirmPasswordRegister.Text.Trim())
                            {
                                MessageBox.Show("Password does not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string InsertData = "INSERT INTO users (username, password, role, status, date) " +
                                        "VALUES(@usern, @pass, @role, @status, @date)";

                                using (SqlCommand InsertD = new SqlCommand(InsertData, connect))
                                {
                                    InsertD.Parameters.AddWithValue("@usern", txtUsernameRegister.Text.Trim());
                                    InsertD.Parameters.AddWithValue("@pass", txtPasswordRegister.Text.Trim());
                                    InsertD.Parameters.AddWithValue("@role", "cashire");
                                    InsertD.Parameters.AddWithValue("@status","approval");

                                    DateTime today = DateTime.Today;
                                    InsertD.Parameters.AddWithValue("@date",today);

                                    InsertD.ExecuteNonQuery();
                                    MessageBox.Show("Register Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    FormLogin formLogin = new FormLogin();
                                    formLogin.Show();

                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Connection Failed" + ex ,
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        public bool ConnectionCheck()
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

        private void chShowPasswordRegister_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordRegister.PasswordChar = chShowPasswordRegister.Checked ? '\0' : '*';
            txtConfirmPasswordRegister.PasswordChar = chShowPasswordRegister.Checked ? '\0' : '*';
        }
    }
}
