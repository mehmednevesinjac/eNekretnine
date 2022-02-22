using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.GenericRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IDrzavaRepository Drzava { get; }
        public IGradRepository Grad { get; }
        public ILokacijaRepository Lokacija { get; }


        int Complete();
    }
}
