using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DigisensePlatformAPIs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      

//            routes.MapRoute(
//                name: "Login",
//                url: "{controller}/{action}/{id}",
//                defaults: new { controller = "Login", action = "Authenicate" }
//            );

//            routes.MapRoute(
//               name: "ForgotPassword",
//               url: "{controller}/{action}/{id}",
//               defaults: new { controller = "ForgotPassword", action = "ForgotPassword" }
//           );


//            routes.MapRoute(
//              name: "ChangePassword",
//              url: "{controller}/{action}/{id}",
//              defaults: new { controller = "ChangePassword", action = "ChangePassword" }
//          );

//            routes.MapRoute(
//             name: "Alerts",
//             url: "{controller}/{action}/{id}",
//             defaults: new { controller = "Alerts", action = "AlertDetails" }
//         );

//            #region Profiles

//                routes.MapRoute(
//                name: "Profile",
//                url: "api/Profile",
//                defaults: new { controller = "Profile", action = "Profile" }
//            );

//                routes.MapRoute(
//                name: "ProfilePost",
//                url: "api/Profile",
//                defaults: new { controller = "Profile", action = "ProfilePost" }
//            );

//                routes.MapRoute(
//                name: "ProfileForSpecificUser",
//                url: "api/Profile/{userId}",
//                defaults: new { controller = "Profile", action = "ProfileForSpecificUser" }
//            );

//                routes.MapRoute(
//                name: "ProfileForSpecificUserPatch",
//                url: "api/Profile/{userId}",
//                defaults: new { controller = "Profile", action = "ProfileForSpecificUserPatch" }
//            );

               

//                routes.MapRoute(
//          name: "ProfileAlertConfiguration",
//          url: "api/Profile/AlertConfiguration",
//          defaults: new { controller = "Profile", action = "ProfileAlertConfiguration" }
//        );

//                routes.MapRoute(
//        name: "ProfileAlertConfigurationPatch",
//        url: "api/Profile/AlertConfiguration",
//        defaults: new { controller = "Profile", action = "ProfileAlertConfigurationPatch" }
//      );

//            #endregion

//            #region Driver
//            routes.MapRoute(
//               name: "DriverProfiles",
//               url: "api/DriverProfiles",
//               defaults: new { controller = "Driver1", action = "DriverProfiles" }
//           );
//            routes.MapRoute(
//            name: "DriverProfilesWithDriverId",
//            url: "api/DriverProfiles/{driverId}",
//            defaults: new { controller = "Driver1", action = "DriverProfilesWithDriverId" }
//        );
//            routes.MapRoute(
//        name: "DriverProfilesWithDriverIdPatch",
//        url: "api/DriverProfiles/{driverId}",
//        defaults: new { controller = "Driver1", action = "DriverProfilesWithDriverIdPatch" }
//    );
//            routes.MapRoute(
//    name: "DriverProfilesForPost",
//    url: "api/DriverProfiles/Driver",
//    defaults: new { controller = "Driver1", action = "DriverProfilesForPost" }
//);
//            #endregion
        }
    }
}
