using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace NekretnineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDController(IGenericService<T, TSearch> service) : base(service)
        {
        }

        [HttpDelete("{id}")]
        public T Delete(int id)
        {
            return ((ICRUDService<T, TSearch, TInsert, TUpdate>)this.Service).Delete(id);
        }

        [HttpPost]
        public T Insert([FromBody]TInsert insert)
        {
            return ((ICRUDService<T, TSearch, TInsert, TUpdate>)this.Service).Insert(insert);
        }

        [HttpPut("{id}")]
        public T Update(int id, TUpdate update)
        {
            return ((ICRUDService<T,TSearch, TInsert, TUpdate>)this.Service).Update(id, update);
        }
    }
}
