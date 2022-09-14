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
using WebApi.Models.ClienteProducto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteProductoController : ControllerBase
    {
        private ClienteProductoService clienteService = new ClienteProductoService();

        [ResponseType(typeof(Models.ClienteProducto.ClienteProducto))]
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] FilterClienteProducto filter)
        {
            List<Data.Entities.ClienteProducto> result = await this.clienteService.GetAsync(clienteID: filter.ClienteID, productoID: filter.ProductoID, clienteProductoID: filter.ClienteProductoID);

            return this.Ok(
                new
                {
                    Data = result.ToListModels()
                });
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateClienteProducto model)
        {
            if (ModelState.IsValid)
            {
                Data.Entities.ClienteProducto inserResult = this.clienteService.InsertClienteProductoAsync(model.ToEntity()).Result;


                return this.Ok(
                    new
                    {
                        Data = inserResult.ToModel()
                    });
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }


        [HttpDelete]
        public ActionResult Delete(int clienteProductoId)
        {
            if (ModelState.IsValid)
            {
                bool updateResult = this.clienteService.DeleteClienteProductoAsync(clienteProductoID: clienteProductoId).Result;


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
