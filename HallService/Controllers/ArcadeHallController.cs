using HallService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HallService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArcadeHallController : ControllerBase
    {
        private readonly HallManagementDbContext _context;

        public ArcadeHallController(HallManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetHalls()
        {
            var halls = await _context.Halls.ToListAsync();
            if (halls == null)
            {
                return NotFound();
            }
            return Ok(await _context.Halls.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetArcadeHall(int id)
        {

            var arcadeHall = await _context.Halls.FindAsync(id);
            if (arcadeHall == null)
            {
                return NotFound();
            }

            return Ok(arcadeHall);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArcadeHall(int id, ArcadeHall arcadeHall)
        {
            if (id != arcadeHall.Id)
            {
                return BadRequest();
            }

            _context.Entry(arcadeHall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Halls.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArcadeHall(int id)
        {
            var arcadeHall = await _context.Halls.FindAsync(id);
            if (arcadeHall == null)
            {
                return NotFound();
            }

            _context.Halls.Remove(arcadeHall);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}

