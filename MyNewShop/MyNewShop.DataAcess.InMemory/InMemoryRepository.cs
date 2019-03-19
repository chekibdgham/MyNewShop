using MyNewShop.Core.Contracts;
using MyNewShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyNewShop.DataAcess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T: BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        #region Constructor
        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        } 
        #endregion

        public void Commit()
        {
            cache[className] = items;
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public T Find(string id)
        {
            T t = items.Find(i => i.Id == id);
            if (t!=null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " not found.");
            }
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Delete(string id)
        {
            T TtoDelete = items.Find(d => d.Id == id);
            if (TtoDelete!=null)
            {
                items.Remove(TtoDelete);
            }
            else
            {
                throw new Exception(className + " not Found.");
            }
        }

        public void Update(T t)
        {
            T TToUpdate = items.Find(u => u.Id == t.Id);
            if (TToUpdate!=null)
            {
                TToUpdate = t;
            }
            else
            {
                throw new Exception(className + " not found");
            }
        }


    }
}
