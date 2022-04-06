using AutoMapper;
using Database;
using Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CRUDService<T, TDb, TSearch, TInsert, TUpdate> : GenericService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate>
        where T : class where TDb : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public CRUDService(NekretnineContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public T Delete(int id)
        {
            var entity = Context.Set<TDb>().Find(id);
            if (entity != null)
            {
                Context.Set<TDb>().Remove(entity);
                Context.SaveChanges();
            }
            return Mapper.Map<T>(entity);
        }

        public virtual T Insert(TInsert insert)
        {
            var set = Context.Set<TDb>();

            var entity = Mapper.Map<TDb>(insert);
    
            set.Add(entity);

            Context.SaveChanges();

            return Mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate update)
        {
            var entity = Context.Set<TDb>().Find(id);
            if(entity == null)
                return null;
            Mapper.Map(update,entity);
            Context.SaveChanges();
            return Mapper.Map<T>(entity);
           
        }
    }
}
