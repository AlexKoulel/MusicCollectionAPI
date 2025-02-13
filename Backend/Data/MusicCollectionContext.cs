using Microsoft.EntityFrameworkCore;
using MusicCollectionAPI.Backend.Entities;

namespace MusicCollectionAPI.Backend.Data
{
    public class MusicCollectionContext(DbContextOptions<MusicCollectionContext> options) : DbContext(options)
    {
        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Format> Formats => Set<Format>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                  new { Id = 1, Name = "Rock" },
                  new { Id = 2, Name = "Metal" },
                  new { Id = 3, Name = "Hip-Hop" },
                  new { Id = 4, Name = "Pop" },
                  new { Id = 5, Name = "Jazz" },
                  new { Id = 6, Name = "Ambient" },
                  new { Id = 7, Name = "Electronic" },
                  new { Id = 8, Name = "Classical" },
                  new { Id = 9, Name = "Indie" },
                  new { Id = 10, Name = "Punk" }
                );

            modelBuilder.Entity<Format>().HasData(
                    new { Id = 1, Name = "Digital" },
                    new { Id = 2, Name = "CD" },
                    new { Id = 3, Name = "Vinyl" },
                    new { Id = 4, Name = "Cassette" }
                );
        }
    }
}
