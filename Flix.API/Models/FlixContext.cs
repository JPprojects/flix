using Microsoft.EntityFrameworkCore;
namespace Flix.API.Models
{
    public class FlixContext : DbContext
    {
        public FlixContext(DbContextOptions<FlixContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        // {
        //     optionBuilder.UseNpgsql("");
        // }
    }
}