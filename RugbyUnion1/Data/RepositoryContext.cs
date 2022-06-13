
using Microsoft.EntityFrameworkCore;
using RugbyClub1.Models;

namespace RugbyUnion1.Data
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
