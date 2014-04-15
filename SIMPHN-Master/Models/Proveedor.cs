using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPHN_Master.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }
}