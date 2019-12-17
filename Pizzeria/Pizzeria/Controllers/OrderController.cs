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
    public class OrderController : ControllerBase
    {

        private readonly s17960Context _context;

        public OrderController(s17960Context context)
        {
            _context = context;
        }
        // GET: api/Order
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_context.Order.ToList());
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Order.FirstOrDefault(e => e.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Create(Order newOrder)
        {
            _context.Order.Add(newOrder);
            _context.SaveChanges();

            return StatusCode(201, newOrder);
        }

        // PUT: api/Order/5
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
