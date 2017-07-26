using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Proveedor
    {
        [Key]
        public int ProveedorID { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Contacto 1")]
        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Contacto1 { get; set; }

        [Display(Name = "Contacto 2")]
        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Contacto2 { get; set; }

        public int Telefono { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        public virtual ICollection<ProveedoresProducto> ProveedorProductos { get; set; }

    }
}