using System.ComponentModel.DataAnnotations;

namespace ASPMovieCurd.Models
{
    public class Movie
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]

        public DateTime ReleaseDate { get; set; }
        [Required]

        public string? Type { get; set; }
        [Required]

        public string? Stars { get; set; }




    }
}
