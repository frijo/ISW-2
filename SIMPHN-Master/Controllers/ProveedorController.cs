using SIMPHN_Master.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMPHN_Master.Controllers
{
    public class ProveedorController : Controller
    {
        private ApplicationDb db = new ApplicationDb();

        public ActionResult Index()
        {
            List<Proveedor> proveedores = db.Proveedores.ToList();
            ViewBag.proveedores = proveedores;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nombre = "", string direccion = "", int telefono = 0)
        {
            Proveedor nuevo = new Proveedor();
            nuevo.Nombre = nombre;
            nuevo.Direccion = direccion;
            nuevo.Telefono = telefono;
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(nuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.proveedor = proveedor;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string nombre = "", string direccion = "", int telefono = 0, int id = 0)
        {
            if (ModelState.IsValid)
            {
                Proveedor proveedor = db.Proveedores.Find(id);
                proveedor.Nombre = nombre;
                proveedor.Direccion = direccion;
                proveedor.Telefono = telefono;
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.proveedor = proveedor;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedor);
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
