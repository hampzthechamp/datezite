using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace datezite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AddEntry",
                routeTemplate: "api/EntryApi/CreateNew/",
                defaults: new { controller = "EntryApi", action = "CreateNew"}
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
