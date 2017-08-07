using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models.ViewModels
{
    public class VistaUsuario
    {
        public string UsuarioID { get; set; }
        public string Nombre { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        public VistaRoles Role { get; set; }
        public List<VistaRoles> Roles { get; set; }



    }
}