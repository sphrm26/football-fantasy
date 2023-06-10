using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class OTPChecking
    {
        public static string OTPCheck(string otp, string email)
        {
            return UserHandel.OTPCheck(otp, email);
        }
    }
}
