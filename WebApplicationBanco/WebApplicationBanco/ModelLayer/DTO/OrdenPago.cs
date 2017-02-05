using System;

namespace ModelLayer.DTO
{
    public class OrdenPago
    {
        public int OrdenPagoID { get; set; }
        public decimal Monto { get; set; }
        public int MonedaID { get; set; }
        public int EstadoID{ get; set; }
        public DateTime FechaPago { get; set; }
        public int SucursalID { get; set; }
    }
}
