using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class RegisterFormApp : Form
    {
        SqlConnection
            connect = new SqlConnection("Server=localhost; Database=Inventory;Trusted_Connection=True");

        public RegisterFormApp()
        {
            InitializeComponent();
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


        private void btnCloses_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
        }

        private void btnReg_Click_1(object sender, EventArgs e)
        {
            if (txtUsernameReg.Text == "" || txtPasswordReg.Text == "" || txtCPasswordReg.Text == "")
            {
                MessageBox.Show("Please fill the empty field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ConnectionCheck())
                {
                    try
                    {
                        connect.Open();

                        string checkUsername = "SELECT * FROM users WHERE username = @usern";

                        using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", txtUsernameReg.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("'" + txtUsernameReg.Text.Trim() + "'" + " Is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (txtPasswordReg.Text.Length < 8)
                            {
                                MessageBox.Show("Invalid Password, at least 8 characters are needed", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (txtPasswordReg.Text.Trim() != txtCPasswordReg.Text.Trim())
                            {
                                MessageBox.Show("Password does not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string InsertData = "INSERT INTO users (username, password, role, status, date) " +
                                        "VALUES(@usern, @pass, @role, @status, @date)";

                                using (SqlCommand InsertD = new SqlCommand(InsertData, connect))
                                {
                                    InsertD.Parameters.AddWithValue("@usern", txtUsernameReg.Text.Trim());
                                    InsertD.Parameters.AddWithValue("@pass", txtPasswordReg.Text.Trim());
                                    InsertD.Parameters.AddWithValue("@role", "cashire");
                                    InsertD.Parameters.AddWithValue("@status", "approval");

                                    DateTime today = DateTime.Today;
                                    InsertD.Parameters.AddWithValue("@date", today);

                                    InsertD.ExecuteNonQuery();
                                    MessageBox.Show("Register Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    FormLogin formLogin = new FormLogin();
                                    formLogin.Show();

                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Failed" + ex,
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void chShowPasswordReg_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordReg.PasswordChar = chShowPasswordReg.Checked ? '\0' : '*';
            txtCPasswordReg.PasswordChar = chShowPasswordReg.Checked ? '\0' : '*';
        }
    }
}
