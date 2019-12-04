using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {

        private s17960Context _context;

        public PizzaController(s17960Context context)
        {
            _context = context;
        }

        // GET: api/Pizza
        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        // GET: api/Pizza/5
        [HttpGet("{id}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        // POST: api/Pizza
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pizza/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
