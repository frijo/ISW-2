using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPHN_Master.Models
{
    public class Despacho
    {
        public int Id { get; set; }
        public int IdBodega { get; set; }
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaDespacho { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
    }
}