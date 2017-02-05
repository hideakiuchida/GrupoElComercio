using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationBanco.Models
{
    public class BancoViewModels
    {
        [DisplayName("Código de Banco")]
        [Required]
        public int BancoID { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [DisplayName("Fecha de Registro")]
        [Required]
        public DateTime FechaRegistro { get; set; }
    }
}