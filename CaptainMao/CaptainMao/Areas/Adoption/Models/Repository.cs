using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaptainMao.Areas.Adoption.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MaoEntities db = new MaoEntities();
        private DbSet<T> dbset = null;

        public Repository()
        {
            dbset = db.Set<T>();
        }

        public void Create(T _entity)
        {
            dbset.Add(_entity);
            db.SaveChanges();
        }

        public void Delete(T _entity)
        {
            dbset.Remove(_entity);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetByID(int id)
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