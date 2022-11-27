using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SearchEngineDataBase.Repositories
{
    public class DesignTimeSearchEngineDbContext
    {
        public SearchEngineDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PriceListsDbContext>();
            var migrationsAssembly = GetType().Assembly.GetName().Name;
            var connectionString = config.GetConnectionString("PriceListsDatabase");
            optionsBuilder.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
                sql.EnableDefaultRetryOnFailure();
            });

            return new SearchEngineDbContext(optionsBuilder.Options, null);
        }
    }
}
