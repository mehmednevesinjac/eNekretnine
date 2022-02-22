using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NekretnineAPI.Data;
using NekretnineAPI.GenericRepository;
using NekretnineAPI.Model;
using NekretnineAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public GradController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<Grad> GetAll()
        {
            return unitOfWork.Grad.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Grad GetById(int id)
        {
            return unitOfWork.Grad.GetById(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            unitOfWork.Grad.Delete(id);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult Update([FromBody] Grad grad)
        {
            unitOfWork.Grad.Update(grad);
            unitOfWork.Complete();
            return Ok();
        }
        [HttpPost]
        public ActionResult Add([FromBody]GradVM gradVM)
        {
            Grad grad = new Grad
            {
                Naziv = gradVM.Naziv,
                DrzavaId = gradVM.DrzavaId
            };
            unitOfWork.Grad.Add(grad);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
