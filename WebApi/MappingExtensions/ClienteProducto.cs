using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.ClienteProducto;
using WebApi.MappingExtensions;

namespace WebApi.MappingExtensions
{
    public static class ClienteProducto
    {
        public static Data.Entities.ClienteProducto ToEntity(this CreateClienteProducto model)
        {
            Data.Entities.ClienteProducto clienteProducto = new Data.Entities.ClienteProducto
            {
                ClienteID = model.ClienteID,
                ProductoID = model.ProductoID,
                Cantidad = model.Cantidad,
                ValorTotal = model.ValorTotal
            };

            return clienteProducto;
        }

        public static WebApi.Models.ClienteProducto.ClienteProducto ToModel(this Data.Entities.ClienteProducto entity)
        {
            WebApi.Models.ClienteProducto.ClienteProducto clienteProducto = new WebApi.Models.ClienteProducto.ClienteProducto
            {
                ClienteProductoID = entity.ClienteProductoID,
                ClienteID = entity.ClienteID,
                ProductoID = entity.ProductoID,
                Cantidad = entity.Cantidad,
                MedioDePagoID = entity.MedioDePagoID

            };

            if(entity.Cliente != null)
            {
                clienteProducto.Cliente = entity.Cliente.ToModel();
            }
            if (entity.Cliente != null)
            {
                clienteProducto.Producto = entity.Producto.ToModel();
            }

            return clienteProducto;
        }

        public static List<WebApi.Models.ClienteProducto.ClienteProducto> ToListModels(this List<Data.Entities.ClienteProducto> entities)
        {
            List<WebApi.Models.ClienteProducto.ClienteProducto> models = new List<WebApi.Models.ClienteProducto.ClienteProducto>();

            foreach (Data.Entities.ClienteProducto entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
