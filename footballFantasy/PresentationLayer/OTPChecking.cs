using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class OTPChecking
    {
        public static string OTPCheck(string otp, string email)
        {
            var waitUser = handelUserDatabase.findWaitUser(otp, email);
            if (waitUser == null)
            {
                handelExpireOTPDatabase.checkAllOTPForExpire();
                return "your OTP is incorrect";
            }
            if (expireOTP.checkExpire(waitUser))
            {
                handelExpireOTPDatabase.checkAllOTPForExpire();
                return "your OTP is expired";
            }
            //add to user class
            User newUser = new User(waitUser.password, waitUser.name, waitUser.email, waitUser.userName);
            handelUserDatabase.addToUsers(newUser);
            //remove from wait list
            handelUserDatabase.removeFromWaitList(waitUser);
            return "your OTP is correct\nsuccessfuly sign up";
        }
    }
}
