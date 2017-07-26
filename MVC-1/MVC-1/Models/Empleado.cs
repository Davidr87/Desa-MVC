using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Empleado
    {

        [Key]
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal Salario { get; set; }
        public int Bono { get; set; }
        public DateTime FehcaNacimiento { get; set; }
        public DateTime HoraInicio { get; set; }
        public string Correo { get; set; }
        public string URL { get; set; }
        public int TipoDocuemntoID { get; set; }

        //public virtual TipoDocumento TipoDocumento { get; set; }
    }
}