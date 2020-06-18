using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext              //purpose of creating this class is to define my store
    {
        public EventContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EventType> EventTypes { get; set; }           //DbSet is a DB table
        public DbSet<EventCategory> EventCategories { get; set; }   //Classes Eventtype,item, location are changed into Tables
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(e =>
            {
                e.ToTable("EventCategories");
                e.Property(l => l.Id).IsRequired()
                                     .UseHiLo("event_category_hilo");
                e.Property(l => l.Category).IsRequired()
                                           .HasMaxLength(100);
                
            });
            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventTypes");
                e.Property(t => t.Id).IsRequired()
                                     .UseHiLo("event_type_hilo");
                e.Property(t => t.Type).IsRequired()
                                        .HasMaxLength(100);
                
            });
            modelBuilder.Entity<EventItem>(e =>
            {
                e.ToTable("EventItems");

                e.Property(i => i.Id).IsRequired()
                                        .UseHiLo("event_item_hilo");
                e.Property(i => i.Name).IsRequired()
                                           .HasMaxLength(200);
                e.Property(i => i.Location).IsRequired()
                                            .HasMaxLength(200);
                e.Property(i => i.DateTime).IsRequired()
                                            .HasMaxLength(50);
                e.Property(i => i.Price).IsRequired();

                e.HasOne(i => i.EventType)
                    .WithMany()
                    .HasForeignKey(i => i.EventTypeId);

                e.HasOne(i => i.EventCategory)
                    .WithMany()
                        .HasForeignKey(i => i.EventCategoryId);
                                        
            });
        }
    }
}   
