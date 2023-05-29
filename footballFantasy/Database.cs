using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace footballFantasy
{
    public class Database : DbContext
    {
        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlite("Data source=database.db");
        }
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public static void validationEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("please enter your email");
            }
            string pattern = @"[0-9a-ZA-z]{1}[0-9a-zA-Z\.]{5,29}[0-9a-ZA-z]{1}@{1}[0-9a-zA-Z]+\.[a-zA-z]{2,}$";
            if(!(Regex.IsMatch(email, pattern)))
            {
                throw new Exception("please enter a correct email address.");
            }
        }
    }
}