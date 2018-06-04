﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreeWheel.Infrastructure.Entities
{
    [Table("MovieGenres")]
    public class MovieGenre
    {
        public int ID { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
    }
}
