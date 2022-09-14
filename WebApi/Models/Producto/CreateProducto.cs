using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Producto
{
    public class CreateProducto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
        public int CantidadDisponible { get; set; }
    }
}
