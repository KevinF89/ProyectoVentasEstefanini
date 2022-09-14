using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.ClienteProducto
{
    public class FilterClienteProducto
    {
        public int? ClienteProductoID { get; set; }
        public int? ClienteID { get; set; }
        public int? ProductoID { get; set; }
    }
}
