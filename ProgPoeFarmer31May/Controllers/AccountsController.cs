using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ProgPoeFarmer31May.Models;
using System.Data.SqlClient;

namespace ProgPoeFarmer31May.Controllers
{
    public class AccountsController : Controller
    {
        DataAccessLayer da = new DataAccessLayer();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User temp)
        {
            User us = temp;
            int i = da.accessgranted(us);
            if (i == 1)
            {
                return View();
            }
            else
            {
                ViewBag.Error("This user does not exist");
                return RedirectToAction("Login");
            }
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User temp)
        {
            User us = temp;
            if ( us.Username1 == null || us.Password1 == null)
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
                    command.Parameters.AddWithValue("@Value3", "No");
                    


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return RedirectToAction("Login");
                }
            }
        }
        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
