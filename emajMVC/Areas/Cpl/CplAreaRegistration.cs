using System.Web.Mvc;

namespace emajMVC.Areas.Cpl
{
    public class CplAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cpl";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Cpl_default",
                "Cpl/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { "emajMVC.Areas.Cpl.Controllers" }
            );
        }
    }
}