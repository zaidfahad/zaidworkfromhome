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
            // Web API configuration and services
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "Error404",
            routeTemplate: "{*url}",
            defaults: new { controller = "Error", action = "Handle404" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

         
        }
    }
}
