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
    public class ClienteProductoService
    {
        private static Context context = new Context();
        private readonly BaseRepository<ClienteProducto> repositoryClienteProducto = new BaseRepository<ClienteProducto>(context);

        public async Task<ClienteProducto> InsertClienteProductoAsync(ClienteProducto clienteProducto)
        {

            await this.repositoryClienteProducto.InsertAsync(clienteProducto);


            return clienteProducto;
        }

        public async Task<bool> DeleteClienteProductoAsync(int clienteProductoID)
        {
            bool result = false;
            ClienteProducto clienteProducto = this.Query(clienteProductoID: clienteProductoID, tracking: true).FirstOrDefault();

            result = await this.repositoryClienteProducto.DeleteAsync(clienteProducto) > 0 ? true : false;

            return result;
        }

        public async Task<ClienteProducto> UpdateClienteAsync(ClienteProducto clienteProducto)
        {
            ClienteProducto updateClienteProducto = this.Query(clienteProductoID: clienteProducto.ClienteProductoID, tracking: true).FirstOrDefault();

            updateClienteProducto.ClienteID = clienteProducto.ClienteID;
            updateClienteProducto.ProductoID = clienteProducto.ProductoID;
            updateClienteProducto.ValorTotal = clienteProducto.ValorTotal;
            updateClienteProducto.Cantidad = clienteProducto.Cantidad;
            updateClienteProducto.MedioDePagoID = clienteProducto.MedioDePagoID;

            await this.repositoryClienteProducto.UpdateAsync(updateClienteProducto);

            return clienteProducto;
        }

        public async Task<List<ClienteProducto>> GetAsync(int? clienteProductoID = null, int? clienteID = null, int? productoID = null, int? medioDePagoID = null, bool includeData = false, bool tracking = false)
        {
            List<ClienteProducto> pagedList = this.Query(clienteProductoID: clienteProductoID, clienteID: clienteID, productoID: productoID, medioDePagoID: medioDePagoID, includeData: includeData, tracking: tracking).ToList();

            return pagedList;
        }


        public async Task<ClienteProducto> GetByIdAsync(int? clienteProductoID = null, bool tracking = false)
        {
            return await this.Query(clienteProductoID: clienteProductoID, tracking: tracking).FirstOrDefaultAsync();
        }

        public IQueryable<ClienteProducto> Query(int? clienteProductoID = null, int? clienteID = null, int? productoID = null, int? medioDePagoID =null, bool includeData = false, bool tracking = false)
        {
            IQueryable<ClienteProducto> query = tracking ? this.repositoryClienteProducto.Track : this.repositoryClienteProducto.NoTrack;

            if(includeData)
            {
                query = query.Include(i => i.Producto);
                query = query.Include(i => i.Cliente);
                query = query.Include(i => i.MedioDePago);
            }

            if (clienteProductoID.HasValue)
            {
                query = query.Where(w => w.ClienteProductoID.Equals(clienteProductoID.Value));
            }

            if (clienteID.HasValue)
            {
                query = query.Where(w => w.ClienteID.Equals(clienteID.Value));
            }

            if (medioDePagoID.HasValue)
            {
                query = query.Where(w => w.MedioDePagoID.Equals(medioDePagoID.Value));
            }

            query = query.OrderBy(ob => ob.ClienteProductoID);

            return query;
        }
    }
}
