using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.Migrations;
using EventCatalogAPI.ViewModels;
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
            var itemsCount =  _context.EventItems.LongCountAsync();

            var items = await _context.EventItems
                    .OrderBy(i => i.Name)
                    .Skip(pageIndex * pagesize)
                    .Take(pagesize)
                    .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item =>
                 item.PictureUrl = item.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalEventBaseUrl"]));

            return items;
        }

        [HttpGet("[action]")]
        public async Task <IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.EventLocations.ToListAsync();
            return Ok(locations);
        }

        [HttpGet("[action]/type/{eventTypeId}/location/{eventLocationId}")]
        public async Task <IActionResult> Items(
            int? eventTypeId,
            int? eventLocationId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pagesize = 6) 
        {
            var query = (IQueryable<EventItem>)_context.EventItems;

            if (eventTypeId.HasValue)
            {
                query = query.Where(i => i.EventTypeId == eventTypeId);
            }
            if (eventLocationId.HasValue)
            {
                query = query.Where(i => i.EventLocationId == eventLocationId);
            }
            var itemsCount = query.LongCountAsync();

            var items = await query
                    .OrderBy(i => i.Name)
                    .Skip(pageIndex * pagesize)
                    .Take(pagesize)
                    .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
        }
    }
}
