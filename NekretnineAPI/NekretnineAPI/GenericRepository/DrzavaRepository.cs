using Microsoft.AspNetCore.Mvc;
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
        ApplicationDbContext dbContext1;
        public DrzavaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            dbContext1 = dbContext;
        }

        public override ActionResult Update(Drzave obj)
        {
            var drzava = dbContext1.Drzave.First(x => x.DrzavaID == obj.DrzavaID);
            drzava.Naziv = obj.Naziv;
            OkResult rezultat = new OkResult();
            return rezultat;
        }
    }
}
