using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPIWeb.Data;
using TestAPIWeb.Models;

namespace TestAPIWeb.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ObjetSocialController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ObjetSocialController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/objetsocials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjetSocial>>> GetObjetSocials()
        {
            return await _context.ObjetSocials.ToListAsync();
        }

        // GET: api/objetsocials/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjetSocial>> GetObjetSocial(int id)
        {
            var association = await _context.ObjetSocials.FindAsync(id);

            if (association == null)
            {
                return NotFound();
            }

            return association;
        }
    }
}
