using AutoMapper;
using AutoMapper.QueryableExtensions;
using FreeWheel.Domain.Commands.Movies;
using FreeWheel.Domain.Configuration;
using FreeWheel.Domain.DTOs;
using FreeWheel.Domain.MappingProfiles.Movies;
using FreeWheel.Domain.Queries.Movies;
using FreeWheel.Infrastructure.Context;
using FreeWheel.Infrastructure.Entities;
using System.Linq;

namespace FreeWheel.Domain.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly MapperConfiguration _mapperConfig;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public MovieService()
        {
            _dbContext = ContextLocator.GetContext();
            _mapperConfig = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new MovieProfile());
                cfg.AddProfile(new UserMovieRatingProfile());
            });
            _mapper = _mapperConfig.CreateMapper();
        }

        public UserMovieRatingDto AddOrUpdateRating(UserMovieRatingDto dto)
        {
            // Can be replaced with better validation
            // Currently just return null if not valid
            if (dto.Rating < 1 || dto.Rating > 5)
            {
                return null;
            }

            var entity = _mapper.Map<UserMovieRating>(dto);
            var command = new AddRatingCommand(_dbContext, entity);
            var result = command.Execute();
            return _mapper.Map<UserMovieRatingDto>(result);
        }

        public IQueryable<MovieDto> GetTop5MoviesByAllUsersRating()
        {
            var query = new GetTop5MoviesByAllUsersRating(_dbContext);
            var movies = query.Execute();
            return movies.ProjectTo<MovieDto>(_mapperConfig);
        }

        public IQueryable<MovieDto> GetTop5MoviesByCertainUserRating(int UserID)
        {
            var query = new GetTop5MoviesByCertainUserRating(_dbContext, UserID);
            var movies = query.Execute();
            return movies.ProjectTo<MovieDto>(_mapperConfig);
        }

        public IQueryable<MovieDto> GetMoviesFiltered(string title, int? yearOfRelease, string[] genres)
        {
            var query = new GetMoviesFiltered(_dbContext, title, yearOfRelease, genres);
            var movies = query.Execute();
            return movies.ProjectTo<MovieDto>(_mapperConfig);
        }
    }
}
