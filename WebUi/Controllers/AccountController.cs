using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using BusinessObject;
using WebUi.Models.InputForms;

namespace WebUi.Controllers
{
    public class AccountController : BaseController
    {

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.UserDatas.FirstOrDefault(x => x.UserName == model.UserName && x.UserPassword == model.Password);
                if (user == null)
                {
                    TempData["Message"] = "Invalid Username or password";
                    return View(model);
                }
                
                //Authentication Code Starts from Here
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                serializeModel.Id = user.Id;
                serializeModel.UserName = user.UserName;
                serializeModel.UserFullName = user.UserFullName;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string userData = serializer.Serialize(serializeModel);

                FormsAuthenticationTicket ebAuthTicket = new FormsAuthenticationTicket(
                         1,
                         model.UserName,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(60),
                         false,
                         userData);

                string encTicket = FormsAuthentication.Encrypt(ebAuthTicket);
                HttpCookie ebCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(ebCookie);
                    
                //Authentication ends here

                return RedirectToAction("Index", "Home");
            }
            
            TempData["Message"] = "Form contains error. Please input properly";
            return View(model);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Items.Clear();
            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Id;
                var userData = db.UserDatas.FirstOrDefault(u => u.Id == userId);
                if (userData.UserPassword != model.CurrentPassword)
                {
                    TempData["Message"] = "Incorrect current Password";
                    return View();
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    TempData["Message"] = "New passwords didn't match";
                    return View();
                }

                userData.UserPassword = model.NewPassword;
                db.SaveChanges();
                
                TempData["Message"] = "Password changed successfully";
                return RedirectToAction("Index","Home");
            }
            
            TempData["Message"] = "Form contains error. Please input properly";
            return View();
        }
    }
}