using BusinessLayer.Implementation;
using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Interfaces;

namespace WebServiceBanco.Controllers
{
    public class OrdenPagoController : ApiController
    {
        IOrdenPagoBL ordenPago = new OrdenPagoBL();
        [Route("api/OrdenPagoByMoneda")]
        [HttpGet]
        public List<OrdenPago> GetOrdenPagoByMoneda(int id)
        {
            return ordenPago.GetOrdenPagoByMoneda(id);
        }
    }
}
