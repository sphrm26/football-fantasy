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

    class User
    {
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}