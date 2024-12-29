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
                //try
                //{
                    connect.Open();

                    string selectData = "SELECT * FROM users WHERE username = @usern AND password = @pass";

                    using (SqlCommand cmd = new SqlCommand(selectData,connect))
                    {
                        cmd.Parameters.AddWithValue("@usern", txtUsernameLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass",txtPasswordLogin.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        if (data.Rows.Count > 0)
                        {
                            MessageBox.Show("Login Succesfully!", "Information Message", 
                                            MessageBoxButtons.OK,MessageBoxIcon.Information);

                            MainForm mForm = new MainForm();
                            mForm.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password, Please Try Again", "Error Message", 
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Connection Failed : " + ex , "Error Message", 
                //                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                //}
                //finally
                //{
                //    connect.Close();
                //}
            }
        }
    }
}
