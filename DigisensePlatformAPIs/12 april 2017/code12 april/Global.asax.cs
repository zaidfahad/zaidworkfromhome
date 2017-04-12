﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using DigisensePlatformAPIs.Utilities;
using System.Web.Http.Controllers;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DigisensePlatformAPIs
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            log4net.Config.XmlConfigurator.Configure();
            configuration.Services.Replace(typeof(IHttpControllerSelector), new HttpNotFoundAwareDefaultHttpControllerSelector(configuration));
            configuration.Services.Replace(typeof(IHttpActionSelector), new HttpNotFoundAwareControllerActionSelector());
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
           
        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            //HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            //HttpContext.Current.Response.Headers.Remove("Server");
            //HttpContext.Current.Response.Headers.Remove("ETag");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            HttpException httpex = ex as HttpException;
            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            if (httpex == null)
            {
                routeData.Values.Add("controller", "Error");
            }
            else
            {
                switch (httpex.GetHttpCode())
                {
                    case 404:
                        {

                            break;
                        }
                    case 302:
                        {

                            break;
                        }
                    case 400:
                        {

                            break;
                        }
                    case 500:
                        {

                            break;
                        }
                    case 503:
                        {

                            break;
                        }
                }
            }
        }
    }

}