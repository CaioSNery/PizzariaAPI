using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class VendaDTO
    {
        public int ClienteId { get; set; }
        public int PizzaId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;

    }
}