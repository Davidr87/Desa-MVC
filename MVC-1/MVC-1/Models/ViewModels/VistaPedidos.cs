using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_1.Models.ViewModels
{
    public class VistaPedidos
    {
        public Cliente Cliente { get; set; }
        public PedidoProductos Producto { get; set; }
        public List<PedidoProductos> Productos { get; set; }
    }
}