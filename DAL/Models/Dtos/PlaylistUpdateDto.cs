using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Dtos
{
    public class PlaylistUpdateDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; } = "";
    }
}
