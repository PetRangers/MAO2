using System.Web.Mvc;

namespace CaptainMao.Areas.Adoption
{
    public class AdoptionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Adoption";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Adoption_default",
                "Adoption/{controller}/{action}/{id}",
                new { controller="Action", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}