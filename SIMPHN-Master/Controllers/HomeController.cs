using SIMPHN_Master.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMPHN_Master.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private ApplicationDb db = new ApplicationDb();

        public ActionResult Index()
        {
            List<Bodega> bodegas = db.Bodegas.ToList();
            ViewBag.bodegas = bodegas;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nombre = "", string direccion = "", int telefono = 0)
        {
            Bodega nuevo = new Bodega();
            nuevo.Nombre = nombre;
            nuevo.Direccion = direccion;
            nuevo.Telefono = telefono;
            if (ModelState.IsValid)
            {
                db.Bodegas.Add(nuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            ViewBag.bodega = bodega;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string nombre = "", string direccion = "", int telefono = 0, int id = 0)
        {
            if (ModelState.IsValid)
            {
                Bodega bodega = db.Bodegas.Find(id);
                bodega.Nombre = nombre;
                bodega.Direccion = direccion;
                bodega.Telefono = telefono;
                db.Entry(bodega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            ViewBag.bodega = bodega;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Bodega bodega = db.Bodegas.Find(id);
            db.Bodegas.Remove(bodega);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
