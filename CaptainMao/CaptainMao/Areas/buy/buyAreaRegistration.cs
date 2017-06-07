using System.Web.Mvc;

namespace CaptainMao.Areas.buy
{
    public class buyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "buy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "buy_default",
                url: "buy/{controller}/{action}/{id}",
                defaults: new { controller="Shopping", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}