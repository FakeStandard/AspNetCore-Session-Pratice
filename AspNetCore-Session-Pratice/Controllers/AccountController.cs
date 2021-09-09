using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Session_Pratice.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("admin") && password.Equals("1234"))
            {
                HttpContext.Session.SetString("username", username);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.error = "Invalid Account.";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            // or clear all
            //HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
