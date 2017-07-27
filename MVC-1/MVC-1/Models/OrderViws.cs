using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class OrderViws
    {
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; }
    }
}