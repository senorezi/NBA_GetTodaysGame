using GetTodaysGame.Entities.SqlLite;
using Microsoft.EntityFrameworkCore;
namespace GetTodaysGame.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
