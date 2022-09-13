using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
   public class ClienteProducto
    {
        [Key]
        public int ClienteProductoID { get; set; }
        public int ClienteID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public int ValorTotal { get; set; }
        public int MedioDePagoID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual MedioDePago MedioDePago { get; set; }

    }
}
