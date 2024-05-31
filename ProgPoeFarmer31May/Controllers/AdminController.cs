using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgPoeFarmer31May.Models;
using System.Data.SqlClient;

namespace ProgPoeFarmer31May.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult List()
        {
            return View(Product.products);
        }
        public ActionResult ProductEdit(int id)
        {
            return View();
        }
        // GET: AdminController/Delete/5
        public ActionResult ProductDelete(int id)
        {
            return View();
        }
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: LoginController/Create
        
        public ActionResult UserList()
        {
            return View();
        }
       

        // GET: AdminController/Create
        public ActionResult UserCreate()
        {
            return View();
        }
         public ActionResult UserDelete()
         {
            return View();
         }
        // GET: AdminController/Edit/5
        public ActionResult UserEdit(int id)
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserCreate(User temp)
        {
            User us = temp;
            if (us.Username1 == null || us.Password1 == null || us.Admin1 == null)
            {
                ViewBag.Error = "Please enter all the fields";
                return View();
            }
            else
            {

                string connectionString = DataAccessLayer.connString;
                string insertQuery = "INSERT INTO Users (Username, Password, Admin) VALUES (@Value1, @Value2, @Value3)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(insertQuery, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("@Value1", us.Username1);
                    command.Parameters.AddWithValue("@Value2", us.Password1);
                    command.Parameters.AddWithValue("@Value3", us.Admin1);



                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return RedirectToAction("Login");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product temp)
        {
            Product p = temp;
            if (p.Name1 == null || p.Category1 == null || p.ProductionDate1 == null)
            {
                ViewBag.Error = "Please enter all the fields";
                return View();
            }
            else
            {

                string connectionString = DataAccessLayer.connString;
                string insertQuery = "INSERT INTO Products (Name, Category, ProductionDate) VALUES (@Value1, @Value2, @Value3)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(insertQuery, connection);

                    // Add parameters
                    command.Parameters.AddWithValue("@Value1", p.Name1);
                    command.Parameters.AddWithValue("@Value2", p.Category1);
                    command.Parameters.AddWithValue("@Value3", p.ProductionDate1);



                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return RedirectToAction("List");
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserDelete(User temp)
        {
            User u = temp;

            string connectionString = DataAccessLayer.connString;
            string updateQuery = "DELETE FROM Users WHERE Username = @NewValue1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Add parameters for new values
                command.Parameters.AddWithValue("@NewValue1", u.Username1);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            return View();
        }

        

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(User u)
        {
            User data = u;
            if (u.Username1 == null ||u.Password1 == null || u.Admin1 == null)
            {
                ViewBag.Error = "No data in list";
                return View();
            }
            else
            {// add data query here                     
                string connectionString = DataAccessLayer.connString;
                string updateQuery = "UPDATE Admin SET Username = @NewValue1, Password = @NewValue2 , Admin = @NewValue3";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(updateQuery, connection);

                    // Add parameters for new values
                    command.Parameters.AddWithValue("@NewValue1", u.Username1);
                    command.Parameters.AddWithValue("@NewValue2", u.Password1);
                    command.Parameters.AddWithValue("@NewValue3", u.Admin1);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }

                return RedirectToAction("UserList");
            }
        }
        

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Productedit(Product p)
        {
            Product data = p;
            if (p.Name1 == null || p.Category1 == null || p.ProductionDate1 == null)
            {
                ViewBag.Error = "No data in list";
                return View();
            }
            else
            {// add data query here                     
                string connectionString = DataAccessLayer.connString;
                string updateQuery = "UPDATE Products SET Name = @NewValue1, Category = @NewValue2 , ProductionDate = @NewValue3";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(updateQuery, connection);

                    // Add parameters for new values
                    command.Parameters.AddWithValue("@NewValue1", p.Name1);
                    command.Parameters.AddWithValue("@NewValue2", p.Category1);
                    command.Parameters.AddWithValue("@NewValue3", p.ProductionDate1);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }

                return RedirectToAction("Index");
            }
        }

        

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductDelete(Product temp)
        {
            Product p = temp;

            string connectionString = DataAccessLayer.connString;
            string updateQuery = "DELETE FROM Products WHERE ProductID = @NewValue1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Add parameters for new values
                command.Parameters.AddWithValue("@NewValue1", p.ProductID1);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            return View();
        }
    }
}
