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
                    new { Id = 1, Datum = DateTime.Parse("2020-03-09 16:50:09"), Url = "https://previews.dropbox.com/p/thumb/AA5hFiq-DXHGWzzPjj9G7YjidvrJDDQa-sAwfoiiFQFifqWk0QEgGs71I4fxy0pzJDDjya38inxVyEYEY6Gglbeawr6Ef7duvRljWwQLk-cCv7ry4J5cxWr9Mvs_830psSMAtYFFGQtOwC32RdKSjQp7bQt8_v9lURPXMBRQ8TiC5p83KVFk6AOfbALrGcJ-U4PGCBGsSsRYCBouwHikMqUOEMv0PTFj-ifFukbp--JrJbAH0IxWBx43ky8GwcatoozyVYEvAcbIfFZJJLotmeNHnj2IzVPX7UdsEqembK3G3ELIvXZEfnkJr77c6eCaOgdAPyBSC1BvovVHvDT3iuzvgmnptn4XuKkEewyuxIB81A/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 2, Datum = DateTime.Parse("2020-03-09 17:07:36"), Url = "https://previews.dropbox.com/p/thumb/AA79kZwCjDP-uF_kz7Igg7w7fq3tp514dWjGt9ZpIR7YjOxtRA1yuj0gGu8cpHf0A_OlfdYJnUyp9rpceWhpeWK12MHrc-GYjxEc-PMNf9OCVTG_y0uAyhS_HqrHHV64KtJuZaGLRvTNyTmBp5BzqyEFD1bqPBYfxj0PnZQ27ynYVuTTY7VENQCZjYwbePfd_8GGrY79nMmYTA6AU896EmpuXZ8-GG5ux2-HA8ZyYQsMayMSjGxKJQcbhZGrPHoVOM5qD23q5IT0qa07MTE44njJA7i8YZNoyNNc370BupnDoXd8fiLi-2M0IRUj8eOjqYICX9HKi0fMbUwBfR5-nhTCJz8ius17ZQsLw-P2pwus8g/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 3, Datum = DateTime.Parse("2020-03-09 17:46:18"), Url = "https://previews.dropbox.com/p/thumb/AA7WJDeScPls59gWbzx6AxoSiHrJq8t5StTzKpwSAwi9Uje7qxMQf9VmQjkMSJamZHb3RntXOJMNlQBbbCWvL-333AuMwCiQicHcZ3BGRMx9uH6MSmEWP4YS7mI546IExoMQ2lb8UxqqeJTKCE8VFXk2nPjEUR0CPY-5Y6oN8UI-5S4y4Xej44tJiWqlMa-6ASUwZtM569ANum2hd56B3HkrWGtms7BKIYN_2vxFpNIV2nec4vv4wUH_te8-2l754UkMHALo1b-UdEakA-xCGkLfK8jQnUp2SjmqMaKEtrKQGetR2RjzkVW9TqMNJpDKCrdPvAAHCOYW_9TwXp12KXGDYtwSGJ09jfw9QK3oPG2R7w/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 4, Datum = DateTime.Parse("2020-03-09 20:34:31"), Url = "https://previews.dropbox.com/p/thumb/AA7lKssbARgPnaKnEMXAFs6Be_WJWysemhyT9hajpfzpSoNIoQoA4SLCGFS4oU8QV4xesfhndCAaxFsc8K_dYWJMsI5KwT9g_o7p0Y14oVS8OPZJhQPeEKGzndPPOuiUVSjOkOfgcwSa66zsqdkjDAEVObAh-KnL2oEthsusjcxadDuUsjzy9i72r2msDMFNfNwvYxVYbTLlH5Jwysqo4UoHoAU3kFhOoxUMRQxTyLSdlxY1NWkztmn_FXa8O1TvuXkKjLkk3mI3x_ecee2aXmRlYbopFeOWMBLav01_Xa1hr-3oxaSV9a-pP-FY1m6o9kE2zeepWuXG4M5L14px4dLviJB6t27eChrA-hAObaBP0A/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 5, Datum = DateTime.Parse("2020-03-09 23:22:56"), Url = "https://previews.dropbox.com/p/thumb/AA5RimVND1m8ynxCOUkeKLcAZWfolORVapSpZjpKKK9cTohrhV27Q0DcQJYGFMWQIBw2UJbb0Z7_xoCG_wx1JNkhohpJA55WrBS4T8V_JRcoveqFsjGgCqoTB5iDtFgr_8TWc9KW07IgXJg3LKsE23eDKOtuN_9rLHr74SXtDBuB4-TZqee_bkzZtpQI2-uGltaJclEyGVAPKl-X6lKeEz7gV2VfJ8mNR11MwCsr7ZwW8YcE3jbGU0812DFdhmcL2PXTIWm-b3GADCMZfMVnLlHx0LwuxqH7R6T4VcxbLB7_BnLJ57SK3B__s3O7c8C5dLK18OnLRmWyPDXa0IFyCY85vz9J5sY9MtpjrzHWD5Tt6g/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 6, Datum = DateTime.Parse("2020-03-10 02:11:08"), Url = "https://previews.dropbox.com/p/thumb/AA7_Sfg7HZWkE72P2pSpQ6YK823kaRQBBLA8ArDirIG7iOkZEPv5A3gyGKkFduW8TXMTmonsWCRSARTiLOfEbE4e-ynp7BuX8EA7LTBWA9SaB1sSMyIJPZQrupzUGTLURc6HfguvEZXhkM-XKd9_DmAtduZs4PDcRMUPeThthpPdDjVgJKcJhH_GdIP224aXG__eqAt-p4dXfnxuDunGu9JUUhmgV1N8re84oG-tEm5yq36BqfDc3uyAaLRW0OR0YDnBdTusEoKNHqizxGjeRGocbk1LZKrdXk9BZQnaQMpQ6bBKSpKPXB6xHoMQLAKq3vGePXsvHMC3mblIH9M4wvHfMxRFwVLdfOTKtMNDmFgsOw/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 7, Datum = DateTime.Parse("2020-03-10 04:59:41"), Url = "https://previews.dropbox.com/p/thumb/AA6Q-KE4_2PR4_MCiqoFlEJezkb_0cb5KpEw2p1HRU14eWYpiN7DRul4KW537qSCdCwHC4VfkIIcBtSlcFCPUm5nBr5jHt1yIQPLvrPWqrKdgI0CKw0luHVWRd_IhoelntDEAU4ZwDS8cw0sXxFpAYRJZLxqSlNtI1LmoiphvC29gHH0dSJ1oC_vUcqkmggILues_1kaNpGBf9WRD5S3J8QPPjsVQaIID_rMTfy6XZvdEEurMmylM7Lbnbon5BzTZKNFte-J26mgDlzkzUFO45Vrm46qbBn9hHs3se2INCwtMG7bmxwu92ClIYCMU_O8APfZW_0nqYqPRjCQrSscfSouCbY-8GmCz3wuRO5qOiI8lg/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 8, Datum = DateTime.Parse("2020-03-10 07:48:06"), Url = "https://previews.dropbox.com/p/thumb/AA6uul9WPk59lrd7a84FCim4ygRCiJxxo0P4HaQNwe8y371Y0X02wcr6f6M2fqX1s28hu5J25shJcBbJbYOPLq8Vf8eyCmAuBDT0ut5aVenYSve-sLO7crUjkjczzmD3Oav2xttmnDl5VbtE11z_S69iXmnu8NuOzexNNybW4avwAbMDjGIo2H1Qvjku99FS_207DL29g1cYWzJ-zRU1-CzATuqfc1Tq9knrBc4dQHyIXIvVWUrYwyHR5zloQDpd5qx3YLhOtWzrKbsymoBYFA7lQnkFu6iOv44jpoHXmEz_DyMA9R2GL97k8m3Dp9bNyTrrgpto3swMXnJ5Imbt3qKL4hjKTh_E6x9Wpy8xkHrjbw/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 },
                    new { Id = 9, Datum = DateTime.Parse("2020-03-10 10:34:52"), Url = "https://previews.dropbox.com/p/thumb/AA6oyBKm1zns4uzJSYNVcbbxdWbYTeIO_VMvcJGM8_incEq7xGffjJ2eTlhWjC39bioZyTnRGFVDld5fC7nDbxfgAqbszYS5V1LSwv9bSMEoL2dXZ47dJiwtZk7cG5eofquj_bxoqAr1vCnsLm6aWFC1SYypvvLElkgfb56UKIJCNogE-cLi5R7mkl76aPiQmVyhqv1DOULGi9H3OzA_HkF9W-X_1MfZo2HX64Tal8uYBL3zK3L6XptNJdvqjpXQrjt6ZxUwZB380igJw685M2ce2CgwGhDChq-_o-rldxjLHsPaBEa2Z4-ZOTGEabFPbSSs1YEvQWlYtxrq8epPH7hZXCRgsBtJ5ZVdffMtDNn4JA/p.jpeg?fv_content=true&size_mode=5", OmgevingId = 1 });

            //seeden van de Temperaturen
            builder.Entity<Temperatuur>().HasData(
                    new { Id = 1, Datum = DateTime.Parse("2020-03-09 16:50:09"), Waarde = 20.812F, OmgevingId = 1 },
                    new { Id = 2, Datum = DateTime.Parse("2020-03-09 17:07:36"), Waarde = 20F, OmgevingId = 1 },
                    new { Id = 3, Datum = DateTime.Parse("2020-03-09 17:46:18"), Waarde = 18.75F, OmgevingId = 1 },
                    new { Id = 4, Datum = DateTime.Parse("2020-03-09 20:34:31"), Waarde = 19.375F, OmgevingId = 1 },
                    new { Id = 5, Datum = DateTime.Parse("2020-03-09 23:22:56"), Waarde = 16.875F, OmgevingId = 1 },
                    new { Id = 6, Datum = DateTime.Parse("2020-03-10 02:11:08"), Waarde = 16.375F, OmgevingId = 1 },
                    new { Id = 7, Datum = DateTime.Parse("2020-03-10 04:59:41"), Waarde = 16.1875F, OmgevingId = 1 },
                    new { Id = 8, Datum = DateTime.Parse("2020-03-10 07:48:06"), Waarde = 16.375F, OmgevingId = 1 },
                    new { Id = 9, Datum = DateTime.Parse("2020-03-10 10:34:52"), Waarde = 17.4375F, OmgevingId = 1 }
                );

            //seeden van de luchtdrukken
            builder.Entity<Luchtdruk>().HasData(
                    new { Id = 1, Datum = DateTime.Parse("2020-03-09 16:50:09"), Waarde = 1005.49F, OmgevingId = 1 },
                    new { Id = 2, Datum = DateTime.Parse("2020-03-09 17:07:36"), Waarde = 1005.49F, OmgevingId = 1 },
                    new { Id = 3, Datum = DateTime.Parse("2020-03-09 17:46:18"), Waarde = 1005.49F, OmgevingId = 1 },
                    new { Id = 4, Datum = DateTime.Parse("2020-03-09 20:34:31"), Waarde = 1005.49F, OmgevingId = 1 },
                    new { Id = 5, Datum = DateTime.Parse("2020-03-09 23:22:56"), Waarde = 1005.49F, OmgevingId = 1 },
                    new { Id = 6, Datum = DateTime.Parse("2020-03-10 02:11:08"), Waarde = 1005.49F, OmgevingId = 1 },
                    new { Id = 7, Datum = DateTime.Parse("2020-03-10 04:59:41"), Waarde = 1005.495F, OmgevingId = 1 },
                    new { Id = 8, Datum = DateTime.Parse("2020-03-10 07:48:06"), Waarde = 1005.49F, OmgevingId = 1 },
                    new { Id = 9, Datum = DateTime.Parse("2020-03-10 10:34:52"), Waarde = 1005.49F, OmgevingId = 1 });
        }
    }
}
