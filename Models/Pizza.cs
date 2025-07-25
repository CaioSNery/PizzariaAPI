using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public required string Sabor { get; set; }
        public required string Tamanho { get; set; }
        public decimal ValorPizza{get;set;}
        
    }
}