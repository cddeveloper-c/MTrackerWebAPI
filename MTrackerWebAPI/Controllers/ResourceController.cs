using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Migrations;
using MTrackerWebAPI.Model;
using Resource = MTrackerWebAPI.Migrations.Resource;
//using Resource = MTrackerWebAPI.Migrations.Resource;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly MTrackerDbContext _context;
        public ResourceController(MTrackerDbContext Dbcontext)
        {
            _context = Dbcontext;
        }
        //[HttpGet]
        //[Route("api/Resource/GetResource")]
        //public async Task<ActionResult<IEnumerable<Resource>>> GetResource()
        //{
        //    return await _context.Resource.ToListAsync();
        //}

        // GET: api/Employees
        [HttpGet]
        [Route("api/Employee/GetEmployee")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

    }
}
