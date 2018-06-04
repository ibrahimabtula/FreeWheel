using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreeWheel.Infrastructure.Entities
{
    [Table("UserMovieRatings")]
    public class UserMovieRating
    {
        public int ID { get; set; }

        public float Rating { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public int MovieID { get; set; }

        public Movie Movie { get; set; }
    }
}
