using FreeWheel.Infrastructure.Context;
using FreeWheel.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeWheel.Infrastructure.Extrentions
{
    public static class ContextExtensions
    {
        public static void EnsureSeedData(this ApplicationDbContext dbContext)
        {

            using (var tr = dbContext.Database.BeginTransaction())
            {
                SeedUsers(dbContext);// Users
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Users ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Users OFF");

                SeedGenres(dbContext);// Genres
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Genres ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Genres OFF");

                SeedMovies(dbContext);// Movies
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Movies ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Movies OFF");

                SeedMovieGenres(dbContext);// MovieGenres
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.MovieGenres ON");
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.MovieGenres OFF");

                tr.Commit();
            }
        }

        #region Users
        private static void SeedUsers(ApplicationDbContext context)
        {
            CreateUserIfNotExists(context, 1, "Ivan", "Ivanov");
            CreateUserIfNotExists(context, 2, "John", "Smith");
            CreateUserIfNotExists(context, 3, "Ibrahim", "Abtula");
        }

        private static void CreateUserIfNotExists(ApplicationDbContext context, int ID, string FirstName, string LastName)
        {
            var user = context.Users.Find(ID);

            if (user != null) return;

            var newUser = new User()
            {
                ID = ID,
                FirstName = FirstName,
                LastName = LastName,
            };

            context.Users.Add(newUser);
        }
        #endregion

        #region Genres
        private static void SeedGenres(ApplicationDbContext context)
        {
            CreateGenreIfNotExists(context, 1, "Action");
            CreateGenreIfNotExists(context, 2, "Western");
            CreateGenreIfNotExists(context, 3, "Comedy");
            CreateGenreIfNotExists(context, 4, "Drama");
            CreateGenreIfNotExists(context, 5, "Romance");
            CreateGenreIfNotExists(context, 6, "Fantasy");
        }

        private static void CreateGenreIfNotExists(ApplicationDbContext context, int ID, string Name)
        {
            var existing = context.Genres.Find(ID);

            if (existing != null) return;

            var newEntity = new Genre()
            {
                ID = ID,
                Name = Name,
            };

            context.Genres.Add(newEntity);
        }
        #endregion

        #region Movies
        private static void SeedMovies(ApplicationDbContext context)
        {
            CreateMovieIfNotExists(context, 1, "Solo: A Star Wars Story", 2018, 2.15f, 1f);
            CreateMovieIfNotExists(context, 2, "12 Angry Men", 1957, 1.36f, 1f);
            CreateMovieIfNotExists(context, 3, "The Good, the Bad and the Ugly", 1966, 2.58f, 1f);
            CreateMovieIfNotExists(context, 4, "The Matrix", 1999, 2.16f, 1f);
            CreateMovieIfNotExists(context, 5, "Fight Club", 1999, 2.19f, 1f);
            CreateMovieIfNotExists(context, 6, "Forrest Gump", 1994, 2.22f, 1f);
            CreateMovieIfNotExists(context, 7, "Star Wars: Episode V - The Empire Strikes Back", 1980, 2.04f, 1f);
        }

        private static void CreateMovieIfNotExists(ApplicationDbContext context, int ID, string Title, int YearOfRelease, float RunningTime, float AverageRating)
        {
            var existing = context.Movies.Find(ID);

            if (existing != null) return;

            var newEntity = new Movie()
            {
                ID = ID,
                Title = Title,
                AverageRating = AverageRating,
                YearOfRelease = YearOfRelease,
                RunningTime = RunningTime,
            };

            context.Movies.Add(newEntity);
        }
        #endregion

        #region MovieGenres
        private static void SeedMovieGenres(ApplicationDbContext context)
        {
            // Movie 1 Action, Wester, Comedy
            CreateMovieGenreIfNotExists(context, 1, 1, 1);
            CreateMovieGenreIfNotExists(context, 2, 1, 2);
            CreateMovieGenreIfNotExists(context, 3, 1, 3);
            // Movie 2 Drama
            CreateMovieGenreIfNotExists(context, 4, 2, 4);
            // Movie 3 Wester
            CreateMovieGenreIfNotExists(context, 5, 3, 2);
            //Movie 4 Action
            CreateMovieGenreIfNotExists(context, 6, 4, 1);
            //Movie 5 Drama, Romance
            CreateMovieGenreIfNotExists(context, 7, 5, 4);
            CreateMovieGenreIfNotExists(context, 8, 5, 5);
            //Movie 6 Action, Fantasy
            CreateMovieGenreIfNotExists(context, 9, 6, 1);
            CreateMovieGenreIfNotExists(context, 10, 6, 6);

        }

        private static void CreateMovieGenreIfNotExists(ApplicationDbContext context, int ID, int MovieID, int GenreID)
        {
            var existing = context.MovieGenres.Find(ID);

            if (existing != null) return;

            var newEntity = new MovieGenre()
            {
                ID = ID,
                MovieID = MovieID,
                GenreID = GenreID,
            };

            context.MovieGenres.Add(newEntity);
        }
        #endregion
    }
}
