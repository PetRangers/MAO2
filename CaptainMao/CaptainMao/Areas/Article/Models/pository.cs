using CaptainMao.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Article.Models
{
    public class pository<T> : Ipository<T> where T : class
    {
        private MaoEntities db = null;
        private DbSet<T> dbset = null;
        public pository()
        {
            db = new MaoEntities();
            dbset = db.Set<T>();
        }
        public void Create(T _entity)
        {
            dbset.Add(_entity);
            db.SaveChanges();
        }

        public void Delete(T _entity)
        {
            
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetID(int id)
        {
            return dbset.Find(id);
        }

        public void Update(T _entity)
        {
            db.Entry(_entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}