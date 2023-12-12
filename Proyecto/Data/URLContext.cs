using Microsoft.EntityFrameworkCore;
using Proyecto.Entities;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Proyecto.Data
{
    public class URLContext : DbContext
    {
        public DbSet<URL> Urls { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public URLContext(DbContextOptions<URLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            User victor = new User()
            {
                Id = 1,
                Username = "Wiisios",
                Email = "wiisios99@gmail.com",
                Password = "asd123",
            };
            

            modelBuilder.Entity<User>().HasData(
                 victor
                 );

            modelBuilder.Entity<User>()
            .HasMany<URL>(e => e.Urls)
            .WithOne(e => e.User);


            modelBuilder.Entity<Category>()
            .HasMany<URL>(e => e.Urls)
            .WithOne(e => e.Category);


            base.OnModelCreating(modelBuilder);
        }

    }
}
