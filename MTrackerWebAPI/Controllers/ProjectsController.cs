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


    }
}
