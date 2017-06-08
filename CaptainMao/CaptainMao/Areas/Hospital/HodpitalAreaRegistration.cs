using System.Web.Mvc;

namespace CaptainMao.Areas.Hospital
{
    public class HodpitalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Hospital";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Hodpital_default",
                "Hospital/{controller}/{action}/{id}",
                new { controller = "Hospital", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}