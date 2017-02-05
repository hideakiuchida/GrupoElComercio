using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceBanco.Controllers
{
    public class SucursalController : ApiController
    {
        ISucursalBL sucursalBL = new SucursalBL();
        /*[Route("api/SucursalByBanco")]
        [HttpGet]
        public List<Sucursal> GetSucursalByBanco(int id)
        {
            return sucursalBL.GetSucursalByBanco(id);
        }*/

        [Route("api/SucursalByBanco")]
        [HttpGet]
        public IHttpActionResult GetSucursalByBanco(int id)
        {
            return Content(HttpStatusCode.OK, sucursalBL.GetSucursalByBanco(id), Configuration.Formatters.XmlFormatter);
        }

    }
}
