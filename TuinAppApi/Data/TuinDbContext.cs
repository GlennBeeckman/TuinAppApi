using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data
{
    public class TuinDbContext: IdentityDbContext
    {

        public DbSet<Tuin> Tuinen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }

        public TuinDbContext(DbContextOptions<TuinDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // entity tuin
            builder.Entity<Tuin>()
                .HasMany(p => p.Planten)
                .WithOne()
                .IsRequired()
                .HasForeignKey("TuinId"); //shadow property

            builder.Entity<Tuin>().Property(t => t.Naam)
                .IsRequired();

            builder.Entity<Tuin>().Property(t => t.dateAdded)
                .IsRequired();

            //entity gebruiker
            builder.Entity<Gebruiker>().Property(g => g.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<Gebruiker>().Property(g => g.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<Gebruiker>().Property(g => g.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Gebruiker>().Ignore(g => g.FavoriteTuinen);

            //entity gebruikerfavorite
            builder.Entity<GebruikerFavorite>()
                .HasKey(gf => new { gf.GebruikerId, gf.TuinId });

            builder.Entity<GebruikerFavorite>()
                .HasOne(gf => gf.Gebruiker)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.GebruikerId);

            builder.Entity<GebruikerFavorite>()
                .HasOne(gf => gf.Tuin)
                .WithMany()
                .HasForeignKey(f => f.TuinId);



            //seeden van tuinen
            Console.WriteLine("Looking for best spot for the gardens");
            builder.Entity<Tuin>().HasData(
                    new Tuin { Id = 1, Naam = "Vierkante Meter Tuin", dateAdded = DateTime.Now },
                    new Tuin { Id = 2, Naam = "Rode Bloempot", dateAdded = DateTime.Now }
                );

            Console.WriteLine("Seeding some plants");
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
