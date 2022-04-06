using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IDrzaveService : ICRUDService<Models.Drzave,Models.SearchObjects.DrzavaSearchObject,Models.Requests.DrzaveInsertRequest,Models.Requests.DrzaveUpdateRequest>
    {
    }
}
