using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;
using System.Text.Json;

namespace NekretnineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var tuple = Service.GetAll(search);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(tuple.Item2));
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
            return tuple.Item1;
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            var tuple = Service.GetById(id);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(tuple.Item2));
            return tuple.Item1;
        }
    }
}
