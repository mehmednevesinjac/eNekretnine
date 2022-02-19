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

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public ActionResult Add(T obj)
        {
            dbContext.Set<T>().Add(obj);
            OkResult rezultat = new OkResult();
            return rezultat;
        }

        public ActionResult Delete(object id)
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

        public ActionResult Update(T obj)
        {
            dbContext.Set<T>().Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
            OkResult rezultat = new OkResult();
            return rezultat;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);
        }
    }
}
