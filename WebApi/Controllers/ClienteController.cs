using Business.Logic;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using WebApi.MappingExtensions;
using WebApi.Models.Cliente;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private ClienteService clienteService = new ClienteService();

        [ResponseType(typeof(Models.Cliente.UpdateCliente))]
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] FilterCliente filter)
        {
            List<Cliente> result = await this.clienteService.GetAsync(document: filter.Documento, clienteID: filter.ClienteID, documentTypeID: filter.TipoDocumentoID);

            return this.Ok(
                new 
                {
                    Data = result.ToListModels()
                });
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateCliente model)
        {
            if (ModelState.IsValid)
            {
                Cliente inserResult = this.clienteService.InsertClienteAsync(model.ToEntity()).Result;


                return this.Ok(
                    new
                    {
                        Data = inserResult.ToModel()
                    }) ;
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UpdateCliente model)
        {
            if (ModelState.IsValid)
            {
                Cliente updateResult = this.clienteService.UpdateClienteAsync(model.ToEntity()).Result;


                return this.Ok(
                    new 
                    {
                        Data = updateResult,
                    });
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int clienteId)
        {
            if (ModelState.IsValid)
            {
                bool updateResult = this.clienteService.DeleteclienteAsync(clienteID: clienteId).Result;


                return this.Ok(
                    new 
                    {
                        Data = updateResult
                    });
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }
    }
}
