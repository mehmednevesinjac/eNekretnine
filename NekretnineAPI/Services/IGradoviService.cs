using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IGradoviService : ICRUDService<Models.Gradovi, Models.SearchObjects.GradoviSearchObject, Models.Requests.GradoviInsertRequest, Models.Requests.GradoviUpdateRequest>
    {
    }
}
