﻿using Microsoft.AspNetCore.Mvc;
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
       public static string connString = "Data Source= cpkruger.database.windows.net;Initial Catalog=FarmDB;User ID=ST1045492;Password=DoomsD@yDevice5";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        DataTable dt;
        SqlDataAdapter dbAdapter;

     
        public int accessgranted(User temp)
        {
            User us = temp;
            dbConn.Open();

            string sql = "SELECT * FROM User where Username = @Username and Password = @Password";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.Parameters.AddWithValue("@Username", us.Username1);
            dbComm.Parameters.AddWithValue("@Password", us.Password1);
            dbAdapter = new SqlDataAdapter(dbComm);
             dt = null;

            dbAdapter.Fill(dt);


            if (dt == null)
            {
                return 0;
            }
            else
                Product.products.AddRange(GetProductsByUsername(us.Username1));
                return 1;
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
        public IEnumerable<Product> GetProductsByUsernameAdmin(string username)
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
                    Username1 = reader["Username"].ToString(),
                    Name1 = reader["Name"].ToString(),
                    Category1 = reader["Category"].ToString(),
                    ProductionDate1 = reader["ProductionDate"].ToString()
                };


                products.Add(product);
            }

            return products;
        }
    }
}


