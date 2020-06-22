using Microsoft.EntityFrameworkCore;
namespace AcebookApi.Models
{
    public class FlixContext : DbContext
    {
        public FlixContext(DbContextOptions<FlixContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        // {
        //     optionBuilder.UseNpgsql("");
        // }
    }
}