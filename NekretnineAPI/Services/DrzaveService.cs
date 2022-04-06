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
    public class DrzaveService : CRUDService<Models.Drzave, Database.Drzave, Models.SearchObjects.DrzavaSearchObject, Models.Requests.DrzaveInsertRequest, Models.Requests.DrzaveUpdateRequest>, IDrzaveService
    {
        public DrzaveService(NekretnineContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Drzave> AddFilter(IQueryable<Drzave> entity, DrzavaSearchObject search)
        {
            if (!string.IsNullOrEmpty(search?.Naziv))
                entity = entity.Where(x => x.Naziv == search.Naziv);
            return entity;
        }
    }
}
