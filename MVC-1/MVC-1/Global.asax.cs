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
            CrearSuperUsuario(db);
            AgregarPermisoSuperUsiario(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AgregarPermisoSuperUsiario(ApplicationDbContext db)
        {
            var UserPrincipal = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var rolePrincipal = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usuario = UserPrincipal.FindByName("davidromeromesa@yahoo.com");

            if (!UserPrincipal.IsInRole(usuario.Id, "Ver"))
            {
                UserPrincipal.AddToRole(usuario.Id, "Ver");
            }

            if (!UserPrincipal.IsInRole(usuario.Id, "Editar"))
            {
                UserPrincipal.AddToRole(usuario.Id, "Editar");
            }

            if (!UserPrincipal.IsInRole(usuario.Id, "Crear"))
            {
                UserPrincipal.AddToRole(usuario.Id, "Crear");
            }

            if (!UserPrincipal.IsInRole(usuario.Id, "Eliminar"))
            {
                UserPrincipal.AddToRole(usuario.Id, "Eliminar");
            }

        }

        private void CrearSuperUsuario(ApplicationDbContext db)
        {
            var UserPrincipal = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var usuario = UserPrincipal.FindByName("davidromeromesa@yahoo.com");

            if (usuario == null)
            {
                usuario = new ApplicationUser
                {
                    UserName = "davidromeromesa@yahoo.com",
                    Email = "davidromeromesa@yahoo.com"

                };
                UserPrincipal.Create(usuario, "David123.");

            }

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
