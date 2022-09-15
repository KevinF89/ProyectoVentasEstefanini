using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public string Nombres { get; set; } 
        public string Apellidos { get; set; }
        public int TipoDocumentoID { get; set; }
        public string Documento { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        [ForeignKey("TipoDocumentoID")]
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual IEnumerable<ClienteProducto> ClienteProductos { get; set; }
    }
}
