using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        ActionResult Add(T obj);
        ActionResult Update(T obj);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        ActionResult Delete(object id);
        void Save();
    }
}
