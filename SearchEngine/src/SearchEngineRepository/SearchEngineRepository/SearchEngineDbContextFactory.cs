using Microsoft.EntityFrameworkCore;

namespace SearchEngineRepository
{
    public class SearchEngineDbContextFactory
    {
        private IConfiguration configuration;

        public SearchEngineDbContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public SearchEngineDbContext CreateDbContext()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SearchEngineDbContext>();
            var tasksConnectionString = configuration.GetConnectionString("SearchEngineRepository");
            dbContextOptionsBuilder.UseSqlServer(tasksConnectionString);
            return new SearchEngineDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
