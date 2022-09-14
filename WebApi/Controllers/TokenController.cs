using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Functions;
using WebApi.Models.Otros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        public IConfiguration Configuration { get; private set; }
        public TokenController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("~/api/GetToken")]
        [HttpGet]
        public async Task<RespuestaToken> GetToken(string Token)
        {

            var secr = Configuration.GetSection("Settings").GetSection("SecretKey").Value;
            var time = Configuration.GetSection("Settings").GetValue<double>("JWT_EXPIRE_MINUTES");
            var Acceso = Configuration.GetSection("Settings").GetSection("Token_Valido").Value;
            var param = HttpContext.Request.QueryString.ToString();
            RespuestaToken Res = new RespuestaToken();


            try
            {
                //Esto se cambiaría por validación en base de datos de un  login
                if (Acceso == Token)
                {
                    var tokenGT = new TokenGenerator();
                    Res.Valido = true;
                    Res.Error = "";
                    Res.Token = tokenGT.GenerateTokenJwt(Token, secr, time);


                }
                else
                {
                    Res.Valido = false;
                    Res.Error = "Token Incorrecto";
                    Res.Token = "";

                }
            }
            catch (Exception ex)
            {

                Res.Valido = false;
                Res.Error = ex.Message;
            }

            return Res;
        }
    }
}