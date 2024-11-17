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
    public class ReviewsController : ControllerBase
    {
        private readonly MasterContext _context;

        public ReviewsController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(long id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        [HttpGet("search")]

        public async Task<ActionResult<IEnumerable<Review>>> GetReviews([FromQuery] string search)
        {                                                                   // FromQuery được lấy từ Urk 
            var query = _context.Reviews.AsQueryable();
            // lấy cơ sở dữ liệu ra

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(h => h.ReviewId.ToString().Contains(search) ||
                                         h.Rate.ToString().Contains(search) ||
                                         h.Comment.ToString().Contains(search) ||
                                        h.HomestayId.ToString().Contains(search) ||
                                        h.UserId.ToString().Contains(search)||
                                         h.CreatedAt.ToString().Contains(search) ||
                                         h.UpdatedAt.ToString().Contains(search));
            }
            var Reviews = await query.ToListAsync();

            if (Reviews == null || Reviews.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(Reviews);
            }
        }
        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(long id, Review review)
        {
            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Reviews.Add(review);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReviewExists(review.ReviewId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReview", new { id = review.ReviewId }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(long id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(long id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
