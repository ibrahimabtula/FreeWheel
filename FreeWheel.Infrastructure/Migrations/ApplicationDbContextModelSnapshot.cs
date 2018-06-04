﻿// <auto-generated />
using FreeWheel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FreeWheel.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FreeWheel.Infrastructure.Entities.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("FreeWheel.Infrastructure.Entities.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AverageRating");

                    b.Property<float>("RunningTime");

                    b.Property<string>("Title");

                    b.Property<int>("YearOfRelease");

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("FreeWheel.Infrastructure.Entities.MovieGenre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GenreID");

                    b.Property<int>("MovieID");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("FreeWheel.Infrastructure.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FreeWheel.Infrastructure.Entities.UserMovieRating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MovieID");

                    b.Property<float>("Rating");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.HasIndex("UserID");

                    b.ToTable("UserMovieRatings");
                });

            modelBuilder.Entity("FreeWheel.Infrastructure.Entities.MovieGenre", b =>
                {
                    b.HasOne("FreeWheel.Infrastructure.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FreeWheel.Infrastructure.Entities.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FreeWheel.Infrastructure.Entities.UserMovieRating", b =>
                {
                    b.HasOne("FreeWheel.Infrastructure.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FreeWheel.Infrastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
