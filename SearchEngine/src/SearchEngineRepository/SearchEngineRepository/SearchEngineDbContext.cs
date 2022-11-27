using Microsoft.EntityFrameworkCore;
using SearchEngineRepository.Entity;

namespace SearchEngineRepository
{
    public class SearchEngineDbContext : DbContext
    {
        private string connectionString { get; set; }

        public SearchEngineDbContext(DbContextOptions options)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            connectionString = config.GetConnectionString("SearchEngineRepository");
        }

        public DbSet<InvertedIndex> InvertedIndex { get; set; }
        public DbSet<BookIndex> Index { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}