using System;

namespace ModelLayer.DTO
{
    public class Banco
    {
        public int BancoID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
