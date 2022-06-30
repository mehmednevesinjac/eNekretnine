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
        public virtual Tuple<IList<T>, BaseSearchObject> GetAll(TSearch? search = null)
        {
            var entity = Context.Set<TDb>().AsQueryable();
            if (search != null)
                entity = AddFilter(entity, search);
            var count = entity.Count();
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
                entity = entity.Skip(search.PageSize.Value * (search.Page.Value - 1)).Take(search.PageSize.Value);
            var list = entity.ToList();
            BaseSearchObject paginationMetadata;
            if (search?.PageSize != null)   
            {
                paginationMetadata = new BaseSearchObject
                {
                    TotalCount = count,
                    Page = search?.Page.Value,
                    PageSize = search.PageSize.Value,
                    TotalPages = (int)Math.Ceiling((decimal)count / (decimal)search.PageSize)
                };
            }
                else
                {
                    paginationMetadata = new BaseSearchObject
                    {
                        TotalCount = count
                    };
                }  
            var mappedList = Mapper.Map<IList<T>>(list);
            return new Tuple<IList<T>,BaseSearchObject>(mappedList, paginationMetadata);
           
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }

        public virtual Tuple<T,BaseSearchObject> GetById(int id)
        {
            var entity = Context.Set<TDb>().Find(id);
            var mappedObject = Mapper.Map<T>(entity);
            var paginationMetadata = new BaseSearchObject { TotalCount = 1, Page = 1, PageSize = 1, TotalPages = 1 };
            return new Tuple<T, BaseSearchObject>(mappedObject, paginationMetadata);
        }
    }
}
