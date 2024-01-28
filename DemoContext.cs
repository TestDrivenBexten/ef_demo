using Microsoft.EntityFrameworkCore;

namespace EfDemo
{
    public class DemoContext : DbContext
    {
        public DbSet<Account> Accounts;
        public DbSet<Share> Shares;
        public string DbPath { get; }

        public DemoContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
