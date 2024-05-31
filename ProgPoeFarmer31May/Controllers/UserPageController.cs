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
            User us = temp;
            Product p = new Product();
            int i = da.accessgranted(us);
            if (i == 1)
            {
                return View();
            }
            else
            {
                return ViewBag.Error("This user does not exist");
                
            }

           
        }
        //public IActionResult Edit()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult edit(Module mo)
        //{
        //    Module data = mo;
        //    if (mo.Code1 == null || mo.Name1 == null || mo.Credit1 == null || mo.ClassHours1 == null || mo.NumOfWeeks1 == null || mo.SelfStudyHours1 == null || mo.StudID1 == null)
        //    {
        //        ViewBag.Error = "No data in list";
        //        return View();
        //    }
        //    else
        //    {// add data query here
        //        (from p in Module.modules
        //         where p.Code1 == mo.Code1
        //         select p).ToList().ForEach(x =>
        //         {
        //             x.Name1 = mo.Name1;
        //             x.Credit1 = mo.Credit1;
        //             x.ClassHours1 = mo.ClassHours1;
        //             x.NumOfWeeks1 = mo.NumOfWeeks1;
        //             x.SelfStudyHours1 = mo.SelfStudyHours1;
        //             x.StudID1 = mo.StudID1;

        //             string connectionString = "Data Source = localhost; Initial Catalog = PROGst10045492PART3; Integrated Security = True";
        //             string updateQuery = "UPDATE Module SET Name = @NewValue1, Credit = @NewValue2 , ClassHours = @NewValue3, NumOfWeeks = @NewValue4, SelfStudyHours = @NewValue5, StudID = @NewValue6 WHERE Code = @Code";

        //             using (SqlConnection connection = new SqlConnection(connectionString))
        //             {
        //                 SqlCommand command = new SqlCommand(updateQuery, connection);

        //                 // Add parameters for new values
        //                 command.Parameters.AddWithValue("@NewValue1", mo.Name1);
        //                 command.Parameters.AddWithValue("@NewValue2", mo.Credit1);
        //                 command.Parameters.AddWithValue("@NewValue3", mo.ClassHours1);
        //                 command.Parameters.AddWithValue("@NewValue4", mo.NumOfWeeks1);
        //                 command.Parameters.AddWithValue("@NewValue5", mo.SelfStudyHours1);
        //                 command.Parameters.AddWithValue("@NewValue6", mo.StudID1);
        //                 command.Parameters.AddWithValue("@Code", mo.Code1);
        //                 connection.Open();
        //                 int rowsAffected = command.ExecuteNonQuery();
        //                 connection.Close();
        //             }
        //         });
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}
