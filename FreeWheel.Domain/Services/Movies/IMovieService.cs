using FreeWheel.Domain.DTOs;
using System.Linq;

namespace FreeWheel.Domain.Services
{
    public interface IMovieService
    {
        IQueryable<MovieDto> GetMoviesFiltered(string title, int? yearOfRelease, string[] genres);
        IQueryable<MovieDto> GetTop5MoviesByAllUsersRating();
        IQueryable<MovieDto> GetTop5MoviesByCertainUserRating(int UserID);
        UserMovieRatingDto AddOrUpdateRating(UserMovieRatingDto dto);
    }
}
