using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Pizzaria.Models;

namespace PizzariaAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VendaDTO, Vendas>()
            .ForMember(dest => dest.PizzaId, opt => opt.MapFrom(src => src.PizzaId))
            .ForMember(dest => dest.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
            .ForMember(dest => dest.Cliente, opt => opt.Ignore())
            .ForMember(dest => dest.Pizza, opt => opt.Ignore())
            .ForMember(dest => dest.ValorTotal, opt => opt.Ignore());


        }
    }
}