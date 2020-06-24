using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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

            items = ChangePictureUrl(items);

            return Ok(items);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item =>
                 item.PictureUrl = item.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalEventBaseUrl"]));

            return items;
        }
    }
}
