using AspNetCore_Session_Pratice.Helpers;
using AspNetCore_Session_Pratice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Session_Pratice.Controllers
{
    public class CartController : Controller
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

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);

            return View();
        }


        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();

                cart.Add(new Item
                {
                    Product = products.Find(c => c.ID == id),
                    Quantity = 1
                });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

                int index = IsExist(id);

                if (index != -1)
                    cart[index].Quantity++;
                else
                    cart.Add(new Item
                    {
                        Product = products.Find(c => c.ID == id),
                        Quantity = 1
                    });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return View("Index");
        }

        private int IsExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ID == id)
                    return i;
            }

            return -1;
        }
    }
}
