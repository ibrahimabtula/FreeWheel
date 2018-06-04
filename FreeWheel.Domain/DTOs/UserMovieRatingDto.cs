namespace FreeWheel.Domain.DTOs
{
    public class UserMovieRatingDto
    {
        public int ID { get; set; }

        public float Rating { get; set; }

        public int UserID { get; set; }

        public int MovieID { get; set; }
    }
}
