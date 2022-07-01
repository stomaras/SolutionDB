using Entities;
using MyDatabase;
using Repositories.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Persistance
{
    public class GenericRepository<T> : IGenericRepository<T> where T : CompanyEntity
    {
        public MyDBContext db;
        public DbSet<T> table;

        public GenericRepository(MyDBContext context)
        {
            db = context;
            table = db.Set<T>();    
        }

        public void Add(T obj)
        {
            db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            var list = table.ToList();
            return list;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            db.Entry(obj).State = EntityState.Added;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
