using FreeWheel.Infrastructure.Context;
using FreeWheel.Infrastructure.Entities;
using System;
using System.Linq;

namespace FreeWheel.Domain.Commands.Movies
{
    public class AddRatingCommand : ICommand<UserMovieRating>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserMovieRating _userMovieRating;

        public AddRatingCommand(ApplicationDbContext context, UserMovieRating userMovieRating )
        {
            _context = context;
            _userMovieRating = userMovieRating;
        }

        public UserMovieRating Execute()
        {
            try
            {
                UserMovieRating result = null;
                var existingRating = _context.UserMovieRatings
                    .Where(w => w.MovieID == _userMovieRating.MovieID && w.UserID == _userMovieRating.UserID)
                    .FirstOrDefault();

                if (existingRating != null)
                {
                    existingRating.Rating = _userMovieRating.Rating;
                    _context.Update(existingRating);
                    _context.SaveChanges();
                    result = existingRating;
                }
                else
                {
                    _context.UserMovieRatings.Add(_userMovieRating);
                    _context.SaveChanges();
                    result = _userMovieRating;
                }

                // Update the average rating for the movie
                var movieRatings = _context.UserMovieRatings.Where(w => w.MovieID == _userMovieRating.MovieID);
                var movie = _context.Movies.Find(_userMovieRating.MovieID);

                float trueAverageRating = movieRatings.Sum(s => s.Rating) / movieRatings.Count();
                movie.AverageRating = (float)Math.Round(trueAverageRating * 2, MidpointRounding.AwayFromZero) / 2;
                _context.Update(movie);
                _context.SaveChanges();

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
