using System.ComponentModel.DataAnnotations;

namespace DAL.Models.DTOs
{
    public class AccountAuthRequestDto
    {

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
