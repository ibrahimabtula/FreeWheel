using FreeWheel.Configuration;
using FreeWheel.Domain.DTOs;
using FreeWheel.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FreeWheel.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _menuService;

        public MoviesController()
        {
            _menuService = ApplicationServiceLocator.GetService<IMovieService>();
        }

        // GET api/movies
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string title, [FromQuery]int? yearOfRelease, [FromQuery]string genres)
        {
            string[] genresArray = new string[0];
            if (genres != null)
            {
                genresArray = genres.Split(",");
            }

            if (title == null 
                && yearOfRelease == null 
                && (genresArray == null || (genresArray != null && genresArray.Length == 0)))
            {
                return BadRequest("Provide at least one filter criteria!");
            }

            var result = await Task.Run(() => _menuService.GetMoviesFiltered(title, yearOfRelease, genresArray));

            if (result.Count() == 0)
            {
                return NotFound("No movies found!");
            }

            return Json(result);
        }

        // GET api/movies/getTop5MoviesByAllUsersRating
        [HttpGet("getTop5MoviesByAllUsersRating")]
        public async Task<IActionResult> GetTop5MoviesByAllUsersRating()
        {
            var result = await Task.Run(() => _menuService.GetTop5MoviesByAllUsersRating());

            if(result.Count() == 0)
            {
                return NotFound("No movies found!");
            }

            return Json(result);
        }

        // GET api/movies/getTop5MoviesByAllUsersRating
        [HttpGet("getTop5MoviesByCertainUserRating/{id}")]
        public async Task<IActionResult> GetTop5MoviesByCertainUserRating(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("id can't bu NULL!");
            }

            var result = await Task.Run(() => _menuService.GetTop5MoviesByCertainUserRating(id.Value));

            if (result.Count() == 0)
            {
                return NotFound("No movies found!");
            }

            return Json(result);
        }

        // POST api/movies
        [HttpPost("addRating")]
        public async Task<IActionResult> Post([FromBody]UserMovieRatingDto dto)
        {

            if (dto == null)
            {
                return BadRequest();
            }

            if (dto.MovieID == 0 || dto.UserID == 0)
            {
                return BadRequest();
            }

            var result = await Task.Run(() => _menuService.AddOrUpdateRating(dto));

            if (result != null && result.ID > 0)
            {
                return Json(result);
            }

            return BadRequest();

        }
    }
}
