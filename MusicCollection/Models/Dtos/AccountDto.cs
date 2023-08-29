using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string? ProfilePictureUrl { get; set; }
    }
}
