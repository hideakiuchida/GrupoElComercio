using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBancoBL
    {
        Banco GetById(int id);
        List<Banco> GetAll();
        bool Create(Banco item);
        bool Update(Banco item);
        bool DeleteByID(int? id);
    }
}
