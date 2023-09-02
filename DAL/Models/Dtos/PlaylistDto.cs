using System.ComponentModel.DataAnnotations;

namespace DAL.Models.Dtos
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlaylistPictureUrl { get; set; } 
        public Guid AccountId { get; set; }

        public int numberOfSongs { get; set; }
    }
}
