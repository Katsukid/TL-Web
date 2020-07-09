using System.Web.Mvc;

namespace BookMVC.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] {"BookMVC.Areas.Admin.Controllers"} // khai bao them namespace de khong bi xung dot giua Area va main (cung voi file RouteConfig.cs)
            );
        }
    }
}