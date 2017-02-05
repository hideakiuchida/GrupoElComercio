using BusinessLayer.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationBanco.Models
{
    public class SucursalViewModels
    {
        BancoBL bancoBL = new BancoBL();
        public Dictionary<int, string> bancos { get; set; }

        public SucursalViewModels()
        {
            bancos = new Dictionary<int, string>();
            foreach (var banco in bancoBL.GetAll())
            {
                bancos.Add(banco.BancoID, banco.Nombre);
            }
        }

        [Required]
        [DisplayName("Codigo de Sucursal")]
        public int SurcursalID { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [Required]
        [DisplayName("Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }
       
        [Required]
        [DisplayName("Banco")]
        public Nullable<int> BancoID { get; set; }
    }
}