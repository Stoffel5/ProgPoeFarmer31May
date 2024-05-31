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
            int i = da.accessgranted(us.Username1,us.Password1);
            if (i == 1)
            {
                return RedirectToAction("List", "Userpage");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminLogin(User temp)
        {
            User us = temp;
            int i = da.accessgrantedAdmin(us.Username1, us.Password1);
            if (i == 1)
            {
                return RedirectToAction("List", "Userpage");
            }
            else
            {
                ViewBag.Error("This user does not exist");
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
