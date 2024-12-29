using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AdminAddCategories : UserControl
    {

        SqlConnection
            connect = new SqlConnection("Server=localhost;Database=Inventory;Trusted_Connection=True;");

        public AdminAddCategories()
        {
            InitializeComponent();
            displayCategoriesData();
        }

        public void displayCategoriesData()
        {
            CategoriesData cData = new CategoriesData();
            List<CategoriesData> listdata = cData.AllCategoriesData();

            dataGridView1.DataSource = listdata;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtAddCategory.Text == "")
            {
                MessageBox.Show("Empty Field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string checkCtg = "SELECT * FROM categories WHERE category = @ctg";

                        using (SqlCommand cmd = new SqlCommand(checkCtg, connect))
                        {
                            cmd.Parameters.AddWithValue("@ctg", txtAddCategory.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable data = new DataTable();
                            adapter.Fill(data);

                            if (data.Rows.Count > 0)
                            {
                                MessageBox.Show("Category " + txtAddCategory.Text.Trim() + " Is already exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }
                            else
                            {
                                string insertData = "INSERT INTO categories (category,date) VALUES(@ctg,@date)";

                                using (SqlCommand InsertD = new SqlCommand(insertData, connect))
                                {
                                    InsertD.Parameters.AddWithValue("@ctg", txtAddCategory.Text.Trim());
                                    DateTime time = DateTime.Now;
                                    InsertD.Parameters.AddWithValue("@date", time);

                                    InsertD.ExecuteNonQuery();
                                    clearField();
                                    displayCategoriesData();

                                    MessageBox.Show("Added Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void clearField()
        {
            txtAddCategory.Text = "";
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;

                txtAddCategory.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (txtAddCategory.Text == "")
            {
                MessageBox.Show("Empty Field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Update Category ID : " + getID + " ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            {
                                string updateData = "UPDATE categories SET category = @ctg WHERE id = @id";

                                using (SqlCommand updateD = new SqlCommand(updateData, connect))
                                {
                                    updateD.Parameters.AddWithValue("@ctg", txtAddCategory.Text.Trim());
                                    updateD.Parameters.AddWithValue("@id", getID);
                                    
                                    updateD.ExecuteNonQuery();
                                    clearField();
                                    displayCategoriesData();

                                    MessageBox.Show("Added Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection Failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (txtAddCategory.Text == "")
            {
                MessageBox.Show("Empty Field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Remove Category ID : " + getID + " ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            {
                                string removeData = "DELETE FROM categories WHERE id = @id";

                                using (SqlCommand removeD = new SqlCommand(removeData, connect))
                                {
                                    removeD.Parameters.AddWithValue("@id", getID);

                                    removeD.ExecuteNonQuery();
                                    clearField();
                                    displayCategoriesData();

                                    MessageBox.Show("Remove Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection Failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

