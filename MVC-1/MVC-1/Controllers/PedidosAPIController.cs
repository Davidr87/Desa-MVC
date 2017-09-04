using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC_1.Models;

namespace MVC_1.Controllers
{
    public class PedidosAPIController : ApiController
    {
        private MVC_1Context db = new MVC_1Context();

        // GET: api/PedidosAPI
        public IHttpActionResult GetPedido()
        {
            var pedidos = db.Pedido.ToList();
            var pedidosAPI = new List<PedidosAPI>();
            foreach (var pedido in pedidos)
            {
                var pedidoAPI = new PedidosAPI
                {
                   Cliente = pedido.Cliente,
                   FechaOrden=pedido.FechaOrden,
                   Detalles=pedido.DetallePedidos,
                   PedidoID=pedido.PedidoID,
                   EstadoPedido=pedido.EstadoPedido


                };
                pedidosAPI.Add(pedidoAPI);

            }

            return Ok(pedidosAPI);
        }

        // GET: api/PedidosAPI/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult GetPedido(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        // PUT: api/PedidosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.PedidoID)
            {
                return BadRequest();
            }

            db.Entry(pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PedidosAPI
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult PostPedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedido.Add(pedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido.PedidoID }, pedido);
        }

        // DELETE: api/PedidosAPI/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult DeletePedido(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            db.Pedido.Remove(pedido);
            db.SaveChanges();

            return Ok(pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoExists(int id)
        {
            return db.Pedido.Count(e => e.PedidoID == id) > 0;
        }
    }
}