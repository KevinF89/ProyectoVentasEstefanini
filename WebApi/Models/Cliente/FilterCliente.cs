using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Cliente
{
    public class FilterCliente
    {
        public int? ClienteID { get; set; }
        public int? TipoDocumentoID { get; set; }
        public string Documento { get; set; }
    }
}
