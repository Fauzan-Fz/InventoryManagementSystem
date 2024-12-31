using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            //DisplayCatecories()
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
            connect.Open();

            string selectData = "SELECT * FROM categories";

            using (SqlCommand cmd = new SqlCommand())
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(selectData, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox_Category.DataSource = dt;
                comboBox_Category.DisplayMember = "category";
                comboBox_Category.ValueMember = "id";
            }
            {
                connect.Close();
            }
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
            txtProductID.Text = "";
            txtProductName.Text = "";
            comboBox_Category.SelectedIndex = -1;
            txtPrice.Text = "";
            txtStock.Text = "";
            cbStatus.SelectedIndex = -1;
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

        private int getID = 0;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Empty Field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Update Product Id : " + txtProductID.Text.Trim() + " ?",
                                    "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    connect.Open();

                    string updateData = "UPDATE products SET prod_id = @prodID, prod_name = @prodName, " +
                                        "category = @ctg, price = @price, stock = @stock, status = @status WHERE id = @id";

                    using (SqlCommand updateD = new SqlCommand(updateData, connect))
                    {
                        updateD.Parameters.AddWithValue("@id", getID);
                        updateD.Parameters.AddWithValue("@prodID", txtProductID.Text.Trim());
                        updateD.Parameters.AddWithValue("@prodName", txtProductName.Text.Trim());
                        updateD.Parameters.AddWithValue("@ctg", comboBox_Category.Text);
                        updateD.Parameters.AddWithValue("@price", txtPrice.Text.Trim());
                        updateD.Parameters.AddWithValue("@stock", txtStock.Text.Trim());
                        updateD.Parameters.AddWithValue("@status", cbStatus.Text);

                        updateD.ExecuteNonQuery();
                        clearField();
                        displayAllProduct();

                        MessageBox.Show("Updated Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                connect.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                txtProductID.Text = row.Cells[1].Value.ToString();
                txtProductName.Text = row.Cells[2].Value.ToString();
                comboBox_Category.Text = row.Cells[3].Value.ToString();
                txtPrice.Text = row.Cells[4].Value.ToString();
                txtStock.Text = row.Cells[5].Value.ToString();
                string imagepath = row.Cells[6].Value.ToString();

                try
                {
                    if (imagepath != null)
                    {
                        PictureImport.Image = Image.FromFile(imagepath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Image" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cbStatus.Text = row.Cells[7].Value.ToString();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Empty Field", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Delete Product Id : " + txtProductID.Text.Trim() + " ?",
                                    "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    connect.Open();

                    string deleteData = "DELETE FROM products WHERE id = @id";

                    using (SqlCommand deleteD = new SqlCommand(deleteData, connect))
                    {
                        deleteD.Parameters.AddWithValue("@id", getID);

                        deleteD.ExecuteNonQuery();
                        clearField();
                        displayAllProduct();

                        MessageBox.Show("Deleted Succesfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                connect.Close();
            }
        }
    }
}