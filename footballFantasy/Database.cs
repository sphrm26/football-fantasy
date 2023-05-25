using Microsoft.EntityFrameworkCore;

namespace footballFantasy
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlite("Data source=database.db");
        }
    }
}