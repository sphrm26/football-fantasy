using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public static validation (string userName,string name,string email,string password)
        {
            usernameCorrectionCheck( element, userName);
            passwordCorrectionCheck(element , password);
        }
        public static void usernameCorrectionCheck(char element, string userName)
        {
            numCheck(element);
            letterCheck(element);
            usernameCharCheck(element);
            usernameLengthCheck(userName);
        }

        public static void passwordCorrectionCheck(char element, string password)
        {
            passwordLengthCheck(password);
                numCheck(element);
                letterCheck(element);
                passwordCharCheck(element);
            }
            public static bool usernameLengthCheck(string userName)
            {
                if (userName.Length >=8)
                {
                    return true;
                }
                throw new Exception ("The Username length must be at least 8");
            
            }

            public static bool passwordLengthCheck(string password)
            {
                if (password.Length >=8)
                {
                    return true;
                }
                throw new Exception ("The Password length must be at least 8");
            }
            public static bool usernameCharCheck(char element)
            {
                if (element == '.' || element == '-' || element == '_')
                {
                    return true;
                }

                throw new Exception ("The Username must contain at least one Character ('.' , '-' , '_')");
            }
            public static bool passwordCharCheck(char element)
            {
                if (element == '.' || element == '-' || element == '_' || element == '@' || element == '#' || element == '&') ;
                {
                    return true;
                }

                throw new Exception("The Password must contain at least one Character ('.' , '-' , '_')");
            }
            

            public static bool letterCheck(char element)
            {
                
                if ((element>='A')&&('Z'>=element))
                {
                    return true;
                }
                if ((element>='a')&&('z'>=element))
                {
                    return true;
                }
                throw new Exception ("The Username must contain capital letter and small letter both");
            }

            public static bool numCheck(char element)
            {
                if ((element >= '0') && ('9' >= element))
                {
                    return true;
                }
                throw new Exception ("The Username must contain at least one number");
            }

            public User(string name, string userName, string password, string email)
            {
                 
                this.name = name;
                this.userName = userName;
                this.password = password;
                this.email = email;
                
            }

          
            
        
    }

}
        