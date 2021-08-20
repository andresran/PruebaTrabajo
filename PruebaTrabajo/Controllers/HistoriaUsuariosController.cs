using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTrabajo.Models;

namespace PruebaTrabajo.Controllers
{
    [Authorize]
    public class HistoriaUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HistoriaUsuarios
        public ActionResult Index()
        {
            var historiaUsuarios = db.HistoriaUsuarios.Include(h => h.proyectos);
            return View(historiaUsuarios.ToList());
        }

        // GET: HistoriaUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaUsuario historiaUsuario = db.HistoriaUsuarios.Find(id);
            if (historiaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(historiaUsuario);
        }

        // GET: HistoriaUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdProyecto = new SelectList(db.proyectos, "IdProyecto", "Nombre");
            return View();
        }

        // POST: HistoriaUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHistoriaUsuario,Nombre,IdProyecto")] HistoriaUsuario historiaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.HistoriaUsuarios.Add(historiaUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProyecto = new SelectList(db.proyectos, "IdProyecto", "Nombre", historiaUsuario.IdProyecto);
            return View(historiaUsuario);
        }

        // GET: HistoriaUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaUsuario historiaUsuario = db.HistoriaUsuarios.Find(id);
            if (historiaUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProyecto = new SelectList(db.proyectos, "IdProyecto", "Nombre", historiaUsuario.IdProyecto);
            return View(historiaUsuario);
        }

        // POST: HistoriaUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHistoriaUsuario,Nombre,IdProyecto")] HistoriaUsuario historiaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiaUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProyecto = new SelectList(db.proyectos, "IdProyecto", "Nombre", historiaUsuario.IdProyecto);
            return View(historiaUsuario);
        }

        // GET: HistoriaUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaUsuario historiaUsuario = db.HistoriaUsuarios.Find(id);
            if (historiaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(historiaUsuario);
        }

        // POST: HistoriaUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoriaUsuario historiaUsuario = db.HistoriaUsuarios.Find(id);
            db.HistoriaUsuarios.Remove(historiaUsuario);
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
