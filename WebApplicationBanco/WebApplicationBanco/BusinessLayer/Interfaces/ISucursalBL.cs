using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ISucursalBL
    {
        Sucursal GetById(int id);
        List<Sucursal> GetAll();
        bool Create(Sucursal item);
        bool Update(Sucursal item);
        bool DeleteByID(int? id);
        List<Sucursal> GetSucursalByBanco(int id);
    }
}
