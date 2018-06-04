using AutoMapper;
using FreeWheel.Domain.DTOs;
using FreeWheel.Infrastructure.Entities;

namespace FreeWheel.Domain.MappingProfiles.Movies
{
    public class UserMovieRatingProfile : Profile
    {
        public UserMovieRatingProfile()
        {
            CreateMap<UserMovieRating, UserMovieRatingDto>()
                .ReverseMap();
        }
    }
}
