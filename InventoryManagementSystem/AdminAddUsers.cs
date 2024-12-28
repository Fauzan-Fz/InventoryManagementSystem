using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AdminAddUsers : Form
    {
        SqlConnection
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fauza\OneDrive\Documents\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        public AdminAddUsers()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtAddUsername.Text == "" || txtAddPassword.Text == "" || cbAddRole.SelectedIndex == -1 || cbAddStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill the empty fields", "Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string checkUsername = "SELECT * FROM users WHERE username = @usern";

                        using (SqlCommand cmd = new SqlCommand(checkUsername,connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", txtAddUsername.Text.Trim());
                            
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable data = new DataTable();
                            adapter.Fill(data);

                            if (data.Rows.Count > 0)
                            {
                                MessageBox.Show(txtAddUsername.Text.Trim() + "Is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                string InsertData = "INSERT INTO users (username,password,role,status,date) " +
                                                    "VALUES(@usern,@pass,@role,@status,@date)";
                                using (SqlCommand InsertD = new SqlCommand())
                                {

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Failed" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
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

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
