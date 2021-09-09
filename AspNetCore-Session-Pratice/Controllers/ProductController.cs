using AspNetCore_Session_Pratice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Session_Pratice.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    ID=1,
                    Name="ASUSE410MA-0631WN4020 夢幻白14吋輕薄文書筆電",
                    Price=12900,
                    Photo="000001_1628754846.jpg"
                },
                new Product
                {
                    ID=2,
                    Name="LG 樂金 gram 16” 輕贏隨型 極致輕薄筆電 –曜石黑 (i7)－16Z90P-G",
                    Price=53900,
                    Photo="000001_1615281958.jpg"
                },
                new Product
                {
                    ID=3,
                    Name="dynabook 14吋筆電",
                    Price=19999,
                    Photo="000001_1628474318.jpg"
                }
            };

            ViewBag.products = products;

            return View();
        }
    }
}
