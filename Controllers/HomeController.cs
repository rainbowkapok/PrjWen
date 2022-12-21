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
        private readonly ILogger _logger;
        private readonly WenDBContext _dbcontext;

        public HomeController(ILogger<HomeController> logger,WenDBContext db)
        {
            _logger = logger;
            _dbcontext = db;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains(CSectionClass.LoginUser))
            {
                return RedirectToAction("Login");
            }
            //_logger.LogTrace("Loggin Level=0 (Trace)");
            //_logger.LogDebug("Loggin Level=1 (Debug)");
            //_logger.LogInformation("Loggin Level=2 (Information)");
            //_logger.LogWarning("Loggin Level=3 (Warning)");
            //_logger.LogError("Loggin Level=4 (Error)");
            //_logger.LogCritical("Loggin Level=5 (Critical)");
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(CMemberViewModel cmv)
        {
            //Member會員 Member = (new WenDBContext()).Member會員s.FirstOrDefault(m => m.Email信箱.Equals(cmv.txtEmail));
            Member會員 Member = _dbcontext.Member會員s.FirstOrDefault(m => m.Email信箱.Equals(cmv.txtEmail));
            if(Member != null)
            {
                if (Member.Password密碼==cmv.txtPassword)
                {
                    string JoinUser= JsonSerializer.Serialize(Member);
                    HttpContext.Session.SetString(CSectionClass.LoginUser,JoinUser);
                    _logger.LogInformation("success"+"登入時間:"+DateTime.Now.ToString()+Member.Name會員名稱);
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
