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
    public class GenericService<T, TDb, TSearch> : IGenericService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        public NekretnineContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public GenericService(NekretnineContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public virtual IEnumerable<T> GetAll(TSearch search = null)
        {
            var entity = Context.Set<TDb>().AsQueryable();
            if (search != null)
                entity = AddFilter(entity, search);
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
                entity = entity.Take(search.PageSize.Value).Skip(search.PageSize.Value * search.Page.Value);
            var list = entity.ToList();
            return Mapper.Map<IList<T>>(list);
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

        public virtual T GetById(int id)
        {
            var entity = Context.Set<TDb>().Find(id);
            return Mapper.Map<T>(entity);
        }
    }
}
