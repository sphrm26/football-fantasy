using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace footballFantasy.Model
{
    public class Database : DbContext
    {
        public DbSet<waitingUsers> waitingListUsers { get; set; }
        public DbSet<User>? users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlite("Data source=database.db");
        }
    }
}