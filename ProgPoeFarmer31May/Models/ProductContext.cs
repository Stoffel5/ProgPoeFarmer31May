using Elfie.Serialization;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProgPoeFarmer31May.Models
{
    public class ProductContext
    {
        public static List<Product> products = new List<Product>();

        public ProductContext()
        {
            if (products.Count == 0)
            {
                string connectionString = "Data Source = localhost; Initial Catalog = PROGst10045492PART3; Integrated Security = True;" ;
                string query = "SELECT * FROM Products";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string data = reader.GetString(0);
                        string[] parts = data.Split(' ');


                        Product p = new Product();
                        p.ProductID1 = int.Parse(parts[1]);
                        p.FarmerID1 = int.Parse(parts[2]);
                        p.Name1 = parts[3];
                        p.Category1 = parts[4];
                        p.ProductionRate1 = parts[5];


                        ProductContext.products.Add(p);
                    }

                    reader.Close();
                }
            }
        }
    }
}
