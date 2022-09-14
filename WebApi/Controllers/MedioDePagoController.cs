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
    public class MedioDePagoController : ControllerBase
    {
        private MedioDePagoService medioDePagoService = new MedioDePagoService();

        [ResponseType(typeof(Models.MedioDePago.MedioDePago))]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Data.Entities.MedioDePago> result = await this.medioDePagoService.GetAsync();

            return this.Ok(
                new
                {
                    Data = result.ToListModels()
                });
        }
    }
}
