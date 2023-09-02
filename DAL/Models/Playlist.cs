using DAL.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class Playlist:BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;
        public string? PlaylistPictureUrl { get; set; } = string.Empty;
        public Account Account { get; set; }
        public Guid AccountId { get; set; }
        public ICollection<SongInPlaylist> SongsInPlaylists { get; set; } = new List<SongInPlaylist>();

    }
}
