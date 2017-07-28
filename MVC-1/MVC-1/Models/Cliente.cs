using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        public int Telefono { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Display(Name = "Docuemnto")]
        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Documento { get; set; }


        [Display(Name = "Tipo de Docuemnto")]
        [Required(ErrorMessage = "Por Favor completar {0}")]
        public int TipoDocuemntoID { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }


        public string NombreCompleto { get { return string.Format("{0}{1}", Nombres, Apellidos); } } 

        public virtual ICollection<Pedido> Pedido { get; set; }

    }
}