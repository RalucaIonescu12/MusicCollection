using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models.Dtos
{
    public class ArtistCreateDto
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
