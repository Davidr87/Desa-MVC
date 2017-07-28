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

            var list = db.Clientes.ToList();
            //list.Add(new Cliente { ClienteID = 0, NombreCompleto = "[Por favor seleccione el tipo de documento]" });
            list = list.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "NombreCompleto");
            

            return View(vistaPedidos);
        }

        [HttpPost]
        public ActionResult NuevoPedido(VistaPedidos vistaPedidos)
        {

            var list = db.Clientes.ToList();
            list = list.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "NombreCompleto");


            return View(vistaPedidos);
        }

        public ActionResult AgregarPedido(PedidoProductos pedidoProductos)
        {
            return View(pedidoProductos);
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