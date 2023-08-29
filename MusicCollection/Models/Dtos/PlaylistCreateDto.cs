using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models.Dtos
{
    public class PlaylistCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; } = "";
    }
}
