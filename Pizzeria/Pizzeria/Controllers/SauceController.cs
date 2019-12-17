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
    public class SauceController : ControllerBase
    {
        private readonly s17960Context _context;

        public SauceController(s17960Context context)
        {
            _context = context;
        }

        // GET: api/Sauce
        [HttpGet]
        public IActionResult GetSauces()
        {
            return Ok(_context.Sauce.ToList());
        }

        // GET: api/Sauce/5
        [HttpGet("{id}")]
        public IActionResult GetSauce(int id)
        {
            var sauce = _context.Sauce.FirstOrDefault(e => e.SauceId == id);
            if(sauce == null)
            {
                return NotFound();
            }
            return Ok(sauce);
        }

        // POST: api/Sauce
        [HttpPost]
        public IActionResult Create(Sauce newSauce)
        {
            _context.Sauce.Add(newSauce);
            _context.SaveChanges();

            return StatusCode(201, newSauce);
        }

        // PUT: api/Sauce/5
        [HttpPut("{sauceId:int}")]
        public IActionResult Update(int sauceId, Sauce updatedSauce)
        {
            if(_context.Sauce.Count(e => e.SauceId == sauceId) == 0)
            {
                return NotFound();
            }

            _context.Sauce.Attach(updatedSauce);
            _context.Entry(updatedSauce).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedSauce);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{sauceId:int}")]
        public IActionResult Delete(int sauceId)
        {
            var sauce = _context.Sauce.FirstOrDefault(e => e.SauceId == sauceId);
            if (sauce == null)
            {
                return NotFound();
            }

            _context.Sauce.Remove(sauce);
            _context.SaveChanges();
            return Ok(sauce);
        }
    }
}
