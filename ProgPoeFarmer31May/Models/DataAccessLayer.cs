using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.CodeAnalysis;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ProgPoeFarmer31May.Models
{
    public class DataAccessLayer
    {
        public static string connString = "Data Source=cpkruger.database.windows.net;Initial Catalog=FarmDB;User ID=ST1045492;Password=DoomsD@yDevice5";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        DataTable dt;
        SqlDataAdapter dbAdapter;


        public int accessgranted(string username, string password)
        {
            
            foreach (var user in UserContext.users)
            {
                if (user.Username1 == username && user.Password1 == password)  // found the user
                {
                    if(user.Username1 == username && user.Password1 == password && user.Admin1 == "Y") //checking if their admin
                    {
                        return 2;
                    }

                    foreach (var prod in ProductContext.products)
                    {
                        if(prod.Username1 == username)
                        {
                            ProductContext.userproducts.Add(prod);
                        }
                    }
                    return 1;
                }
            }
            return 0;
        }


        public int accessgrantedAdmin(string username, string password)
        {

            foreach (var user in UserContext.users)
            {
                if (user.Username1 == username && user.Password1 == password && user.Admin1 == "Y")
                {
                    foreach (var prod in ProductContext.products)
                    {                        
                            ProductContext.userproducts.Add(prod);                       
                    }
                    return 1;
                }
            }           
            return 0;

        }
            public IEnumerable<Product> GetProductsByUsername(string username)
            {
                      List<Product> products = new List<Product>();


                  dbConn.Open();

                  string query = "SELECT * FROM Products WHERE Username = @Username";
                   dbComm = new SqlCommand(query, dbConn);
                   dbComm.Parameters.AddWithValue("@Username", username);

                   SqlDataReader reader = dbComm.ExecuteReader();

                   while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductID1 = int.Parse((string)reader["ProductID"]),
                            Name1 = reader["Name"].ToString(),
                            Category1 = reader["Category"].ToString(),
                            ProductionDate1 = reader["ProductionDate"].ToString()
                        };


                        products.Add(product);
                     }

                  return products;
             }

            public IEnumerable<Product> GetProductsByUsernameAdmin()
            {
                List<Product> products = new List<Product>();


                dbConn.Open();

                string query = "SELECT * FROM Products";
                dbComm = new SqlCommand(query, dbConn);


                SqlDataReader reader = dbComm.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID1 = int.Parse((string)reader["ProductID"]),
                        Username1 = reader["Username"].ToString(),
                        Name1 = reader["Name"].ToString(),
                        Category1 = reader["Category"].ToString(),
                        ProductionDate1 = reader["ProductionDate"].ToString()
                    };


                    products.Add(product);
                }

                return products;
            }
        public IEnumerable<User> GetUsersAdmin()
        {
            List<User> users = new List<User>();


            dbConn.Open();

            string query = "SELECT * FROM Users";
            dbComm = new SqlCommand(query, dbConn);


            SqlDataReader reader = dbComm.ExecuteReader();

            while (reader.Read())
            {
                User user = new User
                {
                    Username1 = reader["Username"].ToString(),
                    Password1 = reader["Password"].ToString(),
                    Admin1 = reader["Category"].ToString(),
                };


                users.Add(user);
            }

            return users;
        }  
    } 
}



