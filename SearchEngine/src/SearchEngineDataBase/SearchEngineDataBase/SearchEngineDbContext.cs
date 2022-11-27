using SearchEngineDataBase.Entity;
using System.Data.Entity;

namespace SearchEngineDataBase
{
    public class SearchEngineDbContext : DbContext
    {
        public virtual DbSet<InvertedIndex> InvertedIndex { get; set; }
        public virtual DbSet<Index> Index { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=tcp:big-data-project-2022.database.windows.net,1433;Initial Catalog=BigData;Persist Security Info=False;User ID=kacper;Password=Qk@NH3&hQbfNDJn5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
    }
}
