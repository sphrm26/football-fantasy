using footballFantasy.BuisnessLayer;

namespace footballFantasy.PresentationLayer
{
    public class signUp
    {
        public static string signup(string email, string username, string name, string password)
        {
            try
            {
                UserHandel.OTPCheck("otp", email);
            }
            catch
            {
            }
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
            UserHandel.makeNewWaitUser(password, name, email, username, code);

            return "please enter your otp";

            //go to OTP check api
        }
    }
}