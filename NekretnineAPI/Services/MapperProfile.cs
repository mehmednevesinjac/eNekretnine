using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Database.Drzave,Models.Drzave>();
            CreateMap<Models.Requests.DrzaveInsertRequest, Database.Drzave>();
            CreateMap<Models.Requests.DrzaveUpdateRequest, Database.Drzave>();

            CreateMap<Database.Grad,Models.Gradovi>();
            CreateMap<Models.Requests.GradoviInsertRequest, Database.Grad>();
            CreateMap<Models.Requests.GradoviUpdateRequest, Database.Grad>();

            CreateMap<Database.Lokacije, Models.Lokacije>();
            CreateMap<Models.Requests.LokacijeInsertRequest, Database.Lokacije>();
            CreateMap<Models.Requests.LokacijeUpdateRequest, Database.Lokacije>();

        }
    }
}
