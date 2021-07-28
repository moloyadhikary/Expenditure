﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;

namespace WebUi.Controllers
{
    public class HomeController : Controller
    {
        private ExpenditureBookDbEntities db;

        public HomeController()
        {
            db = new ExpenditureBookDbEntities();
        }
        
        public ActionResult Index()
        {
            var now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            
            var data = db.DataEntries.Where(x=>x.IsDeleted==false && x.DataDate >= startDate && x.DataDate <= endDate).ToList();
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}