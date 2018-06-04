using FreeWheel.Infrastructure.Context;
using System.Linq;

namespace FreeWheel.Domain.Queries.Movies
{
    public class GetMoviesFiltered : IQuery<IQueryable<Infrastructure.Entities.Movie>>
    {
        private readonly ApplicationDbContext context;
        private readonly string _title;
        private readonly int? _yearOfRelease;
        private readonly string[] _genres;

        public GetMoviesFiltered(ApplicationDbContext context, string title, int? yearOfRelease, string[] genres)
        {
            this.context = context;
            _title = title;
            _yearOfRelease = yearOfRelease;
            _genres = genres.Select(g => g.Trim().ToLower()).ToArray();
        }

        public IQueryable<Infrastructure.Entities.Movie> Execute()
        {
            var query = context.Movies.AsQueryable();

            if (_title != null)
                query = query.Where(movie => movie.Title.Contains(_title));

            if(_yearOfRelease != null)
                query = query.Where(movie => movie.YearOfRelease ==  _yearOfRelease);

            if (_genres.Length > 0)
                query = query.Where(movie => movie.Genres.Any(movieGenre => _genres.ToList().Contains(movieGenre.Genre.Name.ToLower())));

            return query;
        }
    }
}
