using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.TipoDeDocumento
{
    public class TipoDeDocumento
    {
        public int TipoDocumentoID { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
    }
}
