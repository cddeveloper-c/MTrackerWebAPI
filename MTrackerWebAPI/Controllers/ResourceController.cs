using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

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

        // GET: api/ResourcesTest
        [HttpGet]
        [Route("api/Resource/GetResource")]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResource()
        {
            return await _context.Resource.ToListAsync();
        }
    }
}
