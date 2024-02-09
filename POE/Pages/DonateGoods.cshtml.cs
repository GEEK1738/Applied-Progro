using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace POE.Pages
{
    public class DonateGoodsModel : PageModel
    {
        public List<DonateGoodsModel> GoodsList { get; set; }

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=server2030.database.windows.net;Initial Catalog=applied-prog;User ID=ST10098414@rcconnect.edu.za;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; // Replace with your connection string

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM DonateGoods";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            GoodsList = new List<DonateGoodsModel>();

                            while (reader.Read())
                            {
                                DonateGoodsModel goods = new DonateGoodsModel
                                {
                                    Name = reader.GetString(1),
                                    Clothes = reader.GetString(2),
                                    Food = reader.GetString(3),
                                    SelectAll = reader.GetString(4),
                                    Tentacles = reader.GetInt32(5) // Correct the index if needed
                                };

                                GoodsList.Add(goods);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
            }
        }

        // Define properties for your model
        public string Name { get; set; }
        public string Clothes { get; set; }
        public string Food { get; set; }
        public string SelectAll { get; set; }
        public int Tentacles { get; set; }
    }
}

