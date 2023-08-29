
using MusicCollection.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicCollection.Models
{
    public class Account:BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Email { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }= string.Empty;
        public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
