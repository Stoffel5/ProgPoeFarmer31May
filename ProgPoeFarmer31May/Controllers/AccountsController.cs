using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ProgPoeFarmer31May.Models;
using System.Data.SqlClient;

namespace ProgPoeFarmer31May.Controllers
{
    public class AccountsController : Controller
    {
        ProductContext initiatesarray = new ProductContext();
        UserContext InitiatesArray = new UserContext();

        DataAccessLayer da = new DataAccessLayer();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User temp)
        {
            User s = temp;
            if (s.Username1 == null ||
                s.Password1 == null )
            {
                ViewBag.Error = "Please enter all the fields";
                return View("Create");
            }
            else
            {
                int i = 0;
                foreach ( var user in UserContext.users)
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
                return RedirectToAction("Login");
            

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
            int i = da.accessgranted(us.Username1,us.Password1);
            if (i == 2)
            {
                return RedirectToAction("List", "Admin");
            }
            else if(i == 1)
            {
                return RedirectToAction("List", "UserPage");
            }
            else
            {
                ViewBag.Name("This user does not exist");
                return RedirectToAction("Login");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminLogin(User temp)
        {
            User us = temp;
            int i = da.accessgrantedAdmin(us.Username1, us.Password1);
            if (i == 1)
            {
                return RedirectToAction("List", "Admin");
            }
            else
            {
                
                return RedirectToAction("Login");
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
