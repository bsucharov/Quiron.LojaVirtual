using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // rota 1
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null,
                    pagina = 1
                });

            // rota 2
            routes.MapRoute(null,
               "Pagina{pagina}",
               new
               {
                   Controller = "Vitrine",
                   Action = "ListaProdutos",
                   categoria = (string)null
               }, new { pagina = @"\d+" });


            //rota 3
            routes.MapRoute(null, "{categoria}", new
            {
                controller = "Vitrine",
                action = "ListaProdutos",
                pagina = 1

            });

            // rota 4
            routes.MapRoute(null,
               "{categoria}Pagina{pagina}",
               new
               {
                   Controller = "Vitrine",
                   Action = "ListaProdutos"
               }, new { pagina = @"\d+" });


            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new { controller = "Vitrine", Action = "ListaProdutos" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
