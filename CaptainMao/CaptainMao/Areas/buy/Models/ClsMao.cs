using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.buy.Models
{
    public class ClsMao<T> : IMao<T> where T : class
    {
        global::CaptainMao.Models.MaoEntities MaoDB = new CaptainMao.Models.MaoEntities();
        DbSet<T> dbset = null;

        public ClsMao() {
            dbset = MaoDB.Set<T>();
            //MaoDB.Configuration.ProxyCreationEnabled = false;
        }

        public void Create(T _entry)
        {
            dbset.Add(_entry);
            MaoDB.SaveChanges();
        }




        public void DeletebyID(int id)
        {
            dbset.Remove(GetbyID(id));
            MaoDB.SaveChanges();
        }

  
        public void Edit(T _entry)
        {
            MaoDB.Entry(_entry).State = EntityState.Modified;
            MaoDB.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return dbset;
        }

        public T GetbyID(int id)
        {
            return dbset.Find(id);
        }

    }
}