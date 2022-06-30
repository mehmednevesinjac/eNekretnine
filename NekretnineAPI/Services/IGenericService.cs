using Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IGenericService<T,TSearch> where T : class where TSearch : class
    {
        Tuple<T,BaseSearchObject> GetById(int id);
        Tuple<IList<T>,BaseSearchObject> GetAll(TSearch search = null);
    }
}
