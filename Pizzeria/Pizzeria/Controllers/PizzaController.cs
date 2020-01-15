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
    /// <summary>
    /// Kontroler pizzy
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {

        private readonly s17960Context _context;

        /// <summary>
        /// Konstruktor, pobiera context bazy danych
        /// </summary>
        /// <param name="context"></param>
        public PizzaController(s17960Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Metoda zwraca liste pizz
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Lista pizz</returns>
        // GET: api/Pizza
        [HttpGet]
        public IActionResult GetPizzas(string order = "name")
        {
            if (order == "price"){
                return Ok(_context.Pizza.OrderByDescending(x => x.Price).ToList());
            }

            return Ok(_context.Pizza.OrderBy(x => x.Name).ToList());
        }

        /// <summary>
        /// Metoda zwraca pizzę o podanym id
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <returns>Pizza o podanym id</returns>
        // GET: api/Pizza/5
        [HttpGet("{pizzaId:int}")]
        public IActionResult GetPizza(int pizzaId)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.PizzaId == pizzaId);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        /// <summary>
        /// Metoda dodaje do bazy pizzę podaną w parametrze
        /// </summary>
        /// <param name="newPizza"></param>
        /// <returns>Stworzona pizza</returns>
        // POST: api/Pizza
        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        /// <summary>
        /// Aktualizuje dane pizzy o podanym id
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <param name="updatedPizza"></param>
        /// <returns>Zaktualizowana pizza</returns>
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
        
        /// <summary>
        /// Usuwa pizzę o podanym id
        /// </summary>
        /// <param name="pizzaId"></param>
        /// <returns>Usunięta pizza</returns>
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
