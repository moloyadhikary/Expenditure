using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;

namespace WebUi.Controllers
{
    public class ConfigurationController : Controller
    {
        private ExpenditureBookDbEntities db;

        public ConfigurationController()
        {
            db = new ExpenditureBookDbEntities();
        }


        public ActionResult GetSubTypes()
        {
            var subTypes = db.ItemSubTypes.OrderBy(x=>x.Name).ToList();
            return View(subTypes);
        }

        public ActionResult AddSubType()
        {
            return View();
        }
    }
}