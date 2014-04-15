using SIMPHN_Master.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SIMPHN_Master.Models
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb()
            : base("DefaultConnection")
        {

        }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Despacho> Despachos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}