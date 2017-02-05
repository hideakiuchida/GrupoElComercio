using BusinessLayer.Implementation;
using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationBanco.Models;

namespace WebApplicationBanco.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            List<Banco> bancos = new BancoBL().GetAll();
            List<BancoViewModels> bancosVM = new List<BancoViewModels>();
            if(bancos!=null)
                bancos.ToList().ForEach(b => bancosVM.Add(new BancoViewModels { BancoID =  b.BancoID, Direccion = b.Direccion, Nombre = b.Nombre, FechaRegistro = b.FechaRegistro}));
            return View(bancosVM);
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View(new BancoViewModels());
        }

        // POST: Banco/Create
        [HttpPost]
        public ActionResult Create(BancoViewModels bancoVM)
        {
            if (ModelState.IsValid)
            {
                Banco banco = new Banco { Direccion = bancoVM.Direccion, Nombre = bancoVM.Nombre, FechaRegistro = bancoVM.FechaRegistro };
                bool isSucceded = new BancoBL().Create(banco);
                if (isSucceded)
                    return RedirectToAction("Index");
            }
            return View(bancoVM);
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int id)
        {
            var banco = new BancoBL().GetById(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            BancoViewModels bancoVM = new BancoViewModels { BancoID = banco.BancoID, Direccion = banco.Direccion, Nombre = banco.Nombre, FechaRegistro = banco.FechaRegistro };
            return View(bancoVM);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit(BancoViewModels bancoVM)
        {
            if (ModelState.IsValid)
            {
                Banco banco = new Banco {BancoID = bancoVM.BancoID, Direccion = bancoVM.Direccion, Nombre = bancoVM.Nombre, FechaRegistro = bancoVM.FechaRegistro };
                bool isSucceded = new BancoBL().Update(banco);
                if (isSucceded)
                    return RedirectToAction("Index");
            }

            return View(bancoVM);
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            var banco = new BancoBL().GetById(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            BancoViewModels bancoVM = new BancoViewModels { BancoID = banco.BancoID, Direccion = banco.Direccion, Nombre = banco.Direccion, FechaRegistro = banco.FechaRegistro };
            return View(bancoVM);
        }

        // POST: Banco/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {                 
           bool isSucceded = new BancoBL().DeleteByID(id);
            if (isSucceded)
                return RedirectToAction("Index");
            else
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
