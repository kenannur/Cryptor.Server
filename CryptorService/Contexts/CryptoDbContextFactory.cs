using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CryptorService.Contexts
{
    public class CryptoDbContextFactory : IDesignTimeDbContextFactory<CryptoDbContext>
    {
        public CryptoDbContext CreateDbContext(string[] args)
        {
            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("Default");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<CryptoDbContext>();
            dbContextOptionsBuilder.UseNpgsql(connectionString);

            return new CryptoDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
