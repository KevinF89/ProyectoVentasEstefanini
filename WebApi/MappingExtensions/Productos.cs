using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Producto;

namespace WebApi.MappingExtensions
{
    public static class Productos
    {
        public static Data.Entities.Producto ToEntity(this CreateProducto model)
        {
            Data.Entities.Producto producto = new Data.Entities.Producto
            {
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                CantidadDisponible = model.CantidadDisponible,
                Valor = model.Valor
            };

            return producto;
        }

        public static Data.Entities.Producto ToEntity(this UpdateProducto model)
        {
            Data.Entities.Producto Producto = new Data.Entities.Producto
            {
                ProductoID = model.ProductoID,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                CantidadDisponible = model.CantidadDisponible,
                Valor = model.Valor
            };

            return Producto;
        }

        public static UpdateProducto ToModel(this Data.Entities.Producto entity)
        {
            UpdateProducto Producto = new UpdateProducto
            {
                ProductoID = entity.ProductoID,
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion,
                CantidadDisponible = entity.CantidadDisponible,
                Valor = entity.Valor
            };

            return Producto;
        }

        public static List<UpdateProducto> ToListModels(this List<Data.Entities.Producto> entities)
        {
            List<UpdateProducto> models = new List<UpdateProducto>();

            foreach (Data.Entities.Producto entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
