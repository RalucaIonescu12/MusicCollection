
using DAL.Models;
using DAL.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Song: BaseEntity
    {
        [MaxLength(30)]
        public string Title { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public Guid ArtistId { get; set; }

        public Artist Artist { get; set; }
        public ICollection<SongInPlaylist> SongsInPlaylists { get; set; } = new List<SongInPlaylist>();

    }
}
