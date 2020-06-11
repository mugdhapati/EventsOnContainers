using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int EventTypeId { get; set; }
        public int EventLocationId { get; set; }    

        public EventType EventType { get; set; }
        public EventLocation EventLocation { get; set; }
    }   
}
