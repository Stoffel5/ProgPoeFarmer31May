﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
