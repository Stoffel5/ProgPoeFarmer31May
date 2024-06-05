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
            
            return View(ProductContext.userproducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult List(User temp)
        {
           
                return View();          
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
       
        public IActionResult Delete()
        {
            return View();
        }
       
        

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult edit(Product temp)
        {
           
            Product p = temp;

            int i = 0;
            foreach (var prod in ProductContext.products)
            {
                if (p.ProductID1.Equals(prod.ProductID1))
                {
                    prod.Name1 = p.Name1;
                    prod.Category1 = p.Category1;
                    prod.ProductionDate1 = p.ProductionDate1;
                    ProductContext.products[i] = prod;
                    ProductContext.userproducts[i] = prod;
                }
                i= i+1;
            }


         
            return RedirectToAction("List");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product temp)  //Creating a product
        {
            Product p = temp;

            int id = 1;
            foreach (var prod in ProductContext.products)
            {
                id = id + 1;
            }


            p.ProductID1 = id;
            p.Username1 = ProductContext.userproducts[0].Username1;


            ProductContext.products.Add(p);
            ProductContext.userproducts.Add(p);
            return RedirectToAction("List");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {               


                foreach (var prod in ProductContext.products)
                {
                    if (id.Equals(prod.ProductID1))
                    {
                        ProductContext.products.Remove(prod);
                        ProductContext.userproducts.Remove(prod);
                    }
                }

                return RedirectToAction("List");
            }catch (Exception ex)
            {
                ViewBag.Error=ex.Message;

            }
            return View("List");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout(Product temp) //logout and clear
        {
            ProductContext.userproducts.Clear();
            return RedirectToAction("Login", "Accounts");
        }
    }
}
