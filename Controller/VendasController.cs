using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizzaria.Interface;
using Pizzaria.Models;

namespace Pizzaria.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _service;
        public VendasController(IVendaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarVenda([FromBody] VendaDTO dto)
        {
            var venda = await _service.RealizarVendaAsync(dto);
            if (venda is string erro)
            {
                if (erro.Contains("Não Encontrado")) return NotFound(erro);
                return BadRequest(erro);
            }
            return Ok(venda);
        }

        [HttpGet]
        public async Task<IActionResult> GetVendas()
        {
            var venda = await _service.ObterVendasAsync();
            if (!venda.Any()) return NotFound();
            return Ok(venda);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdVendas(int id)
        {
            var venda = await _service.ObterVendasPorIdAsync(id);
            if (venda == null) return NotFound("Venda nao encontrada");
            return Ok(venda);
        }
    }
}