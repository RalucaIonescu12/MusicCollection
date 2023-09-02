using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Dtos
{
    public class ArtistCreateDto
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
