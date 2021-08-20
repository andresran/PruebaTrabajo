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
    public class proyectosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: proyectos
        public ActionResult Index()
        {
            var proyectos = db.proyectos.Include(p => p.Empresa);
            return View(proyectos.ToList());
        }

        // GET: proyectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = db.proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // GET: proyectos/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "IdEmpresa", "Nombre");
            return View();
        }

        // POST: proyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProyecto,Nombre,IdEmpresa")] proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                db.proyectos.Add(proyectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresas, "IdEmpresa", "Nombre", proyectos.IdEmpresa);
            return View(proyectos);
        }

        // GET: proyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = db.proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "IdEmpresa", "Nombre", proyectos.IdEmpresa);
            return View(proyectos);
        }

        // POST: proyectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProyecto,Nombre,IdEmpresa")] proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresas, "IdEmpresa", "Nombre", proyectos.IdEmpresa);
            return View(proyectos);
        }

        // GET: proyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyectos proyectos = db.proyectos.Find(id);
            if (proyectos == null)
            {
                return HttpNotFound();
            }
            return View(proyectos);
        }

        // POST: proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proyectos proyectos = db.proyectos.Find(id);
            db.proyectos.Remove(proyectos);
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
