using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Cliente
{
    public class UpdateCliente
    {
        public int ClienteID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TipoDocumentoID { get; set; }
        public string Documento { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
    }
}
