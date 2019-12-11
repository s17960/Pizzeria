using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult GetPizzas(string order = "name")
        {
            if (order == "price"){
                return Ok(_context.Pizza.OrderByDescending(x => x.Price).ToList());
            }

            return Ok(_context.Pizza.OrderBy(x => x.Name).ToList());
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
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        // PUT: api/Pizza
        [HttpPut("{pizzaId:int}")]
        public IActionResult Update(int pizzaId, Pizza updatedPizza)
        {
            if (_context.Pizza.Count(x => x.PizzaId == pizzaId) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{pizzaId:int}")]
        public IActionResult Delete(int pizzaId)
        {
            var pizza = _context.Pizza.FirstOrDefault(x => x.PizzaId == pizzaId);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();
            return Ok(pizza);
        }
    }
}
