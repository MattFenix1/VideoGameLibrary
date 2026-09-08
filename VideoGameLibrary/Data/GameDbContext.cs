using VideoGameLibrary.Models;
using Microsoft.EntityFrameworkCore;
using VideoGameLibrary.Models;
namespace VideoGameLibrary.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(
            DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
    }
}