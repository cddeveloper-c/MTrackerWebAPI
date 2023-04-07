using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoriesController : ControllerBase
    {
        public readonly MTrackerDbContext _context;
        public UserStoriesController(MTrackerDbContext Dbcontext)
        {
            _context = Dbcontext;
        }

        [HttpGet]
        [Route("GetUserStories")]
        public async Task<ActionResult<IEnumerable<UserStories>>> GetUserStories()
        {
            return await _context.UserStories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserStories>> GetUserStoriesbyID(int id)
        {
            var userStories = await _context.UserStories.FindAsync(id);

            if (userStories == null)
            {
                return NotFound();
            }

            return userStories;
        }
        [HttpPost]
        public async Task<ActionResult<UserStories>> PostUserStories(UserStories userStories)
        {
            _context.UserStories.Add(userStories);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get UserStories", new { id = userStories.UserStoryID }, userStories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStories(int id)
        {
            var userStories = await _context.UserStories.FindAsync(id);
            if (userStories == null)
            {
                return NotFound();
            }
            _context.UserStories.Remove(userStories);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
