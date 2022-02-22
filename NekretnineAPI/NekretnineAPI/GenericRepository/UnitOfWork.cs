using NekretnineAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            Drzava = new DrzavaRepository(context);
            Grad = new GradRepository(context);
            Lokacija = new LokacijaRepository(context);
        }

        public IDrzavaRepository Drzava { get; private set; }

        public IGradRepository Grad { get; private set; }

        public ILokacijaRepository Lokacija { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
