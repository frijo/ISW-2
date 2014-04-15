using System;
using SIMPHN_Master.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;

using SIMPHN;
using SIMPHN_Master;

namespace SIMPHN.Controllers
{
    public class DespachoController : Controller
    {
        private ApplicationDb db = new ApplicationDb();

        public ActionResult Index()
        {
            List<Despacho> despacho = db.Despachos.ToList();
            ViewBag.despacho = despacho;

            return View();
        }

        public ActionResult Create()
        {
            List<Bodega> bodegas = db.Bodegas.ToList();
            ViewBag.bodegas = bodegas;

            List<Producto> producto = db.Productos.ToList();
            ViewBag.productos = producto;

            List<Proveedor> proveedores = db.Proveedores.ToList();
            ViewBag.proveedores = proveedores;

            List<Usuario> usuarios = db.Usuarios.ToList();
            ViewBag.usuarios = usuarios;

            return View();
        }
        public ActionResult Edit()
        {
            List<Bodega> bodega = db.Bodegas.ToList();
            ViewBag.bodegas = bodega;

            List<Producto> producto = db.Productos.ToList();
            ViewBag.productos = producto;

            List<Proveedor> proveedores = db.Proveedores.ToList();
            ViewBag.proveedores = proveedores;

            List<Usuario> usuarios = db.Usuarios.ToList();
            ViewBag.usuarios = usuarios;

            List<Despacho> despacho = db.Despachos.ToList();
            ViewBag.despacho = despacho;

            return View();
        }

        [HttpPost]
        public ActionResult Create(int IDBodega, int IDProducto, int IDProveedor, int IDUsuario, DateTime Fecha, int cantidad, double total)
        {
            Despacho nuevo = new Despacho();
            nuevo.IdBodega = IDBodega;
            nuevo.IdProducto = IDProducto;
            nuevo.IdProveedor = IDProveedor;
            nuevo.IdUsuario = IDUsuario;
            nuevo.FechaDespacho = Fecha;
            nuevo.Cantidad = cantidad;
            nuevo.Total = total;

            if (ModelState.IsValid)
            {
                db.Despachos.Add(nuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Despacho despacho = db.Despachos.Find(id);
            if (despacho == null)
            {
                return HttpNotFound();
            }
            ViewBag.despacho = despacho;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, int idBodega, int idProducto, int idProveedor, int idUsuario, DateTime Fecha, int cantidad, double total)
        {
            if (ModelState.IsValid)
            {
                Despacho despacho = db.Despachos.Find(id);
                despacho.IdBodega = idBodega;
                despacho.IdProducto = idProducto;
                despacho.IdProveedor = idProveedor;
                despacho.IdUsuario = idUsuario;
                despacho.FechaDespacho = Fecha;
                despacho.Cantidad = cantidad;
                despacho.Total = total;
                db.Entry(despacho).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuario = usuario;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
