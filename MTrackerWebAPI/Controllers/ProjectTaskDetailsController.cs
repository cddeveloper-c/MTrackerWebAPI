using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;
using MTrackerWebAPI.Model.ViewModel;
using System.Linq;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskDetailsController : ControllerBase
    {
        public readonly MTrackerDbContext _context;

        public ProjectTaskDetailsController(MTrackerDbContext Dbcontext)
        {
            _context = Dbcontext;
        }
        [HttpGet]
        public async Task<ActionResult<ProjectTaskDetailsViewModel>> GetProjectTaskDetails(int id)
        {
            //var projecttask = await _context.ProjectTasks.FindAsync(id);
            var projecttask = await (from p in _context.ProjectTasks
                               join r in _context.Resource on p.AssignedTo equals r.ResourceID
                               join u in _context.UserStories on p.UserStoryID equals u.UserStoryID
                               join pr in _context.Projects on u.ProjectID equals pr.ProjectID
                               select new ProjectTaskDetailsViewModel
                               {
                                   ProjectTaskID = p.ProjectTaskID,
                                   ResourceName = r.ResourceName,
                                   ProjectName = pr.ProjectName,
                                   Story = u.Story,
                               }).ToListAsync();

            return Ok(projecttask);
        }
    }
}
