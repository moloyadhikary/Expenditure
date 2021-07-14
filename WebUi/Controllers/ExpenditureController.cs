using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUi.Controllers
{
    public class ExpenditureController : Controller
    {
        private ExpenditureBookDbEntities db;

        public ExpenditureController()
        {
            db = new ExpenditureBookDbEntities();
        }
       
        public ActionResult Create()
        {
            var itemTypes = db.ItemTypes.ToList();
            itemTypes.Add(new ItemType{Id = 0, Name = "Select Type"});
            ViewBag.ItemTypeList = new SelectList(itemTypes.OrderBy(d=>d.Id), "Id", "Name");
            
            return View();
        }
        
        [HttpPost]
        public JsonResult GetSubTypesByType(int typeId)
        {
            var subTypes = db.ItemSubTypes.Where(s => s.ItemTypeId == typeId).ToList();
            return Json(subTypes.Select(x => new
            {
                x.Id,
                x.Name
            }));
        }
    }
}