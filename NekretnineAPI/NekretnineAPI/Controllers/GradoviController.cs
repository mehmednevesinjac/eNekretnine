using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.SearchObjects;
using Services;

namespace NekretnineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoviController : BaseCRUDController<Models.Gradovi, Models.SearchObjects.GradoviSearchObject, Models.Requests.GradoviInsertRequest, Models.Requests.GradoviUpdateRequest>
    {
        public GradoviController(IGradoviService service) : base(service)
        {
        }
    }
}
