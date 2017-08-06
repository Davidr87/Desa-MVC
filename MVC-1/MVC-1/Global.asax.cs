using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MVC_1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.MVC_1Context,Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var rolePrincipal = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!rolePrincipal.RoleExists("Ver"))
            {
                rolePrincipal.Create(new IdentityRole("Ver"));
            }

            if (!rolePrincipal.RoleExists("Editar"))
            {
                rolePrincipal.Create(new IdentityRole("Editar"));
            }

            if (!rolePrincipal.RoleExists("Crear"))
            {
                rolePrincipal.Create(new IdentityRole("Crear"));
            }

            if (!rolePrincipal.RoleExists("Ver"))
            {
                rolePrincipal.Create(new IdentityRole("Ver"));
            }

            if (!rolePrincipal.RoleExists("Eliminar"))
            {
                rolePrincipal.Create(new IdentityRole("Eliminar"));
            }
        }
    }
}
