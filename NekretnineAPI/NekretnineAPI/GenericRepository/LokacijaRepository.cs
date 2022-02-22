using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class LokacijaRepository : GenericRepository<Lokacije>, ILokacijaRepository
    {
        ApplicationDbContext dbContext1;
        public LokacijaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            dbContext1 = dbContext;
        }

        public override IEnumerable<Lokacije> GetAll()
        {
            return dbContext1.Lokacije.Include(x => x.Grad).Include(x =>x.Grad.Drzave).ToList();
        }


        public override ActionResult Update(Lokacije obj)
        {
            var lokacija = dbContext1.Lokacije.Include(x => x.Grad).Include(x => x.Grad.Drzave).First(x => x.LokacijaID == obj.LokacijaID);
            lokacija.Broj = obj.Broj;
            lokacija.GradId = obj.GradId;
            lokacija.Ulica = obj.Ulica;
            OkResult rezultat = new OkResult();
            return rezultat;
        }


    }
}
