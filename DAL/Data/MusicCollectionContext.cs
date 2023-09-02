using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class MusicCollectionContext: DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<SongInPlaylist> SongsInPlaylists { get; set; }

        public MusicCollectionContext(DbContextOptions<MusicCollectionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongInPlaylist>()
                  .HasKey(sp => new { sp.SongId, sp.PlaylistId });

            modelBuilder.Entity<Song>()
                .HasMany(s => s.SongsInPlaylists)
                .WithOne(sip => sip.Song)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SongInPlaylist>()
                        .HasOne(sp => sp.Song)
                        .WithMany(s => s.SongsInPlaylists)
                        .HasForeignKey(sp => sp.SongId);

            modelBuilder.Entity<SongInPlaylist>()
                        .HasOne(sp => sp.Playlist)
                        .WithMany(p => p.SongsInPlaylists)
                        .HasForeignKey(sp => sp.PlaylistId);

            modelBuilder.Entity<Account>()
              .HasMany(u => u.Playlists)
              .WithOne(p => p.Account)
              .HasForeignKey(p => p.AccountId);


            modelBuilder.Entity<Artist>()
            .HasMany(a => a.Songs)
            .WithOne(s => s.Artist)
            .HasForeignKey(a => a.ArtistId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
