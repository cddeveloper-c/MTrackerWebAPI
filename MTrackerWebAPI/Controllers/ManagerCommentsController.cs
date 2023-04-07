using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerCommentsController : ControllerBase
    {
        public readonly MTrackerDbContext _context;
        public ManagerCommentsController(MTrackerDbContext Dbcontext)
        {
            _context = Dbcontext;
        }

        [HttpGet]
        [Route("GetManagerComments")]
        public async Task<ActionResult<IEnumerable<ManagerComments>>> GetManagerComments()
        {
            return await _context.ManagerComments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerComments>> GetManagerCommentsbyID(int id)
        {
            var managerComments = await _context.ManagerComments.FindAsync(id);

            if (managerComments == null)
            {
                return NotFound();
            }

            return managerComments;
        }

        [HttpPost]
        public async Task<ActionResult<ManagerComments>> PostManagerComments(ManagerComments managerComments)
        {
            _context.ManagerComments.Add(managerComments);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get ManagerComments", new { id = managerComments.ManagerCommentID }, managerComments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagerComments(int id)
        {
            var managerComments = await _context.ManagerComments.FindAsync(id);
            if (managerComments == null)
            {
                return NotFound();
            }
            _context.ManagerComments.Remove(managerComments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
