using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        public DateTime FechaOrden { get; set; }
        public int ClienteID { get; set; }
        public EstadoPedido EstadoPedido { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetallesPedidos> DetallePedidos { get; set; }
    }
}