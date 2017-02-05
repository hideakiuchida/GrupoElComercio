using System;

namespace ModelLayer.DTO
{
    public class Sucursal
    {
        public int SucursalID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int BancoID { get; set; }
    }
}
