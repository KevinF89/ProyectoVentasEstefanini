using Business.Logic;
using Data.Entities;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using WebApi.MappingExtensions;
using WebApi.Models.Cliente;
using IHttpActionResult= System.Web.Http.IHttpActionResult;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteService clienteService = new ClienteService();



        [ResponseType(typeof(UpdateCliente))]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Cliente cliente = await this.clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return (IHttpActionResult)this.NotFound();
            }

            return (IHttpActionResult)this.Ok(cliente.ToModel());
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get([System.Web.Http.FromUri] FilterCliente filter)
        {
            List<Cliente> result = await this.clienteService.GetAsync(document: filter.Documento, clienteID: filter.ClienteID, documentTypeID: filter.TipoDocumentoID);

            return (IHttpActionResult)this.Ok(
                new 
                {
                    Data = result.ToListModels()
                });
        }

        // POST: api/Mecanicos
        [HttpPost]
        public IHttpActionResult Post([FromBody] CreateCliente model)
        {
            if (ModelState.IsValid)
            {
                var inserResult = this.clienteService.InsertClienteAsync(model.ToEntity());


                return (IHttpActionResult)this.Ok(
                    new 
                    {
                        Data = inserResult
                    });
            }
            else
            {
                return (IHttpActionResult)this.BadRequest(ModelState);
            }
        }

        // PUT: api/Mecanicos/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] UpdateCliente model)
        {
            if (ModelState.IsValid)
            {
                Cliente updateResult = this.clienteService.UpdateClienteAsync(model.ToEntity()).Result;


                return (IHttpActionResult)this.Ok(
                    new 
                    {
                        Data = updateResult,
                    });
            }
            else
            {
                return (IHttpActionResult)this.BadRequest(ModelState);
            }
        }

        // DELETE: api/Mecanicos/5
        [HttpDelete]
        public IHttpActionResult Delete(string tipoDocumento, int documento)
        {
            if (ModelState.IsValid)
            {
                bool updateResult = this.clienteService.DeleteMecanico(tipoDocumento: tipoDocumento, documento: documento);


                return this.Ok(
                    new Response<bool>
                    {
                        Data = updateResult,
                        Valido = updateResult
                    });
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }
    }
}
