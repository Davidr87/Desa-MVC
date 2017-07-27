using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class DetallesPedidos
    {
        public int DetallesPedidosID { get; set; }
        public int PedidoID { get; set; }
        public int id { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [StringLength(30, ErrorMessage = "El {0} nombre debe contener entre {2} a {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [DataType(DataType.Currency)]

        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Por Favor completar {0}")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]

        public float Cantidad { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }


    }
}