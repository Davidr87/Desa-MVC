using MVC_1.Models;
using MVC_1.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_1.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos87
        public ActionResult NuevoPedido()
       {
            var vistaPedidos = new VistaPedidos();
            vistaPedidos.Cliente = new Cliente();
            vistaPedidos.Productos = new List<Producto>();
            return View(vistaPedidos);
        }
    }
}