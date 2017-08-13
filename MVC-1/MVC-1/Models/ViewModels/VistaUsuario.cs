using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVC_1.Models.ViewModels
{
    public class VistaUsuario
    {
        public string UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public RoleView Role { get; set; }
        public List<RoleView> Roles { get; set; }
    }
}