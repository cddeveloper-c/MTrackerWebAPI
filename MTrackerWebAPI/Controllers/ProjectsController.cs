using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public readonly MTrackerDbContext _context;

        public ProjectsController(MTrackerDbContext Dbcontext)
        {
            _context = Dbcontext;
        }
        [HttpGet]
        [Route("GetProjects")]
        public async Task<ActionResult<IEnumerable<Projects>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetProjectsbyID(int id)
        {
            var projects = await _context.Projects.FindAsync(id);

            if (projects == null)
            {
                return NotFound();
            }

            return projects;
        }
        [HttpPost]
        public async Task<ActionResult<Projects>> PostProjects(Projects projects)
        {
            _context.Projects.Add(projects);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get Projects", new { id = projects.ProjectID }, projects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            if(projects == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
