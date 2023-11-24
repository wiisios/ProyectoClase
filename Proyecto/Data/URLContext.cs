using Microsoft.EntityFrameworkCore;
using Proyecto.Entities;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Reflection.Emit;

namespace Proyecto.Data
{
    public class URLContext : DbContext
    {
        public DbSet<URL> Urls { get; set; }
        public DbSet<User> Users { get; set; }

        public URLContext(DbContextOptions<URLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            URL google = new URL()
            {
                Id = 1,
                Url = "google.com",
                ShortUrl = "AbC012",
                VisitCounter = 1,
                Catergory = "busqueda",

            };

            User victor = new User()
            {
                Id = 1,
                Username = "Wiisios",
                Email = "wiisios99@gmail.com",
                Password = "asd123",
            };
            


            modelBuilder.Entity<URL>().HasData(
                google);

            modelBuilder.Entity<User>().HasData(
                 victor
                 );

            modelBuilder.Entity<User>()
              .HasMany<URL>(e => e.Urls)
              .WithMany(e => e.Users);






            base.OnModelCreating(modelBuilder);
        }

    }
}
