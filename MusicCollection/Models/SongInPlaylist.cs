using MusicCollection.Models;
using System.Reflection;

namespace MusicCollection.Models
{
    public class SongInPlaylist
    {
        public Guid SongId { get; set; }
        public Song Song { get; set; }
        public Guid? PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
    }
}
