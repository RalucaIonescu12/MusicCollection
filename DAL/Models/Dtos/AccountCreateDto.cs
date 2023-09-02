using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL.Models.Dtos
{
    public class AccountCreateDto
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(30)]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
