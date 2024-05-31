using System.Data.SqlClient;
using System.Reflection;

namespace ProgPoeFarmer31May.Models
{
    public class Product
    {
      public static List<Product> products = new List<Product>();



        int ProductID;
        int FarmerID;
        String Name;
        String Category;
        String ProductionRate;
        public Product() { }

        public Product(int productID, int farmerID, string name, string category, string productionRate)
        {
            ProductID1 = productID;
            FarmerID1 = farmerID;
            Name1 = name;
            Category1 = category;
            ProductionRate1 = productionRate;
        }

        public int ProductID1 { get => ProductID; set => ProductID = value; }
        public int FarmerID1 { get => FarmerID; set => FarmerID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Category1 { get => Category; set => Category = value; }
        public string ProductionRate1 { get => ProductionRate; set => ProductionRate = value; 
        } 

            public void Datafill() {
            

            string connectionString = "Data Source = localhost; Initial Catalog = PROGst10045492PART3; Integrated Security = True;";
            string query = "SELECT * FROM Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product obj = new Product
                    {
                        ProductID1 = Convert.ToInt32(reader["ProductID"]),
                        FarmerID1 = Convert.ToInt32(reader["FarmerID1"]),
                        Name1 = reader["Name"].ToString(),
                        Category1 = reader["Category"].ToString(),
                        ProductionRate1 = reader["ProductionRate"].ToString(),
                        // Populate other properties similarly
                    };

                    products.Add(obj);
                }
                
                reader.Close();
            }

        }
    }
}
