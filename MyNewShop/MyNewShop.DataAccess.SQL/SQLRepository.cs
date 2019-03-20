using MyNewShop.Core.Contracts;
using MyNewShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context; 
        internal DbSet<T> dbset;
        public SQLRepository(DataContext _context)
        {
            this.context = _context;
            this.dbset = _context.Set<T>();

        }
        public IQueryable<T> Collection()
        {
           return dbset;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var todelet = dbset.Find(id);
            if (context.Entry(todelet).State==EntityState.Detached)
            {
                dbset.Attach(todelet);
            }
            dbset.Remove(todelet);
        }

        public T Find(string id)
        {
            return dbset.Find(id);
        }

        public void Insert(T t)
        {
            dbset.Add(t);
        }

        public void Update(T t)
        {
            dbset.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
