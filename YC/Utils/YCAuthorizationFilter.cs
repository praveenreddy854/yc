using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Configuration;

namespace YC.Utils
{
    public class YCAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string certThumPrint = ConfigurationManager.AppSettings["YCAuthCertThumbPrint"];
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, certThumPrint, true);

            if(certs.Count == 0)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}