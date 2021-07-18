﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUi.Models.InputForms;

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
        public ActionResult Create(AddExpenditureInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var itemTypes = db.ItemTypes.ToList();
                itemTypes.Add(new ItemType{Id = 0, Name = "Select Type"});
                ViewBag.ItemTypeList = new SelectList(itemTypes.OrderBy(d=>d.Id), "Id", "Name");
                TempData["Message"] = "Form contains error. Please input properly";
                return View(model);
            }

            var data = new DataEntry();
            data.ItemTypeId = model.ItemTypeId;
            data.Amount = model.Amount;
            data.DataDate = Convert.ToDateTime(model.DataDate);
            data.EntryDate = DateTime.Now;
            data.IsDeleted = false;
            data.ItemSubTypeId = model.ItemSubTypeId;
            data.Remarks = model.Remarks;

            db.DataEntries.Add(data);
            db.SaveChanges();
            
            TempData["Message"] = $"Data saved successfully";
            return RedirectToAction("Index", "Home");
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