using Microsoft.EntityFrameworkCore;
namespace AcebookApi.Models
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        // {
        //     optionBuilder.UseNpgsql("");
        // }
    }
}