using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        public EventController(EventContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult>Items(
            [FromQuery]int pageIndex = 0,
            [FromQuery] int pagesize = 6)
        {
            var items = await _context.EventItems
                    .OrderBy(e => e.Name)
                    .Skip(pageIndex * pagesize)
                    .Take(pagesize)
                    .ToListAsync();

            return Ok(items);
        }
    }
}
