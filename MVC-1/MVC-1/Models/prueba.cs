using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class prueba
    {
        [Key]
        public int pruebaId { get; set; }

     public string Nombres { get; set; }

    }
}