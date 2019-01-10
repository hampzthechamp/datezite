using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace datezite
{
    
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "EntryApi", action = "Post", id = UrlParameter.Optional }
            );
        }
    }
}
