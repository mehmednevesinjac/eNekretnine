using NekretnineAPI.Data;
using NekretnineAPI.Model;
using NekretnineAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.GenericRepository
{
    public class DrzavaRepository : GenericRepository<Drzave>, IDrzavaRepository
    {
        public DrzavaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        
    }
}
