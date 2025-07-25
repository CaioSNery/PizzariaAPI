using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class VendaDTO
    {
        public required string NomeCliente { get; set; }
        public required string IdPizza { get; set; }
        public int Quantidade { get; set; }
        public DateTime DateVenda { get; set; } = DateTime.Now;

    }
}