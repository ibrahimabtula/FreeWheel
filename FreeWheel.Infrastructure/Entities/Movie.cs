using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeWheel.Infrastructure.Entities
{
    [Table("Movies")]
    public class Movie
    {
        public Movie()
        {
            Genres = new HashSet<MovieGenre>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public float RunningTime { get; set; }
        public float AverageRating { get; set; }
        public IEnumerable<MovieGenre> Genres{ get; set; }
    }
}
