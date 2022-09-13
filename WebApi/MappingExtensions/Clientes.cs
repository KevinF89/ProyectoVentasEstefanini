using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Cliente;

namespace WebApi.MappingExtensions
{
    public static class Clientes
    {
        public static Data.Entities.Cliente ToEntity(this CreateCliente model)
        {
            Data.Entities.Cliente cliente = new Data.Entities.Cliente
            {
                TipoDocumentoID = model.TipoDocumentoID,
                Documento = model.Documento,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Celular = model.Celular,
                Correo = model.Correo
            };

            return cliente;
        }

        public static Data.Entities.Cliente ToEntity(this UpdateCliente model)
        {
            Data.Entities.Cliente cliente = new Data.Entities.Cliente
            {
                ClienteID = model.ClienteID,
                TipoDocumentoID = model.TipoDocumentoID,
                Documento = model.Documento,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Celular = model.Celular,
                Correo = model.Correo
            };

            return cliente;
        }

        public static UpdateCliente ToModel(this Data.Entities.Cliente entity)
        {
            UpdateCliente cliente = new UpdateCliente
            {
                ClienteID = entity.ClienteID,
                TipoDocumentoID = entity.TipoDocumentoID,
                Documento = entity.Documento,
                Nombres = entity.Nombres,
                Apellidos = entity.Apellidos,
                Celular = entity.Celular,
                Correo = entity.Correo
            };

            return cliente;
        }

        public static List<UpdateCliente> ToListModels(this List<Data.Entities.Cliente> entities)
        {
            List<UpdateCliente> models = new List<UpdateCliente>();

            foreach (Data.Entities.Cliente entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
