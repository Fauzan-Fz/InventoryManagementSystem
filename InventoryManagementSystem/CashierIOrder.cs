using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class CashierIOrder : UserControl
    {
        public CashierIOrder()
        {
            InitializeComponent();
            displayAllAvailableProducts();
        }

        public void displayAllAvailableProducts()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listdata = apData.AllProductsData();

            dataGridView1.DataSource = listdata;
        }
    }
}
