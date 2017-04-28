using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
 
namespace DigisensePlatformAPIs
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           // log4net.Config.XmlConfigurator.Configure();
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
            name: "Error404",
            routeTemplate: "{*url}",
            defaults: new { controller = "Error", action = "Handle404" }
            );
        }
    }
}
