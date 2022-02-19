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
        int Complete();
    }
}
