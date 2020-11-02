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
            // Domain para DtoOut
            Mapper.CreateMap<Marca, MarcaDtoOut>();
            Mapper.CreateMap<Patrimonio, PatrimonioDtoOut>();

            // DtoIn para Domain
            Mapper.CreateMap<MarcaDtoIn, Marca>();
            Mapper.CreateMap<PatrimonioDtoIn, Patrimonio>();
        }
    }
}