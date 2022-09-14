using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.ClienteProducto
{
    public class CreateClienteProducto
    {
        public int ClienteID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public int ValorTotal { get; set; }
        public int MedioDePagoID { get; set; }
    }
}
