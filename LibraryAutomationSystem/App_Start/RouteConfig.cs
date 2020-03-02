
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryAutomationSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
                name:"Library",
                url:" LibraryAutomationSystem /{ action}",
                defaults:new {controller="LibraryAutomationSystem",action= "ViewUser",id=UrlParameter.Optional}
                );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "HomeLAS", action = "Home", id = UrlParameter.Optional }
           );
        }
    }
}
