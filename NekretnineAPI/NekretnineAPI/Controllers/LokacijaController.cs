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
    public class LokacijaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public LokacijaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public Lokacije GetById(int id)
        {
            return unitOfWork.Lokacija.GetById(id);
        }

        [HttpGet]
        public List<Lokacije> GetAll()
        {
            return unitOfWork.Lokacija.GetAll().ToList();
        }

        [HttpPost]
        public ActionResult Add([FromBody] LokacijeVM lokacijaVM)
        {
            Lokacije lokacija = new Lokacije()
            {
                Broj = lokacijaVM.Broj,
                GradId = lokacijaVM.GradId,
                Ulica = lokacijaVM.Ulica
                
        };
            unitOfWork.Lokacija.Add(lokacija);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult Update([FromBody] LokacijeVM lokacijaVM)
        {
            Lokacije lokacija = new Lokacije()
            {
                Broj = lokacijaVM.Broj,
                Ulica = lokacijaVM.Ulica,
                GradId = lokacijaVM.GradId,
                LokacijaID = lokacijaVM.LokacijaId
            };
            unitOfWork.Lokacija.Update(lokacija);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            unitOfWork.Lokacija.Delete(id);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
