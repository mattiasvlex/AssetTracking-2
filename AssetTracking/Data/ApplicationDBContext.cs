using AssetTracking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Data
{
    internal class ApplicationDBContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AssetTracking;Integrated Security=True";

        public DbSet<Office> Offices { get; set; }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Office office1 = new Office { Location = "Sweden", Currency = "SEK", ToUSD = 10.68 };
            Office office2 = new Office { Location = "Denmark", Currency = "DKK", ToUSD = 6.88 };
            Office office3 = new Office { Location = "USA", Currency = "USD", ToUSD = 1.0 };

            modelBuilder.Entity<Office>().HasData(office1, office2, office3);

            modelBuilder.Entity<Asset>().HasData(new Asset { Id = 1, Type = "Computer", Brand = "ASUS ROG", Model = "B550-F", Date = new DateOnly(2020, 11, 24), Price = 950, OfficeLocation = office1.Location },
                                                 new Asset { Id = 2, Type = "Computer", Brand = "HP", Model = "14S-FQ1010NO", Date = new DateOnly(2023, 01, 30), Price = 679, OfficeLocation = office2.Location },
                                                 new Asset { Id = 3, Type = "Phone", Brand = "Samsung", Model = "S20 Plus", Date = new DateOnly(2022, 09, 12), Price = 700, OfficeLocation = office3.Location },
                                                 new Asset { Id = 4, Type = "Phone", Brand = "Sony Xperia", Model = "10 III", Date = new DateOnly(2021, 03, 06), Price = 800, OfficeLocation = office1.Location },
                                                 new Asset { Id = 5, Type = "Phone", Brand = "Iphone", Model = "10", Date = new DateOnly(2018, 11, 25), Price = 750, OfficeLocation = office2.Location },
                                                 new Asset { Id = 6, Type = "Computer", Brand = "HP", Model = "Elitebook", Date = new DateOnly(2023, 08, 30), Price = 1530, OfficeLocation = office3.Location },
                                                 new Asset { Id = 7, Type = "Computer", Brand = "HP", Model = "Elitebook", Date = new DateOnly(2021, 07, 06), Price = 1640, OfficeLocation = office1.Location });
        }
    }
}
