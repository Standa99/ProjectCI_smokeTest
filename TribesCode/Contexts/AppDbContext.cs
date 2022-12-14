using dusicyon_midnight_tribes_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dusicyon_midnight_tribes_backend.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}