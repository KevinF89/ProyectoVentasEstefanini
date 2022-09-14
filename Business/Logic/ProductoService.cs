using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Entities;
using Data.Base;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Business.Logic
{
    public class ProductoService
    {
        private static Context context = new Context();
        private readonly BaseRepository<Producto> repositoryProducto = new BaseRepository<Producto>(context);

        public async Task<Producto> InsertProductoAsync(Producto producto)
        {

            await this.repositoryProducto.InsertAsync(producto);
            return producto;
        }

        public async Task<bool> DeleteproductoAsync(int productoID)
        {
            bool result = false;
            Producto producto = this.Query(productoID: productoID, tracking: true).FirstOrDefault();

            result = await this.repositoryProducto.DeleteAsync(producto) > 0 ? true : false;

            return result;
        }

        public async Task<Producto> UpdateProductoAsync(Producto producto)
        {
            Producto updateProducto = this.Query(productoID: producto.ProductoID, tracking: true).FirstOrDefault();

            updateProducto.Nombre = producto.Nombre;
            updateProducto.Descripcion = producto.Descripcion;
            updateProducto.Valor = producto.Valor;
            updateProducto.CantidadDisponible = producto.CantidadDisponible;

            await this.repositoryProducto.UpdateAsync(updateProducto);

            return producto;
        }

        public async Task<List<Producto>> GetAsync(int? productoID = null, int? valor = null, int? cantidad = null, string nombre = null, bool tracking = false)
        {
            List<Producto> pagedList = this.Query(productoID: productoID, valor: valor, cantidad: cantidad, nombre: nombre, tracking: tracking).ToList();

            return pagedList;
        }


        public async Task<Producto> GetByIdAsync(int? productoID = null, bool tracking = false)
        {
            return await this.Query(productoID: productoID, tracking: tracking).FirstOrDefaultAsync();
        }

        public IQueryable<Producto> Query(int? productoID = null, int? valor = null, int? cantidad= null, string nombre = null, bool tracking = false)
        {
            IQueryable<Producto> query = tracking ? this.repositoryProducto.Track : this.repositoryProducto.NoTrack;

            if (productoID.HasValue)
            {
                query = query.Where(w => w.ProductoID.Equals(productoID.Value));
            }

            if (valor.HasValue)
            {
                query = query.Where(w => w.Valor.Equals(valor.Value));
            }

            if (cantidad.HasValue)
            {
                query = query.Where(w => w.CantidadDisponible.Equals(cantidad.Value));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(w => w.Nombre.Equals(nombre));
            }

            query = query.OrderBy(ob => ob.ProductoID);

            return query;
        }
    }
}
