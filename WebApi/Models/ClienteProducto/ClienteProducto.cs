using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Cliente;
using WebApi.Models.Producto;
using WebApi.Models.MedioDePago;

namespace WebApi.Models.ClienteProducto
{
    public class ClienteProducto
    {
        public int ClienteProductoID { get; set; }
        public int ClienteID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public int ValorTotal { get; set; }
        public int MedioDePagoID { get; set; }
        public virtual UpdateCliente Cliente { get; set; }
        public virtual UpdateProducto Producto { get; set; }
        public virtual WebApi.Models.MedioDePago.MedioDePago MedioDePago { get; set; }
    }
}
