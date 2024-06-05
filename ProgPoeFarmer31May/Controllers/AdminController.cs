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
            return View(ProductContext.products);
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
            return View(UserContext.users);
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
        public IActionResult UserCreate(User temp)
        {
            User s = temp;
            if (s.Username1 == null ||
                s.Password1 == null ||
                s.Admin1 == null)
            {
                ViewBag.Error = "Please enter all the fields";
                return View("Create");
            }
            else
            {
                int i = 0;
                foreach (var user in UserContext.users)
                {
                    if (s.Username1 == user.Username1)
                    {
                        i = 1;

                    }
                }
                if (i == 1)
                {
                    ViewBag.Message = "User already taken";
                    return View("Create");
                }

            }

            UserContext.users.Add(s);
            return RedirectToAction("List");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product temp)  //Creating a product
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
        public IActionResult UserDelete(int id)
        {
            try
            {


                foreach (var usr in UserContext.users)
                {
                    if (id.Equals(usr.Username1))
                    {
                        UserContext.users.Remove(usr);                     
                    }
                }

                return RedirectToAction("UserList");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return View("List");


        }



        // POST: AdminController/Edit/5
        [HttpPost]
        public IActionResult UserEdit(User temp)
        {

            User u = temp;
            
            foreach (var usr in UserContext.users)
            {
                if (u.Username1.Equals(usr.Username1))
                {
                    usr.Username1 = u.Username1;
                    usr.Password1 = u.Password1;
                    usr.Admin1 = u.Admin1;                                      
                }
                
            }
            return RedirectToAction("UserList");
        }


        // POST: AdminController/Edit/5
        [HttpPost]
        public IActionResult ProductEdit(Product temp)
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
                i = i + 1;
            }
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
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return View("List");


        }

        // POST: AdminController/Delete/5

    }
}
