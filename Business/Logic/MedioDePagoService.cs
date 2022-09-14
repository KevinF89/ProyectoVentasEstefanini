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
    public class MedioDePagoService
    {
        private static Context context = new Context();
        private readonly BaseRepository<MedioDePago> repositoryMedioDePago = new BaseRepository<MedioDePago>(context);

        public async Task<List<MedioDePago>> GetAsync(int? medioDePagoID = null, string nombre = null, bool tracking = false)
        {
            List<MedioDePago> pagedList =  this.Query(medioDePagoID: medioDePagoID, nombre: nombre, tracking: tracking).ToList();

            return pagedList;
        }


        public async Task<MedioDePago> GetByIdAsync(int? medioDePagoID = null, bool tracking = false)
        {
            return await this.Query(medioDePagoID: medioDePagoID, tracking: tracking).FirstOrDefaultAsync();
        }

        public IQueryable<MedioDePago> Query(int? medioDePagoID = null, string nombre = null, bool tracking = false)
        {
            IQueryable<MedioDePago> query = tracking ? this.repositoryMedioDePago.Track : this.repositoryMedioDePago.NoTrack;

            if (medioDePagoID.HasValue)
            {
                query = query.Where(w => w.MedioDePagoID.Equals(medioDePagoID.Value));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(w => w.Nombre.Equals(nombre));
            }

            query = query.OrderBy(ob => ob.MedioDePagoID);

            return query;
        }
    }
}
