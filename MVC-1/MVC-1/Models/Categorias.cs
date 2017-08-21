using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }

        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El debe contener {0}")]
        [Display(Name = "Descripcion de documento")]
        public string Descripcion { get; set; }
    }
}