using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AdminsAddUser : UserControl
    {

        SqlConnection
            connect = new SqlConnection("Server=localhost;Database=Inventory;Trusted_Connection=True;");


        public AdminsAddUser()
        {
            InitializeComponent();

            DisplayAllUserData();
        }

        public void DisplayAllUserData()
        {
            UsersData uData = new UsersData();

            List<UsersData> listData = uData.AllUserData();

            dataGridView1.DataSource = listData;
        }


        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
            if (txtAddUsername.Text == "" || txtAddPassword.Text == "" || cbAddRole.SelectedIndex == -1 || cbAddStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill the empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string checkUsername = "SELECT * FROM users WHERE username = @usern";

                        using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
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
                                using (SqlCommand InsertD = new SqlCommand(InsertData, connect))
                                {
                                    InsertD.Parameters.AddWithValue("@usern", txtAddUsername.Text.Trim());
                                    InsertD.Parameters.AddWithValue("@pass", txtAddPassword.Text.Trim());
                                    InsertD.Parameters.AddWithValue("@role", cbAddRole.SelectedItem.ToString());
                                    InsertD.Parameters.AddWithValue("@status", cbAddStatus.SelectedItem.ToString());

                                    DateTime time = DateTime.Today;
                                    InsertD.Parameters.AddWithValue("@date", time);

                                    InsertD.ExecuteNonQuery();
                                    ClearFlield();
                                    DisplayAllUserData();

                                    MessageBox.Show("Added Succesfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void ClearFlield()
        {
            txtAddUsername.Text = "";
            txtAddPassword.Text = "";
            cbAddRole.SelectedItem = -1;
            cbAddStatus.SelectedItem = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFlield();
            DisplayAllUserData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddUsername.Text == "" || txtAddPassword.Text == "" || cbAddRole.SelectedIndex == -1 || cbAddStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill the empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (MessageBox.Show("Are you want to Update User ID: " + GetId + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE users SET username = @usern, " +
                                                "password = @pass, role = @role,status = @status WHERE id = @id";

                            using (SqlCommand UpdateD = new SqlCommand(updateData, connect))
                            {
                                UpdateD.Parameters.AddWithValue("@usern", txtAddUsername.Text.Trim());
                                UpdateD.Parameters.AddWithValue("@pass", txtAddPassword.Text.Trim());
                                UpdateD.Parameters.AddWithValue("@role", cbAddRole.SelectedItem);
                                UpdateD.Parameters.AddWithValue("@status", cbAddStatus.SelectedItem);
                                UpdateD.Parameters.AddWithValue("@id", GetId);

                                UpdateD.ExecuteNonQuery();
                                ClearFlield();
                                DisplayAllUserData();

                                MessageBox.Show("Update Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private int GetId = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                GetId = (int)row.Cells[0].Value;
                string username = row.Cells[1].Value.ToString();
                string password = row.Cells[2].Value.ToString();
                string role = row.Cells[3].Value.ToString();
                string status = row.Cells[4].Value.ToString();

                txtAddUsername.Text = username;
                txtAddPassword.Text = password;
                cbAddRole.Text = role;
                cbAddStatus.Text = status;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtAddUsername.Text == "" || txtAddPassword.Text == "" || cbAddRole.SelectedIndex == -1 || cbAddStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill the empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (MessageBox.Show("Are you want to Remove User ID: " + GetId + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "DELETE FROM users WHERE id = @id";

                            using (SqlCommand UpdateD = new SqlCommand(updateData, connect))
                            {
                                UpdateD.Parameters.AddWithValue("@id", GetId);
                                UpdateD.ExecuteNonQuery();

                                ClearFlield();
                                DisplayAllUserData();

                                MessageBox.Show("Removed Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }

}
