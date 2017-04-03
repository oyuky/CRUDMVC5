using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InformacionPersonal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Personas", action = "ListaPersonas", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "routePersonas",
            //    url: "{controller}/{action}/{currentPageIndex}/{nombre}",
            //    defaults: new { controller = "Personas", action = "ListaPersonas", currentPageIndex = UrlParameter.Optional, personanombre = UrlParameter.Optional }
            //);
        }
    }
}
