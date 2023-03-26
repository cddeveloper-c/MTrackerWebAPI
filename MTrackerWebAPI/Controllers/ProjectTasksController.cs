using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        public readonly MTrackerDbContext _context;

        public ProjectTasksController(MTrackerDbContext Dbcontext)
        {
            _context = Dbcontext;
        }

        [HttpGet]
        [Route("GetProjectTasks")]
        public async Task<ActionResult<IEnumerable<ProjectTasks>>> GetProjectTasks()
        {
            return await _context.ProjectTasks.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTasks>> GetProjectTasksbyID(int id)
        {
            var projecttask = await _context.ProjectTasks.FindAsync(id);

            if (projecttask == null)
            {
                return NotFound();
            }

            return projecttask;
        }
        [HttpPost]
        public async Task<ActionResult<ProjectTasks>> PostProjectTasks(ProjectTasks projecttask)
        {
            _context.ProjectTasks.Add(projecttask);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get Projects", new { id = projecttask.ProjectTaskID }, projecttask);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectTasks(int id)
        {
            var projecttask = await _context.ProjectTasks.FindAsync(id);
            if (projecttask == null)
            {
                return NotFound();
            }
            _context.ProjectTasks.Remove(projecttask);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
