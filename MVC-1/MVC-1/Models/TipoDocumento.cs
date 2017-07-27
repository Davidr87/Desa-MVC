using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class TipoDocumento
    {

        [Key]
        public int TipoDocuemntoID { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Empleye> Empleyes { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}