using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOrdenPagoBL
    {
        OrdenPago GetById(int id);
        List<OrdenPago> GetAll();
        bool Create(OrdenPago item);
        bool Update(OrdenPago item);
        bool DeleteByID(int? id);
        List<OrdenPago> GetOrdenPagoByMoneda(int monedaID);
    }
}
