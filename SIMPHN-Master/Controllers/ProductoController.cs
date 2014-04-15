
using SIMPHN_Master.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMPHN_Master.Controllers
{
    public class ProductoController : Controller
    {
        private ApplicationDb db = new ApplicationDb();

        public ActionResult Index()
        {
            List<Producto> productos = db.Productos.ToList();
            ViewBag.productos = productos;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nombre = "", double costo = 0)
        {
            Producto nuevo = new Producto();
            nuevo.Nombre = nombre;
            nuevo.Costo = costo;
            if (ModelState.IsValid)
            {
                db.Productos.Add(nuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.producto = producto;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string nombre = "", double costo = 0, int id = 0)
        {
            if (ModelState.IsValid)
            {
                Producto producto = db.Productos.Find(id);
                producto.Nombre = nombre;
                producto.Costo = costo;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.producto = producto;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
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
