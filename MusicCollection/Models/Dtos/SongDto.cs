using System.ComponentModel.DataAnnotations;

namespace MusicCollection.Models.Dtos
{
    public class SongDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public string Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Guid ArtistId { get; set; }
    }
}
