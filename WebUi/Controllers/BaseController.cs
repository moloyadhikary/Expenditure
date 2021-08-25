using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;

namespace WebUi.Controllers
{
    public class BaseController : Controller
    {
        protected new CustomPrincipal User => HttpContext.User as CustomPrincipal;

        public ExpenditureBookDbEntities db;

        public BaseController()
        {
            db = new ExpenditureBookDbEntities();
        }
    }
}