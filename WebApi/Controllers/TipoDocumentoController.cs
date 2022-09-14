using Business.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using WebApi.MappingExtensions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private TipoDocumentoService tipoDocumentoService = new TipoDocumentoService();

        [ResponseType(typeof(Models.TipoDeDocumento.TipoDeDocumento))]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Data.Entities.TipoDocumento> result = await this.tipoDocumentoService.GetAsync();

            return this.Ok(
                new
                {
                    Data = result.ToListModels()
                });
        }
    }
}
