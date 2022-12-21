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
using PrjWen;
using NLog;

namespace PrjWen.Controllers
{
    public class HomeController : Controller
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly WenDBContext _dbcontext;

        public HomeController(ILogger<HomeController> logger,WenDBContext db)
        {
            _logger = logger;
            _dbcontext = db;
        }

        public IActionResult Index()
        {
            //Utility utiliy = new Utility();
            //_logger.LogInformation("Test");
            //utiliy.Logger("Test");
            
            if (!HttpContext.Session.Keys.Contains(CSectionClass.LoginUser))
            {
                return RedirectToAction("Login");
            }
            #region
            // Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6.
            //Trace - 最常見的記錄資訊，一般用於普通輸出
            //Debug - 同樣是記錄資訊，不過出現的頻率要比Trace少一些，一般用來除錯程式
            //Info - 資訊型別的訊息
            //Warn - 警告資訊，一般用於比較重要的場合
            //Error - 錯誤資訊e
            //Fatal - 致命異常資訊。一般來講，發生致命異常之後程式將無法繼續執行。
            //自上而下，等級遞增。

            //_logger.LogTrace("Loggin Level=0 (Trace)");
            //_logger.LogDebug("Loggin Level=1 (Debug)");
            //_logger.LogInformation("Loggin Level=2 (Information)");
            //_logger.LogWarning("Loggin Level=3 (Warning)");
            //_logger.LogError("Loggin Level=4 (Error)");
            //_logger.LogCritical("Loggin Level=5 (Critical)");
            #endregion
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        public string name;
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
                    name = Member.Name會員名稱;
                    _logger.LogWarning("這是溫馨小提醒(Warning)," + "Hi" + Member.Name會員名稱 + "已登入囉!");
                    //LogEventInfo theEvent = new LogEventInfo(NLog.LogLevel.Info);                    
                    return RedirectToAction("Index");
                }
            }
            return View();
            //${event-properties}
            //Logger log = LogManager.GetCurrentClassLogger();
            //LogEventInfo theEvent = new LogEventInfo(LogLevel.Debug, "", "Pass my custom value");
            //theEvent.Properties["MyValue"] = "My custom string";
            //deprecated
            //theEvent.Context["TheAnswer"] = 42;
            //log.Log(theEvent);
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
