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
    }
}
