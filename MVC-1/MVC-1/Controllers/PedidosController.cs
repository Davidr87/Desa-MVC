using MVC_1.Models;
using MVC_1.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Linq;
using System;

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
            vistaPedidos.Productos = new List<PedidoProductos>();

            Session["vistaPedidos"] = vistaPedidos;

            var list = db.Clientes.ToList();
            list = list.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "NombreCompleto");
            

            return View(vistaPedidos);
        }

        [HttpPost]
        public ActionResult NuevoPedido(VistaPedidos vistaPedidos)
        {
            vistaPedidos = Session["vistaPedidos"] as VistaPedidos;


            var clienteID =int .Parse(Request["ClienteID"]);


            if (clienteID == 0)
            {
            
                var listc = db.Clientes.ToList();
                listc = listc.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.ClienteID = new SelectList(listc, "ClienteID", "NombreCompleto");
                ViewBag.Error = "Debe seleccionar un Cliente";

                return View(vistaPedidos);

            }

            var cliente = db.Clientes.Find(clienteID);

            if (cliente == null)
            {
                var listc = db.Clientes.ToList();
                listc = listc.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.ClienteID = new SelectList(listc, "ClienteID", "NombreCompleto");
                ViewBag.Error = "Debe seleccionar un Cliente";
                ViewBag.Error = "Cliente no existe";

                return View(vistaPedidos);

            }

            if (vistaPedidos.Productos.Count == 0)
            {
                var listc = db.Clientes.ToList();
                listc = listc.OrderBy(c => c.NombreCompleto).ToList();
                ViewBag.ClienteID = new SelectList(listc, "ClienteID", "NombreCompleto");
                ViewBag.Error = "Debe seleccionar un Detalle";

                return View(vistaPedidos);
            }

            var pedido = new Pedido
            {
                ClienteID=clienteID,
                FechaOrden= DateTime.Now,
                EstadoPedido=EstadoPedido.Creada
            };
            db.Pedido.Add(pedido);
            db.SaveChanges();

            var pedidoID = db.Pedido.ToList().Select(p => p.PedidoID).Max();

            foreach (var item in vistaPedidos.Productos)
            {
                var detallesPedido = new DetallesPedidos
                {
                    Descripcion=item.Descripcion,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad,
                    PedidoID= pedidoID,
                };

            }

            return View(vistaPedidos);

         
        }

        public ActionResult AgregarPedido()
        {
         

            var list = db.Productos.ToList();
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
                var listb= db.Productos.ToList();
                listb.Add(new PedidoProductos { id = 0, Descripcion = "[Pro favor seleccione producto]" });
                listb = listb.OrderBy(p => p.Descripcion).ToList();
                ViewBag.id = new SelectList(listb, "id", "Descripcion");
                ViewBag.Error = "Debe seleccionar un producto";

                return View(pedidoProductos);
            
            }

            var producto = db.Productos.Find(id);
            if(producto==null)
            {
                var listC = db.Productos.ToList();
                listC.Add(new PedidoProductos { id = 0, Descripcion = "[Pro favor seleccione producto]" });
                listC = listC.OrderBy(p => p.Descripcion).ToList();
                ViewBag.id = new SelectList(listC, "id", "Descripcion");
                ViewBag.Error = "Producto no existe";

                return View(pedidoProductos);

            }

            pedidoProductos = vistaPedidos.Productos.Find(p=>p.id==id );

            if (pedidoProductos == null)
            {
                pedidoProductos = new PedidoProductos
                {
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    id = producto.id,
                    Cantidad = float.Parse(Request["Cantidad"]),

                };
                vistaPedidos.Productos.Add(pedidoProductos);
            }
            else
            {
                pedidoProductos.Cantidad += float.Parse(Request["Cantidad"]);
            }

            var list = db.Clientes.ToList();
            list.Add(new Cliente { ClienteID = 0, Nombres = "[Pro favor seleccione cliente]" });
            list = list.OrderBy(c => c.NombreCompleto).ToList();
            ViewBag.ClienteID = new SelectList(list, "ClienteID", "NombreCompleto");

            return View("NuevoPedido", vistaPedidos);
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