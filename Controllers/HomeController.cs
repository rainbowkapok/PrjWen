using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrjWen.Models;
using PrjWen.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;



namespace PrjWen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains(CSeactionClass.LoginUser))
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(CMemberViewModel cmv)
        {
            Member會員 Member = (new WenDBContext()).Member會員s.FirstOrDefault(m => m.Email信箱.Equals(cmv.txtEmail));
            if(Member != null)
            {
                if (Member.Password密碼==cmv.txtPassword)
                {
                    string JoinUser= JsonSerializer.Serialize(Member);
                    HttpContext.Session.SetString(CSeactionClass.LoginUser,JoinUser);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public ActionResult practice() 
        {
            return View();
        }
        public ActionResult practiceVueJs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
