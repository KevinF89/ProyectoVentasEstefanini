using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class TipoDocumento
    {
        [Key]
        public int TipoDocumentoID { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}
