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
            if (!eventContext.EventCategories.Any())
            {
                eventContext.EventCategories.AddRange(GetEventCategories());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventTypes.Any())
            {
                eventContext.EventTypes.AddRange(GetEventTypes());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventItems.Any())
            {
                eventContext.EventItems.AddRange(GetEventItems());
                eventContext.SaveChanges();
            }
        }
        private static IEnumerable<EventCategory> GetEventCategories()
        {
            return new List<EventCategory>
            {
                new EventCategory
                {
                    Category = "Family & Education"
                },
                new EventCategory
                {
                    Category = "Science & Technology"
                },
                new EventCategory
                {
                    Category= "Sports & Fitness"
                }
            };
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
        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            {
                new EventItem { EventTypeId = 1, EventCategoryId = 1, Name = "BE About IT", Description = "Be About It: Unpacking White Privilege, Bias, and Anti-Racist Instruction", Location = "Redmond Convention Center", Price = 60, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem { EventTypeId = 1, EventCategoryId = 2, Name= "Webinar Statistika", Description = "Webinar Statistika #3 | Statistical Methods (ANOVA and MANOVA)", Location = "Online", Price = 55, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem { EventTypeId = 3, EventCategoryId = 2, Name= "ProductCon Online", Description = "ProductCon Online: The Product Management Conference", Location = "Online Event", Price = 150, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventItem { EventTypeId = 2, EventCategoryId = 3, Name = "2020 NJCAAE", Description = "2020 NJCAAE Convention Day 1", Location = "Online Event",  Price = 0, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/4"  },
                new EventItem { EventTypeId = 1, EventCategoryId = 2, Name = "Biomarkers", Description = "Use of Biomarkers to Establish the Presence and Severity of Impairment", Location = "Online Event", Price = 30, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5"},
                new EventItem { EventTypeId = 2, EventCategoryId = 1, Name = "PSCC 2020", Description = "XXI Power Systems Computation Conference", Location = "Online Event", Price = 100, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/6"},
                new EventItem { EventTypeId = 3, EventCategoryId = 1, Name = "RELIT!", Description = "RELIT! 2020: Bring. Your. Brave.", Location = "Online Event", Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"},
                new EventItem { EventTypeId = 1, EventCategoryId = 3, Name = "The Coronavirus Advice", Description = "Webinar: The Coronavirus Advice Your Fitness Business Needs to Hear", Location = "Online Event",  Price = 60, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8"},
                new EventItem { EventTypeId = 3, EventCategoryId = 3, Name = "SportBite", Description = "Introduction to Elite Performance Conference - SportBite", Location = "Online Event", Price = 10, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9"},
                new EventItem { EventTypeId = 2, EventCategoryId = 2, Name = "Miami 2020", Description = "Mining Disrupt Conference LIVE | Bitcoin Blockchain Cryptocurrency Mining", Location = "Online Event",  Price = 100, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new EventItem { EventTypeId = 1, EventCategoryId = 1, Name = "NABME", Description = "A Conversation to Foster Anti-Racist Practices in Schools", Location = "Online Event",  Price = 5, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventItem { EventTypeId = 3, EventCategoryId = 1, Name = "The 2020 9th Annual", Description = "2020 9th Annual Liberated Minds Black Homeschool", Location = "Online Event",  Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12"},
                new EventItem { EventTypeId = 2, EventCategoryId = 2, Name = "HHL Expert Talk", Description = "HHL Expert Talk - How to become a great negotiator? Research and practice", Location = "Online Event",  Price = 30, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventItem { EventTypeId = 1, EventCategoryId = 1, Name = "Back to School", Description = "Webinar: Business and Engineering in the USA", Location = "Online Event", Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new EventItem { EventTypeId = 3, EventCategoryId = 2, Name = "New Era", Description = "A New Era for Food and Climate", Location = "Online Event",  Price = 45, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }

            };
        }
    }
}
