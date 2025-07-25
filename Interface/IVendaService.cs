using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzaria.Models;

namespace Pizzaria.Interface
{
    public interface IVendaService
    {
        Task<object> RealizarVendaAsync(VendaDTO dto);
        
        Task<IEnumerable<Vendas>> ObterVendasAsync();

        Task<Vendas> ObterVendasPorIdAsync(int id);
    }
}