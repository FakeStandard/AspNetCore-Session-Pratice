using AspNetCore_Session_Pratice.Helpers;
using AspNetCore_Session_Pratice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Session_Pratice.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            // ex1
            HttpContext.Session.SetString("username", "測試人員");
            HttpContext.Session.SetInt32("age", 20);

            // ex2
            Member member = new Member
            {
                ID = 1,
                Name = "系統管理員",
                Level = "一級"
            };

            SessionHelper.SetObjectAsJson(HttpContext.Session, "member", member);

            // ex3
            List<Member> members = new List<Member>()
            {
                new Member
                {
                    ID=2,
                    Name="經理",
                    Level="二級"
                },
                new Member
                {
                    ID=3,
                    Name="副理",
                    Level="三級"
                },
                new Member
                {
                    ID=4,
                    Name="小職員",
                    Level="四級"
                }
            };

            SessionHelper.SetObjectAsJson(HttpContext.Session, "members", members);

            return View();
        }
    }
}
