using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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

        public static void capitalLetterCheck(string str)
        {
            string pattern_AZ =@"(A-Z)+";
            if (Regex.IsMatch(str,pattern_AZ))
            {
                throw new Exception ("The Username must contain capital letter ");
            }
        }

        public static void smallLetterCheck(string str)
        {
            string pattern_az= @"(a-z)+";
            if (Regex.IsMatch(str,pattern_az))
            {
                throw new Exception ("The Username must contain small letter ");
            }
        }

        public static void numExistanceCheck(string str)
        {
            string pattern_09 = @"(0-9)+";
            if (Regex.IsMatch(str,pattern_09))
            {
                throw new Exception ("The Username must contain at least one number");
            }
        }

        public static void symbolExistanceCheck(string str)
        {
            string patternSymbol = @"(\W_)+";
            if (Regex.IsMatch(str,patternSymbol))
            {
                throw new Exception("The Password must contain at least one Symbol");
            }
        }
        public static void passwordCorrectionCheck(string password)
        {
            if (password.Length < 8 && password.Length > 30)
            {
                throw new Exception("The Password length must be in range 8-30");
            }
            smallLetterCheck(password);
            capitalLetterCheck(password);
            numExistanceCheck(password);
            symbolExistanceCheck(password);
        }
        public static void usernameCorrectionCheck( string userName)
        {
            if (userName.Length < 5 && userName.Length > 50)
            {
                throw new Exception("The Username length must be in range 5-50");
            }
            smallLetterCheck(userName);
            capitalLetterCheck(userName);
            numExistanceCheck(userName);
            symbolExistanceCheck(userName);
        }

        public static void validationSignup(string userName , string password)
        {
            usernameCorrectionCheck( userName);
            passwordCorrectionCheck( password);
        } 
    }
}