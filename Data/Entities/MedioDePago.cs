using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
   public class MedioDePago
    {
        [Key]
        public int MedioDePagoID { get; set; }
        public string Nombre { get; set; }
    }
}
