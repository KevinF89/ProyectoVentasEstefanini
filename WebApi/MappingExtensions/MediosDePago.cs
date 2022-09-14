using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.MappingExtensions
{
    public static class MediosDePago
    {
        public static WebApi.Models.MedioDePago.MedioDePago ToModel(this Data.Entities.MedioDePago entity)
        {
            WebApi.Models.MedioDePago.MedioDePago medioDePago = new WebApi.Models.MedioDePago.MedioDePago
            {
                MedioDePagoID = entity.MedioDePagoID,
                Nombre = entity.Nombre,

            };
            return medioDePago;
        }

        public static List<WebApi.Models.MedioDePago.MedioDePago> ToListModels(this List<Data.Entities.MedioDePago> entities)
        {
            List<WebApi.Models.MedioDePago.MedioDePago> models = new List<WebApi.Models.MedioDePago.MedioDePago>();

            foreach (Data.Entities.MedioDePago entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
