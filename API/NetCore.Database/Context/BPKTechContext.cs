using Code.Model;
using Microsoft.EntityFrameworkCore;

namespace Code.Database.Context
{
    public class BPKTechContext : DbContext
    {
        public BPKTechContext(DbContextOptions<BPKTechContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}