using FreeWheel.Infrastructure.Context;
using FreeWheel.Infrastructure.Entities;
using System.Linq;

namespace FreeWheel.Domain.Queries.Movies
{
    public class GetTop5MoviesByCertainUserRating : IQuery<IQueryable<Movie>>
    {
        private readonly ApplicationDbContext context;
        private readonly int _userID;

        public GetTop5MoviesByCertainUserRating(ApplicationDbContext context, int UserID)
        {
            this.context = context;
            _userID = UserID;
        }

        public IQueryable<Movie> Execute()
        {
            // details of the top 5 movies based on highest ratings given by a specific user
            // In case of a rating draw return them by ascending
            // title alphabetical order

            var query = (from movie in context.Movies
                         join movieRating in context.UserMovieRatings on movie.ID equals movieRating.MovieID
                         where movieRating.UserID == _userID
                         orderby movieRating.Rating descending, movie.Title
                         select movie);

            return query.Take(5);
        }
    }
}
