using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PrjWen.Models;
using PrjWen.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjWen.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly WenDBContext _context;
        private IWebHostEnvironment _enviro;
        public CreditCardController(WenDBContext db, IWebHostEnvironment env)
        {
            _context = db;
            _enviro = env;
        }

        //public IActionResult Index()
        //{
        //    CreditView c = new CreditView();

        //    c.信用卡 = (from p in _context.CreditCard信用卡s
        //             select new MemberCredit
        //             {
        //                 Cid信用卡流水號 = p.Cid信用卡流水號,
        //                 Cname信用卡公司名 = p.Cname信用卡公司名,
        //                 Cnum信用卡號 = p.Cnum信用卡號
        //             }).ToList();
        //    return View(c);
        //}
        public IActionResult Index()
        {
            WenDBContext db = new WenDBContext();
            db.CreditCard信用卡s.ToList();
            List<credit> datas = null;
            datas = db.CreditCard信用卡s.Select(
                c => new credit
                {
                    CreditCard = c,
                }).ToList();
            return View(datas);
        }
        [HttpPost]
        public IActionResult Create(string CompanyName, string Num,bool Cstate)
        {
            CreditCard信用卡 C = new CreditCard信用卡();
            C.Cname信用卡公司名 = CompanyName;
            C.Cnum信用卡號 = Num;
            C.Cuse使用狀態 = Cstate;           
            _context.CreditCard信用卡s.Add(C);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
           WenDBContext db = new WenDBContext();
            credit datas = null;
            datas = db.CreditCard信用卡s.Where(c => c.Cid信用卡流水號 == id).Select
            (c => new credit
            {
                CreditCard = c,
            }).FirstOrDefault();

            return View(datas);
        }
        [HttpPost]
        public ActionResult Edit(credit x,bool Cstate)
        {
            CreditCard信用卡 datas = _context.CreditCard信用卡s.FirstOrDefault(c => c.Cid信用卡流水號 == x.Cid信用卡流水號);
            if (datas!=null)
            {
                datas.Cid信用卡流水號 = x.Cid信用卡流水號;
                datas.Cname信用卡公司名 = x.Cname信用卡公司名;
                datas.Cnum信用卡號 = x.Cnum信用卡號;
                datas.Cuse使用狀態 = Cstate;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? incid)
        {                       

            if (incid != null)
            {
                WenDBContext db = new WenDBContext();
                CreditCard信用卡 p = db.CreditCard信用卡s.FirstOrDefault(t => t.Cid信用卡流水號 == incid);
                if (p != null)
                {
                    db.CreditCard信用卡s.Remove(p);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
      
        public IActionResult JsonEdit(int? id)
        {        
            var query = _context.CreditCard信用卡s
                .Where(c => c.Cid信用卡流水號 == id)
                .Select(c => c);
            return Json(query);      
        }
        
    }
}
