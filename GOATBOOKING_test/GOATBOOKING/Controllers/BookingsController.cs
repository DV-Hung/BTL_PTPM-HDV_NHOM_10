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
    public class BookingsController : ControllerBase
    {
        private readonly MasterContext _context;  // biến _context đại diện cho cơ sở dữ liệu

        public BookingsController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings() 
            // trả về danh sách bookings dưới dang json
        {
            
            return await _context.Bookings.ToListAsync();
            /*var Booking = await _context.Bookings.Where(b => b.BookingId == 1).ToListAsync();
            if(Booking == null || Booking.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(Booking);
            }*/
            //truy vấn đến cơ sở sở dữ liệu tất cả bookings -> danh sách dữ liệu json
        }

        // tìm kiếm theo bất kì kí tự nào truyền vào
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings([FromQuery] string search)
        {
            var query = _context.Bookings.AsQueryable(); 

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b => b.BookingId.ToString().Contains(search) ||
                                         b.TotalPrice.ToString().Contains(search)
                                         || b.CheckInDate.ToString().Contains(search)
                                         || b.CheckOutDate.ToString().Contains(search));
            }
            var bookings = await query.ToListAsync();

            if(bookings == null || bookings.Count == 0)
            {
                return NotFound();
            }
            return Ok(bookings);
        }
        // GET: api/Bookings/5
        [HttpGet("{id}")] // lấy ra thoogn tin booking theo id
        public async Task<ActionResult<Booking>> GetBooking(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound(); // trả về lỗi HTTP 404
            }

            return booking; // trả về dạng json
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")] // cập nhật booking theo id
        public async Task<IActionResult> PutBooking(long id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest(); // trả về lỗi http 404
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingExists(booking.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(long id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
