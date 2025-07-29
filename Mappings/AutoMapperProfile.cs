using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pizzaria.Models;

namespace PizzariaAPI.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VendaDTO, Vendas>()
            .ForMember(dest => dest.ClienteId, opt => opt.Ignore()) 
            .ForMember(dest => dest.PizzaId, opt => opt.Ignore())   
            .ForMember(dest => dest.NomeCliente, opt => opt.Ignore())
            .ForMember(dest => dest.SaborPizza, opt => opt.Ignore())
            .ForMember(dest => dest.ValorTotal, opt => opt.Ignore());
                
    
        }
    }
}