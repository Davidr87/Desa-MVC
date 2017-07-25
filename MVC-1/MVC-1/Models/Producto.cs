using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaUltimaCompras { get; set; }
        public float Bodega { get; set; }
        public string Comentario { get; set; }


    }
}