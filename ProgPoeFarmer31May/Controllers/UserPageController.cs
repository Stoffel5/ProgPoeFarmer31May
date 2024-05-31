using Microsoft.AspNetCore.Mvc;
using ProgPoeFarmer31May.Models;
using System.Data.SqlClient;
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

            //datafill area
            p.Datafill();

            //space

           // return View();
        }
    }
}
