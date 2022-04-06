using AutoMapper;
using Database;
using Microsoft.EntityFrameworkCore;
using Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LokacijeService : CRUDService<Models.Lokacije, Database.Lokacije, Models.SearchObjects.LokacijeSearchObject, Models.Requests.LokacijeInsertRequest, Models.Requests.LokacijeUpdateRequest>, ILokacijeService
    {
        public LokacijeService(NekretnineContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Lokacije> AddFilter(IQueryable<Lokacije> entity, LokacijeSearchObject search)
        {
            if (search.Broj != null)
                entity = entity.Where(x => x.Broj == search.Broj);
            if (search?.Ulica != null)
                entity = entity.Where(x => x.Ulica == search.Ulica);
            if (search?.GradId != null)
            {
                entity = entity.Where(x => x.GradId == search.GradId);
            }
            return entity;
        }

        public override IEnumerable<Models.Lokacije> GetAll(Models.SearchObjects.LokacijeSearchObject? search = null)
        {
            var entity = Context.Set<Database.Lokacije>().Include(x => x.Grad).Include(x => x.Grad.Drzava).AsQueryable();
            if (search != null)
                entity = AddFilter(entity, search);
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
                entity = entity.Take(search.PageSize.Value).Skip(search.PageSize.Value * search.Page.Value);
            var list = entity.ToList();
            return Mapper.Map<IList<Models.Lokacije>>(list);
        }



        public override Models.Lokacije GetById(int id)
        {
            var entity = Context.Set<Database.Lokacije>().Include(x => x.Grad).Include(x => x.Grad.Drzava).First(x => x.LokacijaId == id);
            return Mapper.Map<Models.Lokacije>(entity);
        }
    }
}
