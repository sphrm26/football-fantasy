using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace footballFantasy.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User(string password, string name, string email, string userName)
        {
            this.name = name;
            this.email = email;
            this.userName = userName;
            this.password = password;
        }

        public static void validationEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("please enter your email");
            }
            string pattern = @"[0-9a-ZA-z]{1}[0-9a-zA-Z\.]{5,29}[0-9a-ZA-z]{1}@{1}[0-9a-zA-Z]+\.[a-zA-z]{2,}$";
            if (!Regex.IsMatch(email, pattern))
            {
                throw new Exception("please enter a correct email address.");
            }
        }
        public static void validationName(string name)
        {
            if (name == null)
            {
                throw new Exception("please enter your name");
            }
            Regex regex = new Regex("^(?=.*[a-z])(?=.*\\d).+$");
            if (!Regex.IsMatch(name, "\\d"))
            {
                throw new Exception("No number found.");
            }
            else if (!Regex.IsMatch(name, "[a-z]"))
            {
                throw new Exception("No letter found.");
            }
            if (name.Length >= 30 && name.Length <= 5)
            {
                throw new Exception("your name length must be in range 5 to 30");
            }
        }
        public static void capitalLetterCheck(string str)
        {
            string pattern_AZ = @"(A-Z)+";
            if (Regex.IsMatch(str, pattern_AZ))
            {
                throw new Exception("The Username must contain capital letter ");
            }
        }

        public static void smallLetterCheck(string str)
        {
            string pattern_az = @"(a-z)+";
            if (Regex.IsMatch(str, pattern_az))
            {
                throw new Exception("The Username must contain small letter ");
            }
        }

        public static void numExistanceCheck(string str)
        {
            string pattern_09 = @"(0-9)+";
            if (Regex.IsMatch(str, pattern_09))
            {
                throw new Exception("The Username must contain at least one number");
            }
        }

        public static void symbolExistanceCheck(string str)
        {
            string patternSymbol = @"(\W_)+";
            if (Regex.IsMatch(str, patternSymbol))
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
        public static void usernameCorrectionCheck(string userName)
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

        public static void validationSignup(string userName, string password, string email, string name)
        {
            usernameCorrectionCheck(userName);
            passwordCorrectionCheck(password);
            validationEmail(email);
            validationName(name);
        }
    }

}
