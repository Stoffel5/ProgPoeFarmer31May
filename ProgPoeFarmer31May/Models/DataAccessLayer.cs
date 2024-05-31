using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace ProgPoeFarmer31May.Models
{
    public class DataAccessLayer
    {
        static string connString = "Data Source = localhost; Initial Catalog = PROGst10045492PART3; Integrated Security = True;";
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
            {           //work further from here. I did everything before. Good luck bro, love you
                sql = "UPDATE User " +
           "set Active = '1' " +
           "WHERE Username = @Username and Password = @Password";
                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@Username", us.Username1);
                dbComm.Parameters.AddWithValue("@Password", us.Password1);

                dbComm.ExecuteNonQuery();
                dbConn.Close();


                return 1;
            }
        }
        public void LoadModuleArray()
        {
            Product p = new Product();

            string connectionString = connString;
            string query = "SELECT * FROM Products";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string data = reader.GetString(0);
                    p.products.Add(data);
                }

                reader.Close();
            }
        }
    }
}

