using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptainMao.Areas.buy.Models
{
    public interface IMao<T>
    {
        IQueryable<T> GetAll();

        T GetbyID(int id);
        
        void Create(T _entry);
       void Edit(T _entry);
       void DeletebyID(int id);
    }
}
