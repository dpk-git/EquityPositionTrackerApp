

using EquityPositionTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EquityPositionTrackerAPI.Data
{
    // Change base class from System.Data.Entity.DbContext to Microsoft.EntityFrameworkCore.DbContext
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionID);

            modelBuilder.Entity<Position>()
                .HasKey(p => p.SecurityCode);
        }
    }
}
