using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{

    public partial class CashierIOrder : UserControl
    {

        SqlConnection
            connect = new SqlConnection("Server=localhost;Database=Inventory;Trusted_Connection=True;");

        public CashierIOrder()
        {
            InitializeComponent();
            displayAllAvailableProducts();
            displayAllCategories();
        }

        public void displayAllAvailableProducts()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listdata = apData.AllProductsData();

            dataGridView1.DataSource = listdata;
        }

        public void displayAllCategories()
        {
            try
            {
                connect.Open();

                string selectData = "SELECT * FROM categories";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cbCategory.Items.Clear();

                        while (reader.Read())
                        {
                            string item = reader.GetString(1);
                            cbCategory.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed Connection : " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProductsID.SelectedIndex = -1;
            cbProductsID.Items.Clear();
            lblProdName.Text = "";
            lblPrice.Text = "";
            //numericQuantity.Value = 0;

            string selectedValue = cbCategory.SelectedItem as string;

            if (selectedValue != null)
            {
                try
                {
                    connect.Open();

                    string selectData = $"SELECT * FROM products WHERE category = '{selectedValue}' AND status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@status", "Available");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string value = reader["prod_id"].ToString();

                                cbProductsID.Items.Add(value);
                            }
                        }
                    }
                }
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Failed Connection" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                finally
                {
                    connect.Close();
                }
            }
        }

        private void cbProductsID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbProductsID.SelectedItem as string;

            if (selectedValue != null)
            {
                try
                {
                    connect.Open();

                    string selectData = $"SELECT * FROM products WHERE prod_id = '{selectedValue}' AND status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@status", "Available");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string prodName = reader["prod_name"].ToString();
                                float prodPrice = Convert.ToSingle(reader["price"]);

                                lblProdName.Text = prodName;
                                lblPrice.Text = prodPrice.ToString("0.00");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed Connection" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (cbCategory.SelectedIndex == -1 || cbProductsID.SelectedIndex == -1 || lblProdName.Text == "" || lblPrice.Text == "" || numericQuantity.Value == 0)
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connect.Open();
                    float getPrice = 0;
                    string selectOrder = "SELECT * FROM products WHERE prod_id = @prodID";

                    using (SqlCommand getOrder =  new SqlCommand(selectOrder, connect))
                    {
                        getOrder.Parameters.AddWithValue("@prodID", cbProductsID.SelectedItem);

                        using (SqlDataReader reader = getOrder.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                object rawValuue = reader["price"];

                                if (rawValuue != DBNull.Value)
                                {
                                    getPrice = Convert.ToSingle(rawValuue);
                                }
                            }
                        }
                    }

                    string insertData = "INSERT INTO orders (customers_id,prod_id,prod_name,category,qty,orig_price,total_price,order_date) " +
                        "VALUES(@cID,@prodID,@prodName,@ctg,@qty,@origPrice,@totalprice,@date)";

                    using (SqlCommand cmd = new SqlCommand(insertData,connect))
                    {
                        cmd.Parameters.AddWithValue("@cID",idGen);
                        cmd.Parameters.AddWithValue("@prodID",cbProductsID.SelectedItem);
                        cmd.Parameters.AddWithValue("@prodName", lblProdName.Text.Trim());
                        cmd.Parameters.AddWithValue("@ctg",cbCategory.SelectedItem);
                        cmd.Parameters.AddWithValue("@qty",numericQuantity.Value);
                        cmd.Parameters.AddWithValue("origPrice",getPrice);

                        float totalP = (getPrice*(int)numericQuantity.Value);
                        DateTime date = DateTime.Today;

                        cmd.Parameters.AddWithValue("@totalprice",totalP);
                        cmd.Parameters.AddWithValue("@date",date);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed Connection" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private int idGen;

        private void IDGenerator()
        {
            using (SqlConnection connect = new SqlConnection("Server=localhost;Database=Inventory;Trusted_Connection=True;"))
            {
                connect.Open();

                string selectData = "SELECT MAX(customer_id) FROM customers";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int temp = Convert.ToInt32(result);

                        if (temp == 0)
                        {
                            idGen = 1;
                        }
                        else
                        {
                            idGen = temp + 1;
                        }
                    }
                    else
                    {
                        idGen = 1;
                    }
                }
            }
        }
    }
}