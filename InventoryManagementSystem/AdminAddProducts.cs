using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace InventoryManagementSystem
{

    public partial class AdminAddProducts : UserControl
    {

        SqlConnection
            connect = new SqlConnection("Server=localhost;Database=Inventory;Trusted_Connection=True;");

        public AdminAddProducts()
        {
            InitializeComponent();
            DisplayCatecories();
            displayAllProduct();
        }

        private void AdminAddProducts_Load(object sender, EventArgs e)
        {
            //DisplayCatecories();
        }

        public void displayAllProduct()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listData = apData.AllProductsData();

            dataGridView1.DataSource = listData;
        }

        public bool emptyFields()
        {
            if (txtProductID.Text == "" || txtProductName.Text == "" || comboBox_Category.SelectedIndex == -1 || txtPrice.Text == "" || txtStock.Text == "" || cbStatus.SelectedIndex == -1 || PictureImport.Image == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DisplayCatecories()
        {
            //if (checkConnection())
            //{
            //try
            //{
            connect.Open();

            string selectData = "SELECT * FROM categories";

            using (SqlCommand cmd = new SqlCommand())
            {
                //SqlDataReader reader = cmd.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {
                //        comboBox_Category.Items.Add(reader["category"].ToString());
                //    }
                //}

                SqlDataAdapter adapter = new SqlDataAdapter(selectData, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox_Category.DataSource = dt;
                comboBox_Category.DisplayMember = "category";
                comboBox_Category.ValueMember = "id";
            }
            //}
            //catch (Exception ex)
            //{
            //MessageBox.Show("Connection Failed" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            {
                connect.Close();
            }
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (emptyFields())
            {
                MessageBox.Show("Empty Field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                connect.Open();

                string selectData = "SELECT * FROM products WHERE prod_id = @prodID";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@prodID", txtProductID.Text.Trim());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        MessageBox.Show("Product ID : " + txtProductID.Text.Trim() + " Is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                        string relativePath = Path.Combine("Product_Directory", txtProductID.Text.Trim() + ".jpg");
                        string path = Path.Combine(baseDirectory, relativePath);

                        string directoryPath = Path.GetDirectoryName(path);

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        File.Copy(PictureImport.ImageLocation, path, true);

                        string insertData = "INSERT INTO products (prod_id,prod_name,category,price,stock,image_path,status,date_insert) " +
                                            "VALUES(@prodID,@prodName,@ctg,@price,@stock,@path,@status,@date)";

                        using (SqlCommand InsertData = new SqlCommand(insertData, connect))
                        {
                            InsertData.Parameters.AddWithValue("@prodID", txtProductID.Text.Trim());
                            InsertData.Parameters.AddWithValue("@prodName", txtProductName.Text.Trim());
                            InsertData.Parameters.AddWithValue("@ctg", comboBox_Category.Text);
                            InsertData.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
                            InsertData.Parameters.AddWithValue("@stock", txtStock.Text.Trim());
                            InsertData.Parameters.AddWithValue("@path", path);
                            InsertData.Parameters.AddWithValue("@status", cbStatus.Text);

                            DateTime date = DateTime.Today;
                            InsertData.Parameters.AddWithValue("@date", date);

                            InsertData.ExecuteNonQuery();
                            clearField();
                            displayAllProduct();

                            MessageBox.Show("Added Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                connect.Close();
            }
        }

        public void clearField()
        {
            txtProductID.Text = "" ;
            txtProductName.Text = "";
            comboBox_Category.SelectedIndex = -1 ;
            txtPrice.Text = "";
            txtStock.Text = "";
            cbStatus.SelectedIndex = -1 ;
            PictureImport.Image = null;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png) | *.jpg;*.png";
                string imagePath = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    PictureImport.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();
        }
    }
}
