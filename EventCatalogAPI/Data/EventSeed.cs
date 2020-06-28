using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext eventContext)
        {
            eventContext.Database.Migrate();
            if (!eventContext.EventTypes.Any())
            {
                eventContext.EventTypes.AddRange(GetEventTypes());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventLocations.Any())
            {
                eventContext.EventLocations.AddRange(GetEventLocations());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventItems.Any())
            {
                eventContext.EventItems.AddRange(GetEventItems());
                eventContext.SaveChanges();
            }
            
        }
        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                new EventType
                {
                    Type = "Webinars"
                },
                new EventType
                {
                    Type = "Conventions"
                },
                new EventType
                {
                    Type = "Conferences"
                }
            };
        }
        private static IEnumerable<EventLocation> GetEventLocations()
        {
            return new List<EventLocation>
            {
                new EventLocation
                {
                    Location = "Redmond"
                },
                new EventLocation
                {
                    Location = "Bothell"
                },
                new EventLocation
                {
                    Location= "Renton"
                }
            };
        }
        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            {
                new EventItem { EventTypeId = 1, EventLocationId = 3,Name = "BE About IT", Description = "Be About It: Unpacking White Privilege, Bias, and Anti-Racist Instruction", Date = "July 9, 5PM", Location = "Redmond Convention Center", Price = 60, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem { EventTypeId = 1, EventLocationId = 1,Name= "Webinar Statistika", Description = "Webinar Statistika #3 | Statistical Methods (ANOVA and MANOVA)", Date = "August 20 3PM", Location = "12025 Lake City Way NE, STE B,Seattle, WA 98125", Price = 55, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem { EventTypeId = 3, EventLocationId = 2,Name= "ProductCon Online", Description = "ProductCon Online: The Product Management Conference", Date = "Aug 1 10AM",Location = "Online Event", Price = 150, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventItem { EventTypeId = 2, EventLocationId = 2,Name = "2020 NJCAAE", Description = "2020 NJCAAE Convention Day 1", Date = "July 23 1PM", Location = "High Dive Renton, Renton, WA",  Price = 30, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/4"  },
                new EventItem { EventTypeId = 1, EventLocationId = 3,Name = "Biomarkers", Description = "Use of Biomarkers to Establish the Presence and Severity of Impairment", Date = "Sep 10 4pm, ", Location = "Bellevue College", Price = 30, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5"},
                new EventItem { EventTypeId = 2, EventLocationId = 1,Name = "PSCC 2020", Description = "XXI Power Systems Computation Conference", Date= "Sep 2 3PM", Location = "Hyatt Regency Seattle ", Price = 100, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/6"},
                new EventItem { EventTypeId = 3, EventLocationId = 3,Name = "RELIT!", Description = "RELIT! 2020: Bring. Your. Brave.", Date= "October 19 5PM", Location = "801 228th Ave SE, Sammamish", Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"},
                new EventItem { EventTypeId = 1, EventLocationId = 3,Name = "The Coronavirus Advice", Description = "Webinar: The Coronavirus Advice Your Fitness Business Needs to Hear", Date = "August 27 2PM", Location = "Online Event",  Price = 60, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8"},
                new EventItem { EventTypeId = 3, EventLocationId = 2,Name = "SportBite", Description = "Introduction to Elite Performance Conference - SportBite", Date = "November 5 9AM", Location = "Verlocal,Redmond, WA", Price = 10, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9"},
                new EventItem { EventTypeId = 2, EventLocationId = 1,Name = "Miami 2020", Description = "Mining Disrupt Conference LIVE | Bitcoin Blockchain Cryptocurrency Mining", Date = "December 13 11AM", Location = "Redmond Town Center",  Price = 100, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new EventItem { EventTypeId = 1, EventLocationId = 3,Name = "NABME", Description = "A Conversation to Foster Anti-Racist Practices in Schools", Date = "July 19 5PM", Location = "Hilton, Seattle",  Price = 55, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventItem { EventTypeId = 3, EventLocationId = 1,Name = "The 2020 9th Annual", Description = "2020 9th Annual Liberated Minds Black Homeschool", Date = "Nov 1 4PM", Location = "High Dive Renton, Renton, WA",  Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12"},
                new EventItem { EventTypeId = 2, EventLocationId = 1,Name = "HHL Expert Talk", Description = "HHL Expert Talk - How to become a great negotiator? Research and practice", Date = "June 30 8AM", Location = "Temple Rd, Bothell",  Price = 30, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventItem { EventTypeId = 1, EventLocationId = 3,Name = "Back to School", Description = "Webinar: Business and Engineering in the USA", Location = "Online Event", Date = "October 7 2PM", Price = 105, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new EventItem { EventTypeId = 3, EventLocationId = 2,Name = "New Era", Description = "A New Era for Food and Climate", Date = "May 30 3PM", Location = "Online Event",  Price = 45, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }

            };
        }
    }
}
