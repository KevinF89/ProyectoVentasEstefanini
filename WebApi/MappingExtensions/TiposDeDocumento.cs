using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.MappingExtensions
{
    public static class TiposDeDocumento
    {
        public static WebApi.Models.TipoDeDocumento.TipoDeDocumento ToModel(this Data.Entities.TipoDocumento entity)
        {
            WebApi.Models.TipoDeDocumento.TipoDeDocumento tipoDeDocumento = new WebApi.Models.TipoDeDocumento.TipoDeDocumento
            {
                TipoDocumentoID = entity.TipoDocumentoID,
                Nombre = entity.Nombre,
                Abreviatura = entity.Abreviatura

            };
            return tipoDeDocumento;
        }

        public static List<WebApi.Models.TipoDeDocumento.TipoDeDocumento> ToListModels(this List<Data.Entities.TipoDocumento> entities)
        {
            List<WebApi.Models.TipoDeDocumento.TipoDeDocumento> models = new List<WebApi.Models.TipoDeDocumento.TipoDeDocumento>();

            foreach (Data.Entities.TipoDocumento entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
