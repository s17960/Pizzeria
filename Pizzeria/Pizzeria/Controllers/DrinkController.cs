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
    public class DrinkController : ControllerBase
    {
        private readonly s17960Context _context;

        public DrinkController(s17960Context context)
        {
            _context = context;
        }

        // GET: api/Drink
        [HttpGet]
        public IActionResult GetDrinks()
        {
            return Ok(_context.Drink.ToList());
        }

        // GET: api/Drink/5
        [HttpGet("{id}")]
        public IActionResult GetDrink(int id)
        {
            var drink = _context.Drink.FirstOrDefault(e => e.DrinkId == id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        // POST: api/Drink
        [HttpPost]
        public IActionResult Create(Drink newDrink)
        {
            _context.Drink.Add(newDrink);
            _context.SaveChanges();

            return StatusCode(201, newDrink);
        }

        // PUT: api/Drink/5
        [HttpPut("{drinkId:int}")]
        public IActionResult Update(int drinkId, Drink updatedDrink)
        {
            if (_context.Drink.Count(e => e.DrinkId == drinkId) == 0)
            {
                return NotFound();
            }

            _context.Drink.Attach(updatedDrink);
            _context.Entry(updatedDrink).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedDrink);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{drinkId:int}")]
        public IActionResult Delete(int drinkId)
        {
            var drink = _context.Drink.FirstOrDefault(e => e.DrinkId == drinkId);
            if (drink == null)
            {
                return NotFound();
            }

            _context.Drink.Remove(drink);
            _context.SaveChanges();
            return Ok(drink);
        }
    }
}
