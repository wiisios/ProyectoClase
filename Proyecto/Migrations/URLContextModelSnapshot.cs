﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto.Data;

#nullable disable

namespace Proyecto.Migrations
{
    [DbContext(typeof(URLContext))]
    partial class URLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Proyecto.Entities.URL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Catergory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VisitCounter")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Urls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Catergory = "busqueda",
                            ShortUrl = "AbC012",
                            Url = "google.com",
                            VisitCounter = 1
                        });
                });

            modelBuilder.Entity("Proyecto.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "wiisios99@gmail.com",
                            Password = "asd123",
                            Username = "Wiisios"
                        });
                });

            modelBuilder.Entity("URLUser", b =>
                {
                    b.Property<int>("UrlsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UrlsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("URLUser");
                });

            modelBuilder.Entity("URLUser", b =>
                {
                    b.HasOne("Proyecto.Entities.URL", null)
                        .WithMany()
                        .HasForeignKey("UrlsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
