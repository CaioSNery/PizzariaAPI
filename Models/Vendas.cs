using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Vendas
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;
    }
}