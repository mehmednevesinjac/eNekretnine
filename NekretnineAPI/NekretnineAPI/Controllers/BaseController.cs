using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace NekretnineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IGenericService<T,TSearch> Service { get; set; }

        public BaseController(IGenericService<T,TSearch> service)
        {
            Service = service;
        }

        [HttpGet]
        public IEnumerable<T> GetAll([FromQuery]TSearch? search = null)
        {
            return Service.GetAll(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return Service.GetById(id);
        }
    }
}
