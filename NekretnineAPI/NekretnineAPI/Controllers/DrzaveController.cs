﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public Drzave GetById(int id)
        {
            return unitOfWork.Drzava.GetById(id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] DrzavaVM drzavaVM)
        {
            Drzave drzave = new Drzave();
            drzave.Naziv = drzavaVM.Naziv;
            unitOfWork.Drzava.Add(drzave);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpPost("{id}")]
        public ActionResult Update([FromBody] Drzave drzave)
        {
            unitOfWork.Drzava.Update(drzave);
            unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            unitOfWork.Drzava.Delete(id);
            unitOfWork.Complete();
            return Ok();
        }
    }
}
