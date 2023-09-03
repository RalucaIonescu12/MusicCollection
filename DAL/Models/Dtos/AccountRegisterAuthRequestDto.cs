using System.ComponentModel.DataAnnotations;

namespace DAL.Models.DTOs
{
    public class AccountregisterAuthRequestDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
