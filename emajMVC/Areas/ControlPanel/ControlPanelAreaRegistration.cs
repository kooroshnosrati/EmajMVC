using System.Web.Mvc;

namespace emajMVC.Areas.ControlPanel
{
    public class ControlPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ControlPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ControlPanel_default",
                "ControlPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "emajMVC.Areas.ControlPanel.Controllers" }
            );
        }
    }
}