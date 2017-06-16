using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaptainMao
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Adoption",
            //    url: "{area}/{controller}/{action}/{id}",
            //    defaults: new { controller = "Adoption", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "CaptainMao.Areas.Adoption" }
            //    );
            routes.IgnoreRoute("{*botdetect}",
            new {botdetect=@"(.*)BotDetectCaptcha\.ashx"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CaptainMao", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
