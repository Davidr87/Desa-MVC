using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_1.Models;
using MVC_1.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC_1.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Usuarios
        public ActionResult Index()
        {
            var UserPrincipal = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var usuarios = UserPrincipal.Users.ToList();
            var usuariovista = new List<VistaUsuario>();


            foreach (var user in usuarios)
            {
                var usuarioVista = new VistaUsuario
                {
                    Correo = user.Email,
                    Nombre = user.UserName,
                    UsuarioID = user.Id,
                };
                usuariovista.Add(usuarioVista);
            }

            return View(usuariovista);
        }

        public ActionResult Roles(string UsuarioID)
        {
            if (string.IsNullOrEmpty(UsuarioID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserPrincipal = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var usuarios = UserPrincipal.Users.ToList();
            var usuario = usuarios.Find(u => u.Id == UsuarioID);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            var rolePrincipal = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = rolePrincipal.Roles.ToList();
            var Vistasroles = new List<RoleView>();

            foreach (var item in usuario.Roles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);

                var Vistasrole = new RoleView
                {
                    Nombre = role.Name,
                    RoleID = role.Id
                };

                Vistasroles.Add(Vistasrole);
            }
            var usuarioVista = new VistaUsuario
            {
                Correo = usuario.Email,
                Nombre = usuario.UserName,
                Roles = Vistasroles,
                UsuarioID = usuario.Id
            };
            return View(usuarioVista);

        }
        public ActionResult agregarroles(string UsuarioID)
        {
            if (string.IsNullOrEmpty(UsuarioID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserPrincipal = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var usuarios = UserPrincipal.Users.ToList();
            var usuario = usuarios.Find(u => u.Id == UsuarioID);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            var usuarioVista = new VistaUsuario
            {
                Correo = usuario.Email,
                Nombre = usuario.UserName,
                UsuarioID = usuario.Id
            };

            var rolePrincipal = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var list = rolePrincipal.Roles.ToList();
            list.Add(new IdentityRole { Id = "", Name = "[Seleccione un Role]" });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(list, "Id", "Name");
            //ViewBag.Error = "Debe seleccionar un Detalle";


            return View(usuarioVista);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}