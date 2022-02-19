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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrzaveController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public DrzaveController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<Drzave> GetAll()
        {
            return unitOfWork.Drzava.GetAll().ToList();
        }
        
        [HttpPost]
        public ActionResult Add(string Naziv)
        {
            Drzave drzave = new Drzave();
            drzave.Naziv = Naziv;
            unitOfWork.Drzava.Add(drzave);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
