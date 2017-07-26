using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class ProveedoresProducto
    {
        [Key]
        public int ProveedorProductoID { get; set; }

        public int ProveedorID { get; set; }//IDE DLE PROVEEDOR
        public int id { get; set; }//ID DEL PRODUCTO

        public virtual Proveedor Proveedor { get; set; }

        public virtual Producto Productor { get; set; }


    }
}