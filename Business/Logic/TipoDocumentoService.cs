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
    public class TipoDocumentoService
    {
        private static Context context = new Context();
        private readonly BaseRepository<TipoDocumento> repositoryTipoDocumento = new BaseRepository<TipoDocumento>(context);

        public async Task<List<TipoDocumento>> GetAsync(int? tipoDocumentoID = null, string nombre = null, string abreviatura = null, bool tracking = false)
        {
            List<TipoDocumento> pagedList = this.Query(tipoDocumentoID: tipoDocumentoID, nombre: nombre, abreviatura: abreviatura, tracking: tracking).ToList();

            return pagedList;
        }


        public async Task<TipoDocumento> GetByIdAsync(int? tipoDocumentoID = null, bool tracking = false)
        {
            return await this.Query(tipoDocumentoID: tipoDocumentoID, tracking: tracking).FirstOrDefaultAsync();
        }

        public IQueryable<TipoDocumento> Query(int? tipoDocumentoID = null, string nombre = null, string abreviatura= null, bool tracking = false)
        {
            IQueryable<TipoDocumento> query = tracking ? this.repositoryTipoDocumento.Track : this.repositoryTipoDocumento.NoTrack;

            if (tipoDocumentoID.HasValue)
            {
                query = query.Where(w => w.TipoDocumentoID.Equals(tipoDocumentoID.Value));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(w => w.Nombre.Equals(nombre));
            }

            if (!string.IsNullOrEmpty(abreviatura))
            {
                query = query.Where(w => w.Abreviatura.Equals(abreviatura));
            }

            query = query.OrderBy(ob => ob.TipoDocumentoID);

            return query;
        }
    }
}
