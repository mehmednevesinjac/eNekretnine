using Models;
using Models.SearchObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekretnineAPI.Controllers
{
    public class LokacijeController : BaseCRUDController<Models.Lokacije, Models.SearchObjects.LokacijeSearchObject, Models.Requests.LokacijeInsertRequest, Models.Requests.LokacijeUpdateRequest>
    {
        public LokacijeController(ILokacijeService service) : base(service)
        {
        }
    }
}
