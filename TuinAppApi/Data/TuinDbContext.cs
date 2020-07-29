using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data
{
    public class TuinDbContext: DbContext
    {

        public DbSet<Tuin> Tuinen { get; set; }

        public TuinDbContext(DbContextOptions<TuinDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tuin>()
                .HasMany(p => p.Planten)
                .WithOne()
                .IsRequired()
                .HasForeignKey("TuinId"); //shadow property

            builder.Entity<Tuin>().Property(t => t.Naam)
                .IsRequired();

            builder.Entity<Tuin>().Property(t => t.dateAdded)
                .IsRequired();

            //seeden van tuinen
            builder.Entity<Tuin>().HasData(
                    new Tuin { Id = 1, Naam = "Vierkante Meter Tuin", dateAdded = DateTime.Now },
                    new Tuin { Id = 2, Naam = "Rode Bloempot", dateAdded = DateTime.Now }
                );

            //seeden van planten
            builder.Entity<Plant>().HasData(
                    new { Id = 1, Naam = "Sla", DagenTotOogst = 50, DatumGeplant = DateTime.Now, TuinId = 1},
                    new { Id = 2, Naam = "Wortel", DagenTotOogst = 70, DatumGeplant = DateTime.Now, TuinId = 1},
                    new { Id = 3, Naam = "Radijs", DagenTotOogst = 30, DatumGeplant = DateTime.Now, TuinId = 1},
                    new { Id = 4, Naam = "Pepermunt", DagenTotOogst = 90, DatumGeplant = DateTime.Now, TuinId = 2},
                    new { Id = 5, Naam = "Lavendel", DagenTotOogst = 150, DatumGeplant = DateTime.Now, TuinId = 2},
                    new { Id = 6, Naam = "Salie", DagenTotOogst = 80, DatumGeplant = DateTime.Now, TuinId = 2}
                );
        }
    }
}
