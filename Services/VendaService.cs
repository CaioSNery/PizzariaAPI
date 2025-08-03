using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Interface;
using Pizzaria.Models;

namespace Pizzaria.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;
        private readonly ISMSService _smsService;

        private readonly IMapper _mapper;
        public VendaService(AppDbContext context, ISMSService smsService, IMapper mapper)
        {
            _context = context;
            _smsService = smsService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Vendas>> ObterVendasAsync()
        {
            return await _context.Vendas.Include(c => c.Cliente)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Vendas> ObterVendasPorIdAsync(int id)
        {
            return await _context.Vendas.Include(v => v.Cliente)
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<object> RealizarVendaAsync(VendaDTO dto)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == dto.ClienteId);
            if (cliente == null) return "Cliente nao encontrado";


            var pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == dto.PizzaId);
            if (pizza == null) return "Sabor nao encontrado";

            decimal ValorFinal = pizza.ValorPizza * dto.Quantidade;

            var venda = _mapper.Map<Vendas>(dto);

            venda.ValorTotal = ValorFinal;
            venda.DataVenda = DateTime.Now;


            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            if (cliente != null)
            {
                string msg = $"Olá{cliente.Nome},Seu pedido foi criado com sucesso, e chegará em ate 60 minutos.Total:R${ValorFinal:F2},Endereço : {cliente.Endereço}";
                await _smsService.EnviasSMSAsync(cliente.Telefone, msg);
            }

            return new
            {
                mensagem = "Pedido criado com Sucesso!",
                clientes = cliente.Nome,
                pizza = pizza.Sabor,
                valorTotal = ValorFinal
            };

        }
    }
}