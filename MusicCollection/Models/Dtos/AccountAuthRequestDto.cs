using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models.DTOs
{
    public class AccountAuthRequestDto
    {

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public string? Name { get; set; }
    }
}
