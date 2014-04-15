using SIMPHN_Master.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;


namespace SIMPHN_Master.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationDb db = new ApplicationDb();

        public ActionResult Index()
        {
            List<Usuario> usuarios = db.Usuarios.ToList();
            ViewBag.usuarios = usuarios;

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nombre = "", string contrasena = "")
        {
            Usuario nuevo = new Usuario();
            nuevo.Nombre = nombre;
            nuevo.Contrasena = contrasena;
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(nuevo);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuario = usuario;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string nombre = "", string contrasena = "", int id = 0)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = db.Usuarios.Find(id);
                usuario.Nombre = nombre;
                usuario.Contrasena = contrasena;
                db.Entry(usuario).State = EntityState.Modified;
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
