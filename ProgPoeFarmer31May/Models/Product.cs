using System.Data.SqlClient;
using System.Reflection;

namespace ProgPoeFarmer31May.Models
{
    public class Product
    {
     



        int ProductID;
        String Username;
        String Name;
        String Category;
        String ProductionDate;
        public Product() { }

        public Product(int productID, string username, string name, string category, string productionDate)
        {
            ProductID1 = productID;
            Username1 = username;
            Name1 = name;
            Category1 = category;
            ProductionDate1 = productionDate;
        }

        public int ProductID1 { get => ProductID; set => ProductID = value; }
        public String Username1 { get => Username; set => Username = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Category1 { get => Category; set => Category = value; }
        public string ProductionDate1 { get => ProductionDate; set => ProductionDate = value; 
        } 

            
    }
}
