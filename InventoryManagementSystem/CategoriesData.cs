using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    internal class CategoriesData
    {
        public int id { set; get; }
        public string category { set; get; }
        public string date { set; get; }

        public List<CategoriesData> AllCategoriesData()
        {
            List<CategoriesData> listdata = new List<CategoriesData>();

            using (SqlConnection connect = new SqlConnection("Server=localhost;Database=Inventory;Trusted_Connection=True;"))
            {
                connect.Open();

                string selectData = "SELECT * FROM categories";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CategoriesData cData = new CategoriesData();
                        cData.id = (int)reader["id"];
                        cData.category = reader["category"].ToString();
                        cData.date = reader["date"].ToString();

                        listdata.Add(cData);
                    }
                }
            }
            return listdata;
        }
    }
}
    

