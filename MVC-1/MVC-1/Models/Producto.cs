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

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [DataType(DataType.Currency)]

        public decimal Precio { get; set; }

        [Display(Name = "Ultima Compra")]
        public DateTime FechaUltimaCompras { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [DataType(DataType.Currency)]
        public float Bodega { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(120, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]

        public string Comentario { get; set; }

        public virtual ICollection<ProveedoresProducto> ProveedorProductos { get; set; }

    }
}