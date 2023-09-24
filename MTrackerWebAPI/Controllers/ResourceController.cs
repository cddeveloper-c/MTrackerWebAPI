using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using MTrackerWebAPI.Migrations;
using System.Data;
using Resource = MTrackerWebAPI.Model.Resource;
using Microsoft.AspNetCore.Connections;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // Authorize
    public class ResourceController : ControllerBase
    {
        private readonly MTrackerDbContext _context;
        public readonly IConfiguration _configuration;
        public ResourceController(MTrackerDbContext Dbcontext, IConfiguration configuration)
        {
            _context = Dbcontext;
            _configuration = configuration;
        }

        // GET: api/ResourcesTest
        [HttpGet]
        [Route("api/Resource/GetResource")]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResource()
        {
            return await _context.Resource.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResourcebyID(int id)
        {
            var resource = await _context.Resource.FindAsync(id);

            if (resource == null)
            {
                return NotFound();
            }

            return resource;
        }
        [HttpPost]
        public async Task<ActionResult<Resource>> PostResource(Resource resource)
        {
            _context.Resource.Add(resource);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get Resource", new { id=resource.ResourceID},resource);
        }

        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<output>>> Getoutput(Input input)
        //{
        //    string StoredProc = "exec CreateAppointment " +
        //            "@ClinicID = " + input.ClinicId + "," +
        //            "@AppointmentDate = '" + input.AppointmentDate + "'," +
        //            "@FirstName= '" + input.FirstName + "'," +
        //            "@LastName= '" + input.LastName + "'," +
        //            "@PatientID= " + input.PatientId + "," +
        //            "@AppointmentStartTime= '" + input.AppointmentStartTime + "'," +
        //            "@AppointmentEndTime= '" + input.AppointmentEndTime + "'";

        //    //return await _context.output.ToListAsync();
        //    return await _context.output.FromSqlRaw(StoredProc).ToListAsync();
        //}

        //[HttpPost]
        //public async Task<ActionResult<int>> Resource(Resource resource)
        //{
        //     using var connection = new SqlConnection("Persist Security Info=False;User ID=sa;Password=7101;Initial Catalog=MTrackerAPI;Data Source=LAPTOP-22L160U3\\SQLEXPRESS;TrustServerCertificate=True");
            
        //    var query = "AddResource";
        //    var p = new DynamicParameters();
        //    p.Add("ResourceName", resource.ResourceName);
        //    p.Add("Destination", resource.Destination);
        //    p.Add("ManagerID", resource.ManagerID);
        //    p.Add("ContactNo", resource.ContactNo);
        //    p.Add("EmailID", resource.EmailID);
        //    p.Add("SkillSets", resource.SkillSets);

        //    var rowsAffected = await connection.ExecuteAsync
        //        (query, p, commandType: CommandType.StoredProcedure);

        //    return rowsAffected;

        //}
    }
}
