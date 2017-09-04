using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class PedidosAPI
    {
        public int PedidoID { get; set; }
        public DateTime FechaOrden { get; set; }
        public Cliente Cliente { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
        public ICollection<DetallesPedidos> Detalles { get; set; }

    }
}