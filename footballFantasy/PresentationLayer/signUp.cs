using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class signUp
    {
        public static string signup(User newUser)
        {
            string name = newUser.name, email = newUser.email, username = newUser.userName, password = newUser.password;
            try
            {
                UserHandel.sameUserCheck(email, username);
                UserHandel.sameWaitUserCheck(email, username);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            try
            {
                validaitonSignUp.validation(name, email, username, password);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            // otp
            string code = OTP.OTPSet(Convert.ToString(email));
            UserHandel.makeNewWaitUser(password,name,email,username,code);

            return "please enter your otp";

            //go to OTP check api
        }
    }
}