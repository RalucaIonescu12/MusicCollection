using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL.Models.Dtos
{
    public class AccountUpdateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
