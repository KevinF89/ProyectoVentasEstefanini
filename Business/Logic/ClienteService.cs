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
    public class ClienteService
    {
        private static Context context = new Context();
        private readonly BaseRepository<Cliente> repositoryCliente = new BaseRepository<Cliente>(context);

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {

            await this.repositoryCliente.InsertAsync(cliente);
            return cliente;
        }

        public async Task<bool> DeleteclienteAsync(int clienteID)
        {
            bool result = false;
            Cliente cliente = this.Query(clienteID: clienteID, tracking: true).FirstOrDefault();

            result = await this.repositoryCliente.DeleteAsync(cliente) > 0 ? true : false;

            return result;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            Cliente updateCliente = this.Query(clienteID: cliente.ClienteID, tracking: true).FirstOrDefault();

            updateCliente.Documento = cliente.Documento;
            updateCliente.TipoDocumentoID = cliente.TipoDocumentoID;
            updateCliente.Nombres = cliente.Nombres;
            updateCliente.Apellidos = cliente.Apellidos;
            updateCliente.Celular = cliente.Celular;
            updateCliente.Correo = cliente.Correo;

            await this.repositoryCliente.UpdateAsync(updateCliente);

            return cliente;
        }

        public async Task<List<Cliente>> GetAsync(int? clienteID = null, int? documentTypeID = null, string document = null, bool tracking = false)
        {
            List<Cliente> pagedList =  this.Query(clienteID: clienteID, documentTypeID: documentTypeID, document: document, tracking: tracking).ToList();

            return pagedList;
        }


        public async Task<Cliente> GetByIdAsync(int? clienteID = null, bool tracking = false)
        {
            return  await this.Query(clienteID: clienteID, tracking: tracking).FirstOrDefaultAsync();
        }

        public IQueryable<Cliente> Query(int? clienteID = null, int? documentTypeID = null, string document = null,  bool tracking = false)
        {
            IQueryable<Cliente> query = tracking ? this.repositoryCliente.Track : this.repositoryCliente.NoTrack;

            if (clienteID.HasValue)
            {
                query = query.Where(w => w.ClienteID.Equals(clienteID.Value));
            }

            if (documentTypeID.HasValue)
            {
                query = query.Where(w => w.TipoDocumentoID.Equals(documentTypeID.Value));
            }

            if (!string.IsNullOrEmpty(document))
            {
                query = query.Where(w => w.Documento.Equals(document));
            }

            query = query.OrderBy(ob => ob.ClienteID);

            return query;
        }
    }
}
