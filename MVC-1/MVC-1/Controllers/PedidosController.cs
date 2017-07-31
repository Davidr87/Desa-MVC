using MVC_1.Models;
using MVC_1.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Linq;

namespace MVC_1.Controllers
{
    public class PedidosController : Controller
    {
        private MVC_1Context db = new MVC_1Context();
        // GET: Pedidos87
        public ActionResult NuevoPedido()
       {
            var vistaPedidos = new VistaPedidos();
            vistaPedidos.Cliente = new Cliente();
            vistaPedidos.Productos = new List<Producto>();
            Session["vistaPedidos"] = vistaPedidos;

            var list = db.Clientes.ToList();
            list = list.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "NombreCompleto");
            

            return View(vistaPedidos);
        }

        [HttpPost]
        public ActionResult NuevoPedido(VistaPedidos vistaPedidos)
        {
           
            var list = db.Clientes.ToList();
            list.Add(new Cliente { ClienteID = 0, Nombres = "[Pro favor seleccione cliente]" });
            list = list.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "NombreCompleto");


            return View(vistaPedidos);
        }

        public ActionResult AgregarPedido()
        {
         

            var list = db.Productoes.ToList();
            list.Add(new PedidoProductos { id = 0, Descripcion = "[Pro favor seleccione producto]" });
            list = list.OrderBy(p => p.Descripcion).ToList();
            ViewBag.id = new SelectList(list, "id", "Descripcion");


            return View();
        }

        [HttpPost]
        public ActionResult AgregarPedido(PedidoProductos pedidoProductos)
        {
            var vistaPedidos = Session["vistaPedidos"] as VistaPedidos;
            var id = int.Parse(Request["id"]);

            if (id == 0)
            {
                var list = db.Productoes.ToList();
                list.Add(new PedidoProductos { id = 0, Descripcion = "[Pro favor seleccione producto]" });
                list = list.OrderBy(p => p.Descripcion).ToList();
                ViewBag.id = new SelectList(list, "id", "Descripcion");
                ViewBag.Error = "Debe seleccionar un producto";

                return View(pedidoProductos);
            
            }

            var producto = db.Productoes.Find(id);
            if(producto==null)
            {
                var list = db.Productoes.ToList();
                list.Add(new PedidoProductos { id = 0, Descripcion = "[Pro favor seleccione producto]" });
                list = list.OrderBy(p => p.Descripcion).ToList();
                ViewBag.id = new SelectList(list, "id", "Descripcion");
                ViewBag.Error = "Producto no existe";

                return View(pedidoProductos);

            }
            pedidoProductos = new PedidoProductos
            {
                Descripcion=producto.Descripcion,
                Precio = producto.Precio,
                id = producto.id,
                Cantidad = float.Parse(Request["Cantidad"]),

            };
            vistaPedidos.Productos.Add(pedidoProductos);        
            return View("AgregarPedido",vistaPedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}