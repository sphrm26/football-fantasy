using footballFantasy.BuisnessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class OTPChecking
    {
        public static string OTPCheck(string otp, string email)
        {
            waitingUsers user;
            try
            {
                user = UserHandel.OTPCheck(otp, email);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            UserHandel.addUser(user, email);
            return "your OTP is correct\nsuccessfuly sign up";
        }
    }
}
