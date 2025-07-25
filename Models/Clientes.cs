using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Endereço { get; set; }
        public required string Telefone { get; set; }
    }
}