using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Empleye
    {
        [Key]
        public int EmpleyeId { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Salario { get; set; }

        [Display(Name = "% Bonificacion")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
         public int Bono { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Por Favor completar {0}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FehcaNacimiento { get; set; }

        [Display(Name = "Hora de Inicio")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [DataType(DataType.Url)]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string URL { get; set; }
        public int TipoDocuemntoID { get; set; }

        [NotMapped]
        public int Age { get { return DateTime.Now.Year - FehcaNacimiento.Year; } }

        public virtual TipoDocumento TipoDocumento { get; set; }


    }
}