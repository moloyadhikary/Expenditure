using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using WebUi.Models.InputForms;

namespace WebUi.Controllers
{
    [Authorize]
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
            var itemTypes = db.ItemTypes.ToList();
            ViewBag.ItemTypeList = new SelectList(itemTypes, "Id", "Name");
            
            return View();
        }

        [HttpPost]
        public ActionResult AddSubType(AddSubTypeInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                TempData["Message"] = "Provide Sub Type Name";
                return RedirectToAction(nameof(AddSubType));
            }

            var subType = new ItemSubType();
            subType.Name = model.Name;
            subType.Description = model.Description;
            subType.ItemTypeId = model.ItemTypeId;

            db.ItemSubTypes.Add(subType);
            db.SaveChanges();

            TempData["Message"] = $"Sub type {model.Name} saved successfully";
            return RedirectToAction(nameof(GetSubTypes));
        }
    }
}