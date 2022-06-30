using AutoMapper;
using Database;
using Microsoft.EntityFrameworkCore;
using Models.SearchObjects;
using System.Linq;
namespace Services
{
    public class GradoviService : CRUDService<Models.Gradovi, Database.Grad, Models.SearchObjects.GradoviSearchObject, Models.Requests.GradoviInsertRequest, Models.Requests.GradoviUpdateRequest>, IGradoviService
    {
        public GradoviService(NekretnineContext context, IMapper mapper) : base(context, mapper)
    {
    }

        public override IQueryable<Grad> AddFilter(IQueryable<Grad> entity, GradoviSearchObject search)
        {
        if (!string.IsNullOrEmpty(search?.Naziv))
            entity = entity.Where(x => x.Naziv == search.Naziv);
            if (search?.DrzavaId != null )
                entity = entity.Where(x => x.DrzavaId == search.DrzavaId);
            return entity;
        }

        public override Tuple<IList<Models.Gradovi>, BaseSearchObject> GetAll(GradoviSearchObject? search = null)
        {
            var entity = Context.Set<Database.Grad>().Include(x => x.Drzava).AsQueryable();
            if (search != null)
                entity = AddFilter(entity, search);
            var count = entity.Count();
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
                entity = entity.Skip(search.PageSize.Value * (search.Page.Value - 1)).Take(search.PageSize.Value);
            var list = entity.ToList();
            var paginationMetadata = new BaseSearchObject
            {
                TotalCount = count,
                Page = search.Page.Value,
                PageSize = search.PageSize.Value,
                TotalPages = (int)Math.Ceiling((decimal)count / (decimal)search.PageSize)
            };
            var mappedList = Mapper.Map<IList<Models.Gradovi>>(list);
            return new Tuple<IList<Models.Gradovi>, BaseSearchObject>(mappedList, paginationMetadata);

        }



        public override Tuple<Models.Gradovi,BaseSearchObject> GetById(int id)
        {
            var entity = Context.Set<Database.Grad>().Include(x => x.Drzava).First(x=> x.GradId == id);
            var mappedObject = Mapper.Map<Models.Gradovi>(entity);
            var paginationMetadata = new BaseSearchObject { TotalCount = 1, Page = 1, PageSize = 1,TotalPages = 1 };
            return new Tuple<Models.Gradovi, BaseSearchObject>(mappedObject, paginationMetadata);
        }

    }
}
