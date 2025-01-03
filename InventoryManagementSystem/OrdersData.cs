using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    internal class OrdersData
    {
        SqlConnection
            connect = new SqlConnection("Server=localhost;Database=Inventory;Trusted_Connection=True;");

        public int ID { set; get; }
        public string CID { set; get; }
        public string PID { set; get; }
        public string PName { set; get; }
        public string Category { set; get; }
        public string OrigPrice { set; get; }
        public string QTY { set; get; }
        public string TotalPrice { set; get; }
        public string Date { set; get; }


        public List<OrdersData> allOrdersData()
        {
            List<OrdersData> listData = new List<OrdersData>();

            try
            {
                connect.Open();

                int custID = 0;
                string selectCustData = "SELECT MAX(customers_id) FROM orders";

                using (SqlCommand cmd = new SqlCommand(selectCustData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int temp = Convert.ToInt32(result);

                        if (temp == 0)
                        {
                            custID = 1;
                        }
                        else
                        {
                            custID = temp;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error ID");
                    }
                }

                string selectData = "SELECT * FROM orders WHERE customers_id = @cID";

                using (SqlCommand selectD = new SqlCommand(@selectData, connect))
                {
                    selectD.Parameters.AddWithValue("@cID", custID);

                    SqlDataReader reader = selectD.ExecuteReader();

                    while (reader.Read())
                    {
                        OrdersData oData = new OrdersData();

                        oData.ID = (int)reader["id"];
                        oData.CID = reader["customers_id"].ToString();
                        oData.PID = reader["prod_id"].ToString();
                        oData.PName = reader["prod_name"].ToString();
                        oData.Category = reader["category"].ToString();
                        oData.OrigPrice = reader["orig_price"].ToString();
                        oData.QTY = reader["qty"].ToString();
                        oData.TotalPrice = reader["total_price"].ToString();
                        oData.Date = reader["order_date"].ToString();

                        listData.Add(oData);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connect.Close();
            }
            return listData;
        }
    }
}
