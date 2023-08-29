

using MusicCollection.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models
{
    public class Artist: BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        public string? ArtistPictureUrl { get; set; } = string.Empty;
        public ICollection<Song?> Songs { get; set; }= new List<Song>();

    }
}
