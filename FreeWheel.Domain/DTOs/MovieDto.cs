namespace FreeWheel.Domain.DTOs
{
    public class MovieDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public float RunningTime { get; set; }
        public float AverageRating { get; set; }
    }
}
