using Microsoft.AspNetCore.Mvc;
using ProgPoeFarmer31May.Models;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace ProgPoeFarmer31May.Controllers
{
    public class UserPageController : Controller
    {

        DataAccessLayer da = new DataAccessLayer();
        public IActionResult List()
        {

            //space
            
            return View(Product.products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult List(User temp)
        {
           
                return View();          
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product temp)
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
        public ActionResult Create()
        {
            return View();
        }

        
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult edit(Product p)
        {
            Product data = p;
            if (p.Name1 == null || p.Category1 == null || p.ProductionDate1 == null )
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
    }
}
