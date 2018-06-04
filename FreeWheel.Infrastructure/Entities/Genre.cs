using System.ComponentModel.DataAnnotations.Schema;

namespace FreeWheel.Infrastructure.Entities
{
    [Table("Genres")]
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
