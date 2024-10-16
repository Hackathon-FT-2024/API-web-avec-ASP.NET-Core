using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPIWeb.Data;
using TestAPIWeb.Models;

namespace TestAPIWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AssociationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssociationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/associations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Association>>> GetAssociations()
        {
            return await _context.Associations.ToListAsync();
        }

        // GET: api/associations/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Association>> GetAssociation(int id)
        {
            var association = await _context.Associations.FindAsync(id);

            if (association == null)
            {
                return NotFound();
            }

            return association;
        }

        // POST: api/associations
        [HttpPost]
        public async Task<ActionResult<Association>> PostUser(Association association)
        {
            _context.Associations.Add(association);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssociation), new { id = association.Id }, association);
        }

        // PUT: api/associations/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Association association)
        {
            if (id != association.Id)
            {
                return BadRequest();
            }

            _context.Entry(association).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/associations/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var association = await _context.Associations.FindAsync(id);
            if (association == null)
            {
                return NotFound();
            }

            _context.Associations.Remove(association);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
