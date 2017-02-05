using BusinessLayer.Implementation;
using ModelLayer.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebApplicationBanco.Models;

namespace WebApplicationBanco.Controllers
{
    public class OrdenPagoController : Controller
    {
        // GET: OrdenPago
        public ActionResult Index()
        {
            List<OrdenPago> ordenes = new OrdenPagoBL().GetAll();
            List<OrdenPagoViewModels> ordenesVM = new List<OrdenPagoViewModels>();
            if (ordenes != null)
                ordenes.ToList().ForEach(b => ordenesVM.Add(new OrdenPagoViewModels { OrdenPagoID = b.OrdenPagoID, SucursalID = b.SucursalID, MonedaID = b.MonedaID, EstadoID = b.EstadoID, Monto = b.Monto }));
            return View(ordenesVM);
        }

        public ActionResult OrdenPagoByMoneda()
        {
            ViewData["Monedas"] = new SelectList(new MonedaBL().GetAll(), "MonedaID", "Descripcion");
            return Index();
        }

        [HttpPost]
        public ActionResult OrdenPagoByMoneda(FormCollection form)
        {
            int monedaID = Convert.ToInt16(form["Monedas"]);
            List<OrdenPagoViewModels> ordenesVM = new List<OrdenPagoViewModels>();

            RestClient client = new RestClient { BaseUrl = new Uri("http://localhost:55991/") };

            var request = new RestRequest("api/OrdenPagoByMoneda?id={id}", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", monedaID, ParameterType.UrlSegment);

            var response = client.Execute<List<OrdenPago>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);
            response.Data.ToList().ForEach(b => ordenesVM.Add(new OrdenPagoViewModels { OrdenPagoID = b.OrdenPagoID, SucursalID = b.SucursalID, MonedaID = b.MonedaID, EstadoID = b.EstadoID, Monto = b.Monto }));
            ViewData["Monedas"] = new SelectList(new MonedaBL().GetAll(), "MonedaID", "Descripcion");
            return View(ordenesVM);
        }

        // GET: OrdenPago/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
            return View(new OrdenPagoViewModels());
        }

        // POST: OrdenPago/Create
        [HttpPost]
        public ActionResult Create(OrdenPagoViewModels ordenPagoVM)
        {
            if (ModelState.IsValid)
            {
                OrdenPago ordenPago = new OrdenPago { Monto = ordenPagoVM.Monto, MonedaID = (int)ordenPagoVM.MonedaID, EstadoID = (int)ordenPagoVM.EstadoID, FechaPago = ordenPagoVM.FechaPago, SucursalID = (int)ordenPagoVM.SucursalID };
                bool isSucceded = new OrdenPagoBL().Create(ordenPago);
                if (isSucceded)
                    return RedirectToAction("Index");
            }
            return View(ordenPagoVM);
        }

        // GET: OrdenPago/Edit/5
        public ActionResult Edit(int id)
        {
            var ordenPago = new OrdenPagoBL().GetById(id);
            if (ordenPago == null)
            {
                return HttpNotFound();
            }
            OrdenPagoViewModels ordenPagoVM = new OrdenPagoViewModels { OrdenPagoID = ordenPago.OrdenPagoID, Monto = ordenPago.Monto, MonedaID = (int?)ordenPago.MonedaID, EstadoID = (int)ordenPago.EstadoID, FechaPago = ordenPago.FechaPago, SucursalID = (int?)ordenPago.SucursalID };
            return View(ordenPagoVM);
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        public ActionResult Edit(OrdenPagoViewModels ordenPagoVM)
        {
            if (ModelState.IsValid)
            {
                OrdenPago ordenPago = new OrdenPago { OrdenPagoID = ordenPagoVM.OrdenPagoID, Monto = ordenPagoVM.Monto, MonedaID = (int)ordenPagoVM.MonedaID, EstadoID = (int)ordenPagoVM.EstadoID, FechaPago = ordenPagoVM.FechaPago, SucursalID = (int)ordenPagoVM.SucursalID };
                bool isSucceded = new OrdenPagoBL().Update(ordenPago);
                if (isSucceded)
                    return RedirectToAction("Index");
            }

            return View(ordenPagoVM);
        }

        // GET: OrdenPago/Delete/5
        public ActionResult Delete(int id)
        {
            var ordenPago = new OrdenPagoBL().GetById(id);
            if (ordenPago == null)
            {
                return HttpNotFound();
            }
            OrdenPagoViewModels ordenPagoVM = new OrdenPagoViewModels { Monto = ordenPago.Monto, MonedaID = (int?)ordenPago.MonedaID, EstadoID = (int)ordenPago.EstadoID, FechaPago = ordenPago.FechaPago, SucursalID = (int?)ordenPago.SucursalID };
            return View(ordenPagoVM);
        }

        // POST: OrdenPago/Delete/5
        // POST: Banco/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bool isSucceded = new OrdenPagoBL().DeleteByID(id);
            if (isSucceded)
                return RedirectToAction("Index");
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
