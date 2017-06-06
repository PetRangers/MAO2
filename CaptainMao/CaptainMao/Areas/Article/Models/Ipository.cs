using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptainMao.Areas.Article.Models
{
    interface Ipository<T>
    {
        T GetID(int id);
        IEnumerable<T> GetAll();
        void Create(T _entity);
        void Delete(T _entity);
        void Update(T _entity);
    }
}
