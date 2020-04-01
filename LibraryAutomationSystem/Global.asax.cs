using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System;
using LibraryAutomationSystem.App_Start;

namespace LibraryAutomationSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilter(GlobalFilters.Filters);
            App_Start.MapConfig.Mapper();

        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }
    }
    public class FilterConfig
    {
        public static void RegisterGlobalFilter(GlobalFilterCollection globallFilterCollection)
        {
            globallFilterCollection.Add(new CustomExceptionFilter());
        }
    }

}
