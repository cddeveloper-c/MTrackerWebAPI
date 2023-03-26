using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTrackerWebAPI.Model;
using MTrackerWebAPI.Model.ViewModel;

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
        //[HttpGet]
        //public async Task<ActionResult<ProjectTaskDetailsViewModel>> GetProjectTaskDetails(int id)
        //{
        //    var projecttask = await _context.ProjectTasks.FindAsync(id);

        //}
    }
}
