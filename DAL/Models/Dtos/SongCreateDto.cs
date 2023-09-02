using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Dtos
{
    public class SongCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Duration { get; set; } = string.Empty;
        [Required]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

    }
}
