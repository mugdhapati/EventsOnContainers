using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext              //purpose of creating this class is to define my store
    {
        public DbSet<EventType> EventTypes { get; set; }           //DbSet is a DB table
        public DbSet<EventLocation> EventLocations { get; set; }   //Classes Eventtype,iten, location are changed into Tables
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}   
