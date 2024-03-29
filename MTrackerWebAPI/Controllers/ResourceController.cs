﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTrackerWebAPI.Model;

namespace MTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
   // Authorize
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
    }
}
