using FreeWheel.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeWheel.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserMovieRating> UserMovieRatings { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }
    }
}
