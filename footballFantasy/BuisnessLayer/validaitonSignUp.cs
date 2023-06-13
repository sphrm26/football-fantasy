using System.Text.RegularExpressions;

namespace footballFantasy.BuisnessLayer
{
    public class validaitonSignUp
    {
        public static void validationEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("please enter your email");
            }
            string pattern = @"^[a-zA-Z0-9]+(?:[a-zA-Z0-9._-]*[a-zA-Z0-9])?@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, pattern))
            {
                throw new Exception("please enter a correct email address.");
            }
        }
        public static void validationName(string name)
        {
            if (name.Length == 0)
            {
                throw new Exception("please enter your name");
            }
            if (name.Length > 30)
            {
                throw new Exception("maximum length of name is 30 characters");
            }
        }
        public static void capitalLetterCheck(string str)
        {
            string pattern_AZ = @"[A-Z]+";
            if (!Regex.IsMatch(str, pattern_AZ))
            {
                throw new Exception("The pass word must contain capital letter ");
            }
        }

        public static void smallLetterCheck(string str)
        {
            string pattern_az = @"[a-z]+";
            if (!Regex.IsMatch(str, pattern_az))
            {
                throw new Exception("The pass word must contain small letter ");
            }
        }

        public static void numExistanceCheck(string str)
        {
            string pattern_09 = @"[0-9]+";
            if (!Regex.IsMatch(str, pattern_09))
            {
                throw new Exception("The pass word must contain at least one number");
            }
        }
        public static void passwordCorrectionCheck(string password)
        {
            if (password.Length < 8 || password.Length > 30)
            {
                throw new Exception("The Password length must be in range 8-30");
            }
            string pattern = @"^[A-Za-z0-9@#$%^&*+=_!]*$";
            if (!Regex.IsMatch(password, pattern))
            {
                throw new Exception("you can only use numbers and letters and this symboles {@ # $ % ^ & * + = _ !} for password");
            }
            smallLetterCheck(password);
            capitalLetterCheck(password);
            numExistanceCheck(password);
        }

        public static void usernameCorrectionCheck(string userName)
        {
            if (userName.Length < 5 || userName.Length > 50)
            {
                throw new Exception("The Username length must be in range 5-50");
            }

            string pattern = @"^[A-Za-z0-9]*$";
            if (!Regex.IsMatch(userName, pattern))
            {
                throw new Exception("you can only use numbers and letters for user name");
            }
        }


        public static void validation(string name, string email, string userName, string password)
        {
            usernameCorrectionCheck(userName);
            passwordCorrectionCheck(password);
            validationEmail(email);
            validationName(name);
        }
    }
}
