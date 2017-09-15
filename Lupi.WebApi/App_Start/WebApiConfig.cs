using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Lupi.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configuration of clients accepted types
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
                              "application/xml",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/xml"));

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
                             "application/json",
                             StringComparison.InvariantCultureIgnoreCase,
                             true,
                             "application/json"));

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
                           "text/html",
                           StringComparison.InvariantCultureIgnoreCase,
                           true,
                           "application/json"));
        }
    }
}
