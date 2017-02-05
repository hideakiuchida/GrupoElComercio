using BusinessLayer.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationBanco.Models
{
    public class OrdenPagoViewModels
    {
        SucursalBL sucursalBL = new SucursalBL();
        MonedaBL monedaBL = new MonedaBL();
        EstadoBL estadoBL = new EstadoBL();
        public Dictionary<int, string> sucursales { get; set; }
        public Dictionary<int, string> monedas { get; set; }
        public Dictionary<int, string> estados { get; set; }

        public OrdenPagoViewModels()
        {
            sucursales = new Dictionary<int, string>();
            monedas = new Dictionary<int, string>();
            estados = new Dictionary<int, string>();
            foreach (var sucursal in sucursalBL.GetAll())
            {
                sucursales.Add(sucursal.SucursalID, sucursal.Nombre);
            }
            foreach (var moneda in monedaBL.GetAll())
            {
                monedas.Add(moneda.MonedaID, moneda.Descripcion);
            }
            foreach (var estado in estadoBL.GetAll())
            {
                estados.Add(estado.EstadoID, estado.Descripcion);
            }
        }

        [DisplayName("Codigo de Orden")]
        [Required]
        public int OrdenPagoID { get; set; }

        [DisplayName("Monto")]
        [Required]
        public decimal Monto { get; set; }

        [DisplayName("Moneda")]
        [Required]
        public Nullable<int> MonedaID { get; set; }

        [DisplayName("Estado")]
        [Required]
        public Nullable<int> EstadoID { get; set; }

        [DisplayName("Fecha de Pago")]
        [Required]
        public DateTime FechaPago { get; set; }

        [DisplayName("Sucursal")]
        [Required]
        public Nullable<int> SucursalID { get; set; }
    }
}