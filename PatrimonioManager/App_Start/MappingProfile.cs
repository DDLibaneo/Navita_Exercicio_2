using AutoMapper;
using PatrimonioManager.Dtos;
using PatrimonioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatrimonioManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain para Dto
            Mapper.CreateMap<Marca, MarcaDto>();
            Mapper.CreateMap<Patrimonio, PatrimonioDto>();

            // Dto para Domain
            Mapper.CreateMap<MarcaDto, Marca>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<PatrimonioDto, Patrimonio>().ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}