using DAL.Models;
using System.Reflection;

namespace DAL.Models
{
    public class SongInPlaylist
    {
        public Guid SongId { get; set; }
        public Song Song { get; set; }
        public Guid? PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
    }
}
