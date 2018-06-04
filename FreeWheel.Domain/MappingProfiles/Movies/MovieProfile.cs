using AutoMapper;
using FreeWheel.Domain.DTOs;
using FreeWheel.Infrastructure.Entities;

namespace FreeWheel.Domain.MappingProfiles.Movies
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ReverseMap();
        }
    }
}
