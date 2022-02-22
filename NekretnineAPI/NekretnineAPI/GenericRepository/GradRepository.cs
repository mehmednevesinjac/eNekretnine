using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NekretnineAPI.Data;
using NekretnineAPI.Model;
using NekretnineAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.GenericRepository
{
    public class GradRepository : GenericRepository<Grad>, IGradRepository
    {
        public ApplicationDbContext dbContext1 { get; set; }
        public GradRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            dbContext1 = dbContext;
        }

        public override IEnumerable<Grad> GetAll()
        {
            return dbContext1.Grad.Include(x => x.Drzave).ToList();
        }

        public override ActionResult Update(Grad obj)
        {
            var grad = dbContext1.Grad.Include(x => x.Drzave).First(x => x.GradId == obj.GradId);
            grad.Naziv = obj.Naziv;
            grad.DrzavaId = obj.DrzavaId;
            OkResult rezultat = new OkResult();
            return rezultat;
        }


    }
}
