using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TripsLogApp.Models
{
    public class TripDetailContext : DbContext
    {
        public TripDetailContext(DbContextOptions<TripDetailContext> options)
            : base(options)
        { }

        public DbSet<TripDetail> TripDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TripDetail>().HasData(
                new TripDetail
                {
                    TripDetailID = 1,
                    Destination = "Louisville",
                    Accomodations = "the Galt House",
                    StartDate = new DateTime(2008, 3, 1),
                    EndDate = new DateTime(2009, 3, 1),
                    PhoneNumber = "502-555-9999",
                    Email = "Trip1@gmail.com",
                    FirstThingToDo = "Go to the Derby",
                    SecondThingToDo = "Go drink bourbon",
                    ThirdThingToDo = "Go eat Pizza"


                },
                new TripDetail
                {
                    TripDetailID = 2,
                    Destination = "Gatlinburg",
                    Accomodations = "An AirBnB",
                    StartDate = new DateTime(2022, 3, 1),
                    EndDate = new DateTime(2022, 3, 2),
                    PhoneNumber = "502-555-9999",
                    Email = "Trip2@gmail.com",
                    FirstThingToDo = "Go to Cade's Cove",
                    SecondThingToDo = "Go drink moonshine",
                    ThirdThingToDo = "Go eat pancakes"
                });
        }
    }
}

