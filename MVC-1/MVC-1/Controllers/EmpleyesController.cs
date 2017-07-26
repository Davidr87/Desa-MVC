using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_1.Models;

namespace MVC_1.Controllers
{
    public class EmpleyesController : Controller
    {
        private MVC_1Context db = new MVC_1Context();

        // GET: Empleyes
        public ActionResult Index()
        {
            var empleyes = db.Empleyes.Include(e => e.TipoDocumento);
            return View(empleyes.ToList());
        }

        // GET: Empleyes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleye empleye = db.Empleyes.Find(id);
            if (empleye == null)
            {
                return HttpNotFound();
            }
            return View(empleye);
        }

        // GET: Empleyes/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocuemntoID = new SelectList(db.TipoDocumentoes, "TipoDocuemntoID", "Descripcion");
            return View();
        }

        // POST: Empleyes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleyeId,Nombres,Apellidos,Salario,Bono,FehcaNacimiento,HoraInicio,Correo,URL,TipoDocuemntoID")] Empleye empleye)
        {
            if (ModelState.IsValid)
            {
                db.Empleyes.Add(empleye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocuemntoID = new SelectList(db.TipoDocumentoes, "TipoDocuemntoID", "Descripcion", empleye.TipoDocuemntoID);
            return View(empleye);
        }

        // GET: Empleyes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleye empleye = db.Empleyes.Find(id);
            if (empleye == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocuemntoID = new SelectList(db.TipoDocumentoes, "TipoDocuemntoID", "Descripcion", empleye.TipoDocuemntoID);
            return View(empleye);
        }

        // POST: Empleyes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleyeId,Nombres,Apellidos,Salario,Bono,FehcaNacimiento,HoraInicio,Correo,URL,TipoDocuemntoID")] Empleye empleye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocuemntoID = new SelectList(db.TipoDocumentoes, "TipoDocuemntoID", "Descripcion", empleye.TipoDocuemntoID);
            return View(empleye);
        }

        // GET: Empleyes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleye empleye = db.Empleyes.Find(id);
            if (empleye == null)
            {
                return HttpNotFound();
            }
            return View(empleye);
        }

        // POST: Empleyes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleye empleye = db.Empleyes.Find(id);
            db.Empleyes.Remove(empleye);
            db.SaveChanges();
            return RedirectToAction("Index");
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
