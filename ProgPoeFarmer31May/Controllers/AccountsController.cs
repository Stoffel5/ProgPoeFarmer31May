using Microsoft.AspNetCore.Mvc;
using ProgPoeFarmer31May.Models;

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
                return View();
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
            return View(temp);
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
