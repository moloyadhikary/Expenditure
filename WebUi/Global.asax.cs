using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace WebUi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie ebAuthTicket = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (ebAuthTicket != null)
            {
                FormsAuthenticationTicket ksAuth = FormsAuthentication.Decrypt(ebAuthTicket.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(ksAuth.UserData);

                CustomPrincipal newUser = new CustomPrincipal(ksAuth.Name);
                newUser.Id = serializeModel.Id;
                newUser.UserName = Convert.ToString(serializeModel.UserName);
                newUser.UserFullName = Convert.ToString(serializeModel.UserFullName);

                HttpContext.Current.User = newUser;
            }
        }
        
        
    }
}
