using FreeWheel.Infrastructure.Context;
using System.Linq;

namespace FreeWheel.Domain.Queries.Movies
{
    public class GetTop5MoviesByAllUsersRating : IQuery<IQueryable<Infrastructure.Entities.Movie>>
    {
        private readonly ApplicationDbContext context;

        public GetTop5MoviesByAllUsersRating(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Infrastructure.Entities.Movie> Execute()
        {
            // details of the top 5 movies based on total user average ratings
            // In case of a rating draw return them by ascending
            // title alphabetical order

            var query = (from movie in context.Movies
                         let totalRaiting = context.UserMovieRatings.Where(w => w.MovieID == movie.ID).Sum(s => s.Rating)
                         orderby totalRaiting descending, movie.Title
                         select movie);

            return query.Take(5);
        }
    }
}
