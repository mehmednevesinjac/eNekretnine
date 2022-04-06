using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.SearchObjects;
using Services;

namespace NekretnineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrzaveController : BaseCRUDController<Models.Drzave, Models.SearchObjects.DrzavaSearchObject, Models.Requests.DrzaveInsertRequest, Models.Requests.DrzaveUpdateRequest>
    {
        public DrzaveController(IDrzaveService service) : base(service)
        {
        }
    }
}
