﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_migration
{
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        public int MaxPassanger { get; set; }

        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }

    //Entities
    [Table("Passangers")]
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("FirstName")]
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
    public class Flight
    {

        [Key]//Primary key
        public int Number { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [MaxLength(100)]


        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }


        //Navigation properties
        public ICollection<Client> Clients { get; set; }

    }
    internal class AirplaneDB : DbContext
    {
        public AirplaneDB()
        {

            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;
                                        initial catalog=Airplane;
                                        integrated security=True;
                                        Connect Timeout = 2;
                                        Encrypt = False;
                                        Trust Server Certificate = False;
                                        Application Intent = ReadWrite;
                                        Multi Subnet Failover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            //Initializator - Seeder
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
        new Airplane()
        {
            Id = 1,
            Model = "Boing747",
            MaxPassanger = 300
        },
        new Airplane()
        {
            Id = 2,
            Model = "AN914",
            MaxPassanger = 200
        },
        new Airplane()
        {
            Id = 3,
            Model = "Mria",
            MaxPassanger = 150
        }
            });
            modelBuilder.Entity<Flight>().HasData(new Flight[] {
        new Flight()
        {
             Number = 1,
             DepartureCity = "Kyiv",
             ArrivalCity = "Lviv",
             DepartureTime = new DateTime(2024,2,17),
             ArrivalTime = new DateTime(2024,2,17),
             AirplaneId = 1
        },
        new Flight()
        {
             Number = 2,
             DepartureCity = "Varshava",
             ArrivalCity = "Lviv",
             DepartureTime = new DateTime(2024,2,18),
             ArrivalTime = new DateTime(2024,2,18),
             AirplaneId = 2
        },
        new Flight()
        {
             Number = 3,
             DepartureCity = "Kyiv",
             ArrivalCity = "Lviv",
             DepartureTime = new DateTime(2024,2,22),
             ArrivalTime = new DateTime(2024,2,22),
             AirplaneId = 3
        }
    });
        }
    }
    
}
