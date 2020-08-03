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
                    new { Id = 1, Datum = DateTime.Parse("2020-03-09 16:50:09"), Url = "https://dl.dropboxusercontent.com/apitl/1/AVtXUo4BaOzCv4RR8NM26MXdF9QrZJP92yCHSWElvqHtzZa9Ghyu6pKTgQ34Byy0Qd8n5eRXAiUBZygprox08tf3z89XA7EvdA_s0Ajx9BPtESM8aoVprPA8ZW7bpAvzS5Nj797ZJ1B3X_2y0jw2OlzHG-4h0TPrfdg7Z0l5Mqqp4GuWaZ8KVE75Zq2evbx66DAyZAxKKNiNhzCLRwaUUdM4KXp0LUzccOIpAnCaZnWepHMKvceQehTzzSl7rxS8oN3m1LgseYRMbfCqjumvJLaXIRJgvM028ZiuIqNBTwwVU2bcbfAnX5kSio7_NFTk6zqARvGL3ZPAgjeuv7QOoXf0qJJI9ZWnvig8sIuoxXw06S5gpX3E96OEHsq01iNXt4g", OmgevingId = 1 }
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
