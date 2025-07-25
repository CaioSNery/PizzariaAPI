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
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDb;
        public PizzaController(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        [HttpPost]
        public async Task<ActionResult<Pizza>> AddPizza(Pizza pizza)
        {
            _appDb.Pizza.Add(pizza);
            await _appDb.SaveChangesAsync();

            return Ok(pizza);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> BuscarPizzas()
        {
            var pizza = await _appDb.Pizza.ToListAsync();
            return Ok(pizza);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> BuscarPizzaId(int id)
        {
            var pizza = await _appDb.Pizza.FindAsync(id);
            if (pizza == null) return NotFound();
            return Ok(pizza);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pizza>> AtualizarPizza(int id, [FromBody] Pizza pizzaup)
        {
            if (id != pizzaup.Id) return BadRequest();

            _appDb.Pizza.Update(pizzaup);
            await _appDb.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pizza>> DeletePizza(int id)
        {
            var pizza = _appDb.Pizza.Find(id);
            if (pizza == null) return NotFound();

            _appDb.Pizza.Remove(pizza);
            await _appDb.SaveChangesAsync();

            return NoContent();
        }

    }
}