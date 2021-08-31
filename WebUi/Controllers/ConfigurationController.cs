using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using WebUi.Models.InputForms;

namespace WebUi.Controllers
{
    [Authorize]
    public class ConfigurationController : BaseController
    {
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

        [HttpGet]
        [Authorize]
        public ActionResult EditSubType(int id)
        {
            var subType = db.ItemSubTypes.FirstOrDefault(x => x.Id == id);
            var model = new EditItemSubTypeModel();
            model.Id = subType.Id;
            model.Description = subType.Description;
            model.ItemTypeId = subType.ItemTypeId;
            model.Name = subType.Name;
            
            var itemTypes = db.ItemTypes.ToList();
            ViewBag.ItemTypeList = new SelectList(itemTypes, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditSubType(EditItemSubTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = db.ItemSubTypes.FirstOrDefault(x => x.Id == model.Id);
                dbModel.Name = model.Name;
                dbModel.Description = model.Description;
                dbModel.ItemTypeId = model.ItemTypeId;
                
                db.ItemSubTypes.AddOrUpdate(dbModel);
                db.SaveChanges();
                
                TempData["Message"] = $"Sub type {model.Name} updated successfully";
            }

            return RedirectToAction(nameof(GetSubTypes));
        }
    }
}