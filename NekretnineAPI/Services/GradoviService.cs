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

        public override IEnumerable<Models.Gradovi> GetAll(Models.SearchObjects.GradoviSearchObject? search = null)
        {
            var entity = Context.Set<Database.Grad>().Include(x => x.Drzava).AsQueryable();
            if (search != null)
                entity = AddFilter(entity, search);
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
                entity = entity.Take(search.PageSize.Value).Skip(search.PageSize.Value * search.Page.Value);
            var list = entity.ToList();
            return Mapper.Map<IList<Models.Gradovi>>(list);
        }



        public override Models.Gradovi GetById(int id)
        {
            var entity = Context.Set<Database.Grad>().Include(x => x.Drzava).First(x=> x.GradId == id);
            return Mapper.Map<Models.Gradovi>(entity);
        }

    }
}
