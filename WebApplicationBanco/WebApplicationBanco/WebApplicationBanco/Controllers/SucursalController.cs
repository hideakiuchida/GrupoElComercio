using BusinessLayer.Implementation;
using ModelLayer.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationBanco.Models;

namespace WebApplicationBanco.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Surcursal
        public ActionResult Index()
        {
            List<Sucursal> sucursales = new SucursalBL().GetAll();
            List<SucursalViewModels> sucursalesVM = new List<SucursalViewModels>();
            if (sucursales != null)
                sucursales.ToList().ForEach(b => sucursalesVM.Add(new SucursalViewModels {SurcursalID = b.SucursalID, BancoID = b.BancoID, Direccion = b.Direccion, Nombre = b.Nombre, FechaRegistro = b.FechaRegistro }));
            return View(sucursalesVM);
        }

        // GET: Surcursal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Surcursal/Create
        public ActionResult Create()
        {
            return View(new SucursalViewModels());
        }

        // POST: Surcursal/Create
        [HttpPost]
        public ActionResult Create(SucursalViewModels sucursalVM)
        {
            if (ModelState.IsValid)
            {
                Sucursal sucursal = new Sucursal { BancoID = (int) sucursalVM.BancoID, Direccion = sucursalVM.Direccion, Nombre = sucursalVM.Nombre, FechaRegistro = sucursalVM.FechaRegistro };
                bool isSucceded = new SucursalBL().Create(sucursal);
                if (isSucceded)
                    return RedirectToAction("Index");
            }
            return View(sucursalVM);
        }

        public ActionResult SucursalByBanco()
        {
            ViewData["Bancos"] = new SelectList(new BancoBL().GetAll(), "BancoID", "Nombre");
            return Index();
        }

        [HttpPost]
        public ActionResult SucursalByBanco(FormCollection form)
        {
            int bancoID = Convert.ToInt16(form["Bancos"]);
            List<SucursalViewModels> sucursalesVM = new List<SucursalViewModels>();

            RestClient client = new RestClient { BaseUrl = new Uri("http://localhost:55991/") };

            var request = new RestRequest("api/SucursalByBanco?id={id}", Method.GET) { RequestFormat = DataFormat.Xml };
            request.AddParameter("id", bancoID, ParameterType.UrlSegment);

            var response = client.Execute<List<Sucursal>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);
            response.Data.ToList().ForEach(b => sucursalesVM.Add(new SucursalViewModels { SurcursalID = b.SucursalID, BancoID = b.BancoID, Direccion = b.Direccion, Nombre = b.Nombre, FechaRegistro = b.FechaRegistro }));
            ViewData["Bancos"] = new SelectList(new BancoBL().GetAll(), "BancoID", "Nombre");
            return View(sucursalesVM);
        }

        // GET: Surcursal/Edit/5
        public ActionResult Edit(int id)
        {
            var sucursal = new SucursalBL().GetById(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            SucursalViewModels sucursalVM = new SucursalViewModels { SurcursalID = sucursal.SucursalID, BancoID = sucursal.BancoID, Direccion = sucursal.Direccion, Nombre = sucursal.Nombre, FechaRegistro = sucursal.FechaRegistro };
            return View(sucursalVM);
        }

        // POST: Surcursal/Edit/5
        [HttpPost]
        public ActionResult Edit(SucursalViewModels sucursalVM)
        {
            if (ModelState.IsValid)
            {
                Sucursal sucursal = new Sucursal { SucursalID = sucursalVM.SurcursalID, BancoID = (int)sucursalVM.BancoID, Direccion = sucursalVM.Direccion, Nombre = sucursalVM.Nombre, FechaRegistro = sucursalVM.FechaRegistro };
                bool isSucceded = new SucursalBL().Update(sucursal);
                if (isSucceded)
                    return RedirectToAction("Index");
            }

            return View(sucursalVM);
        }

        // GET: Surcursal/Delete/5
        public ActionResult Delete(int id)
        {
            var sucursal = new SucursalBL().GetById(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            SucursalViewModels sucursalVM = new SucursalViewModels { BancoID = sucursal.BancoID, Direccion = sucursal.Direccion, Nombre = sucursal.Direccion, FechaRegistro = sucursal.FechaRegistro };
            return View(sucursalVM);
        }

        // POST: Surcursal/Delete/5
        // POST: Banco/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bool isSucceded = new SucursalBL().DeleteByID(id);
            if (isSucceded)
                return RedirectToAction("Index");
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
