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
using WebApi.Models.Producto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private ProductoService productoService = new ProductoService();

        [ResponseType(typeof(Models.Producto.UpdateProducto))]
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] FilterProducto filter)
        {
            List<Producto> result = await this.productoService.GetAsync(productoID: filter.ProductoID, nombre: filter.Nombre);

            return this.Ok(
                new
                {
                    Data = result.ToListModels()
                });
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateProducto model)
        {
            if (ModelState.IsValid)
            {
                Producto inserResult = this.productoService.InsertProductoAsync(model.ToEntity()).Result;


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

        [HttpPut]
        public ActionResult Put([FromBody] UpdateProducto model)
        {
            if (ModelState.IsValid)
            {
                Producto updateResult = this.productoService.UpdateProductoAsync(model.ToEntity()).Result;


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
        public ActionResult Delete(int productoId)
        {
            if (ModelState.IsValid)
            {
                bool updateResult = this.productoService.DeleteproductoAsync(productoID: productoId).Result;


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
