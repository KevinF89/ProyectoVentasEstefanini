using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApi.Models.Otros
{
    public class RespuestaToken
    {
        [DataMember]
        public bool Valido { get; set; }
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
}
