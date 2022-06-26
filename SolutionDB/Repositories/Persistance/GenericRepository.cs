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

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            var list = table.ToList();
            return list;
        }

        public IEnumerable<T> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
