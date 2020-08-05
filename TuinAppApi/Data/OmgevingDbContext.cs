using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using TuinAppApi.Models;

namespace TuinAppApi.Data
{
    public class OmgevingDbContext: DbContext
    {
        public DbSet<Omgeving> Omgevingen { get; set; }

        public OmgevingDbContext(DbContextOptions<OmgevingDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Omgeving>()
                .HasMany(o => o.Fotos)
                .WithOne()
                .HasForeignKey("OmgevingId");

            builder.Entity<Omgeving>()
                .HasMany(o => o.Temperaturen)
                .WithOne()
                .HasForeignKey("OmgevingId");

            builder.Entity<Omgeving>()
                .HasMany(o => o.Luchtdrukken)
                .WithOne()
                .HasForeignKey("OmgevingId");

            //seeden van de omgeving
            builder.Entity<Omgeving>().HasData(
                    new Omgeving { Id = 1 }
                );

            //seeden van de fotos
            builder.Entity<Foto>().HasData(
                    new { Id = 1, Datum = DateTime.Parse("2020-03-09 16:50:09"), Url = "https://previews.dropbox.com/p/thumb/AA5hFiq-DXHGWzzPjj9G7YjidvrJDDQa-sAwfoiiFQFifqWk0QEgGs71I4fxy0pzJDDjya38inxVyEYEY6Gglbeawr6Ef7duvRljWwQLk-cCv7ry4J5cxWr9Mvs_830psSMAtYFFGQtOwC32RdKSjQp7bQt8_v9lURPXMBRQ8TiC5p83KVFk6AOfbALrGcJ-U4PGCBGsSsRYCBouwHikMqUOEMv0PTFj-ifFukbp--JrJbAH0IxWBx43ky8GwcatoozyVYEvAcbIfFZJJLotmeNHnj2IzVPX7UdsEqembK3G3ELIvXZEfnkJr77c6eCaOgdAPyBSC1BvovVHvDT3iuzvgmnptn4XuKkEewyuxIB81A/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 }
                );

            //seeden van de Temperaturen
            builder.Entity<Temperatuur>().HasData(
                    new { Id = 1, Datum = DateTime.Parse("2020-03-09 16:50:09"), Waarde = 20.812F, OmgevingId = 1 }
                );

            //seeden van de luchtdrukken
            builder.Entity<Luchtdruk>().HasData(
                    new { Id = 1, Datum = DateTime.Parse("2020-03-09 16:50:09"), Waarde = 1005.49F, OmgevingId = 1 }
                );
        }
    }
}
