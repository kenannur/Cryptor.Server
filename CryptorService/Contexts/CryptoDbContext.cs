using CryptorService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptorService.Contexts
{
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options)
            : base(options)
        { }

        //static CryptoDbContext()
        //{
        //    NpgsqlConnection.GlobalTypeMapper.MapEnum<CompetitionType>();
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasPostgresEnum<CompetitionType>();
        //}

        public DbSet<Test> Tests { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
