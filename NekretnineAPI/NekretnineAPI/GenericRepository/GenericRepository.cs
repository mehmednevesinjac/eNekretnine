using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NekretnineAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public virtual ActionResult Add(T obj)
        {
            dbContext.Set<T>().Add(obj);
            OkResult rezultat = new OkResult();
            return rezultat;
        }

        public ActionResult Delete(int id)
        {
            T existing = dbContext.Set<T>().Find(id);
            dbContext.Set<T>().Remove(existing);
            if(existing != null)
            {
                OkResult rezultat = new OkResult();
                return rezultat;
            }
            else
            {
                NotFoundResult rezultat = new NotFoundResult();
                return rezultat;
            }

        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public virtual ActionResult Update(T obj)
        {
            return new NotFoundResult();   
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);
        }
    }
}
