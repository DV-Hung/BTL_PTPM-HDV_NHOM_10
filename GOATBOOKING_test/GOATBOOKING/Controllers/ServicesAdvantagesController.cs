using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GOATBOOKING.Models;

namespace GOATBOOKING.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesAdvantagesController : ControllerBase
    {
        private readonly MasterContext _context;

        public ServicesAdvantagesController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/ServicesAdvantages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesAdvantage>>> GetServicesAdvantages()
        {
            return await _context.ServicesAdvantages.ToListAsync();
        }

        // GET: api/ServicesAdvantages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesAdvantage>> GetServicesAdvantage(long id)
        {
            var servicesAdvantage = await _context.ServicesAdvantages.FindAsync(id);

            if (servicesAdvantage == null)
            {
                return NotFound();
            }

            return servicesAdvantage;
        }

        // PUT: api/ServicesAdvantages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicesAdvantage(long id, ServicesAdvantage servicesAdvantage)
        {
            if (id != servicesAdvantage.HomestayId)
            {
                return BadRequest();
            }

            _context.Entry(servicesAdvantage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesAdvantageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServicesAdvantages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicesAdvantage>> PostServicesAdvantage(ServicesAdvantage servicesAdvantage)
        {
            _context.ServicesAdvantages.Add(servicesAdvantage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicesAdvantageExists(servicesAdvantage.HomestayId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServicesAdvantage", new { id = servicesAdvantage.HomestayId }, servicesAdvantage);
        }

        // DELETE: api/ServicesAdvantages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicesAdvantage(long id)
        {
            var servicesAdvantage = await _context.ServicesAdvantages.FindAsync(id);
            if (servicesAdvantage == null)
            {
                return NotFound();
            }

            _context.ServicesAdvantages.Remove(servicesAdvantage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicesAdvantageExists(long id)
        {
            return _context.ServicesAdvantages.Any(e => e.HomestayId == id);
        }
    }
}
