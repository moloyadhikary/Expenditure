using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebUi
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string UserName { get; set; }
        string UserFullName { get; set; }
    }

    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string userName)
        {
            this.Identity = new GenericIdentity(userName);
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
    }

    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
    }
}