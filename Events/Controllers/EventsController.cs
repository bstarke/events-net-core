using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly eventsContext _context;
        public EventsController(eventsContext context)
        {
            _context = context;
        }
        // GET api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Event.ToListAsync();
        }

        // GET api/events/activeIsTrue
        [HttpGet("activeIsTrue")]
        public ActionResult<Event> GetActiveEvent()
        {
            return _context.Event.Single(a => a.Active == true);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(long id)
        {
            var returnedEvent = await _context.Event.FindAsync(id);
            if (returnedEvent == null)
            {
                return NotFound();
            }
            return returnedEvent;
        }

        // POST api/events
        [HttpPost]
        public async Task<ActionResult<Event>> Post([FromBody] Event item)
        {
            _context.Event.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent), new { id = item.Id }, item);
        }

        // PUT api/events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Event item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.Event.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Event.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
