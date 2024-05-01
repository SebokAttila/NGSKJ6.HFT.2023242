using Microsoft.EntityFrameworkCore;
using NGSKJ6.HFT._2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NGSKJ6.HFT._2023242.Repository
{
    public class WineryDbContext : DbContext
    {
        public virtual DbSet<Wine> Wines { get; set; }
        public virtual DbSet<Winery> Wineries { get; set; }
        public virtual DbSet<Barrell> Barrels { get; set; }

        public WineryDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase("Wineries");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>(wine => wine
            .HasOne(w => w.Winery)
            .WithMany(winery => winery.Wines)
            .HasForeignKey(w => w.WineryId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Barrell>(barrel => barrel
            .HasOne(b => b.Wine)
            .WithMany(w => w.Barells)
            .HasForeignKey(b => b.WineId)
            .OnDelete(DeleteBehavior.Cascade));

            List<Winery> wineries = new List<Winery>
            {
                new Winery(){WineryId = 1, Location="Villány", Name= "Gere"},
                new Winery(){WineryId = 2, Location="Eger", Name= "Juhász"},
            };
            List<Wine> wines = new List<Wine>
            {
                new Wine(){WineId = 1, Name ="villányi1", Amount = 150, Type ="vörös", Vintage = 1996, WineryId = 1},
                new Wine(){WineId = 2, Name ="villányi2", Amount = 250, Type ="fehér", Vintage = 2018, WineryId = 1},
                new Wine(){WineId = 3, Name ="villányi3", Amount = 350, Type ="rozé", Vintage = 2022, WineryId = 1},
                new Wine(){WineId = 4, Name ="egri1", Amount = 150, Type ="vörös", Vintage = 2002, WineryId = 2},
                new Wine(){WineId = 5, Name ="egri2", Amount = 250, Type ="fehér", Vintage = 2019, WineryId = 2},
                new Wine(){WineId = 6, Name ="egri", Amount = 350, Type ="rozé", Vintage = 2021, WineryId = 2},
            };
            List<Barrell> barrells = new List<Barrell>
            {
                new Barrell(){BarrelId = 1, Type = Types.Barrique, Capacity = 200, Material = "Oak", NumberOfUses = 4, WineId = 1},
                new Barrell(){BarrelId = 2, Type = Types.Barrique, Capacity = 250, Material = "Oak", NumberOfUses = 2, WineId = 2},
                new Barrell(){BarrelId = 3, Type = Types.Lager, Capacity = 600, Material = "Oak", NumberOfUses = 1, WineId = 3},
                new Barrell(){BarrelId = 4, Type = Types.Barrique, Capacity = 200, Material = "Oak", NumberOfUses = 3, WineId = 4},
                new Barrell(){BarrelId = 5, Type = Types.Barrique, Capacity = 230, Material = "Oak", NumberOfUses = 6, WineId = 5},
                new Barrell(){BarrelId = 6, Type = Types.Lager, Capacity = 500, Material = "Oak", NumberOfUses = 0, WineId = 6},
            };

            modelBuilder.Entity<Winery>().HasData(wineries);
            modelBuilder.Entity<Wine>().HasData(wines);
            modelBuilder.Entity<Barrell>().HasData(barrells);


            base.OnModelCreating(modelBuilder);
        }
    }
}
