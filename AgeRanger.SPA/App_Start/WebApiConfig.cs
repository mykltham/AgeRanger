using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AgeRanger.SPA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            // Set the API Controller's Action
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    } // class
} // namespace
