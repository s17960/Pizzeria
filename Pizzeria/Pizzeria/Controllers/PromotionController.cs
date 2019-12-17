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
    public class PromotionController : ControllerBase
    {

        private readonly s17960Context _context;

        public PromotionController(s17960Context context)
        {
            _context = context;
        }

        // GET: api/Promotion
        [HttpGet]
        public IActionResult GetPromotions()
        {
            return Ok(_context.Promotion.ToList());
        }

        // GET: api/Promotion/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetPromotion(int id)
        {
            var promotion = _context.Promotion.FirstOrDefault(e => e.PromotionId == id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        // POST: api/Promotion
        [HttpPost]
        public IActionResult Create(Promotion newPromotion)
        {
            _context.Promotion.Add(newPromotion);
            _context.SaveChanges();

            return StatusCode(201, newPromotion);
        }

        // PUT: api/Promotion/5
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
