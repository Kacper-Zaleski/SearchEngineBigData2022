using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SearchEngineRepository.Repositories
{
    public class DesignTimeSearchEngineDbContext: IDesignTimeDbContextFactory<SearchEngineDbContext>
    {
        public SearchEngineDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SearchEngineDbContext>();
            var migrationsAssembly = GetType().Assembly.GetName().Name;
            var connectionString = config.GetConnectionString("SearchEngineRepository");
            optionsBuilder.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
            });

            return new SearchEngineDbContext(optionsBuilder.Options);
        }
    }
}
