using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApplication3.Dtos;
using WebApplication3.Models;

namespace WebApplication3.App_Start
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {

            Mapper.CreateMap<Przedmiot, PrzedmiotDto>();
            Mapper.CreateMap<PrzedmiotDto, Przedmiot>()
                .ForMember(c => c.ID, opt => opt.Ignore());
            Mapper.CreateMap<ProducentDto, Producent>();
            Mapper.CreateMap<Producent, ProducentDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Kategoria, KategoriaDto>();
            Mapper.CreateMap<KategoriaDto, Kategoria>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}