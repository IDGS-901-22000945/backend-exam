using Microsoft.EntityFrameworkCore;
using BazarUniversalAPI.Models;

namespace BazarUniversalAPI.Data
{
    public class BazarContext : DbContext
    {
        public BazarContext(DbContextOptions<BazarContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
