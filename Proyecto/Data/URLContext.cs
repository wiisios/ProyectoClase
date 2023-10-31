using Microsoft.EntityFrameworkCore;
using Proyecto.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Proyecto.Data
{
    public class URLContext : DbContext
    {
        public DbSet<URL> Urls { get; set; }

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
            


            modelBuilder.Entity<URL>().HasData(
                google);

        



            base.OnModelCreating(modelBuilder);
        }

    }
}
