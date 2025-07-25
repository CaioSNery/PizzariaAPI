using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Models;

namespace Pizzaria.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ClienteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Clientes>> AddCliente(Clientes cliente)
        {
            _appDbContext.Clientes.Add(cliente);
            await _appDbContext.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> BuscarClientes()
        {
            var clientes = await _appDbContext.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> ObterClienteId(int id)
        {
            var cliente = await _appDbContext.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Clientes>> UpdateCliente(int id, [FromBody] Clientes clienteup)
        {
            if (id != clienteup.Id) return BadRequest();

            _appDbContext.Clientes.Update(clienteup);
            await _appDbContext.SaveChangesAsync();

            return Ok(clienteup);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Clientes>> DeleteCliente(int id)
        {
            var cliente = _appDbContext.Clientes.Find(id);
            if (cliente == null) return NotFound();

            _appDbContext.Clientes.Remove(cliente);

            await _appDbContext.SaveChangesAsync();

            return NoContent();


        }
        
    }
}