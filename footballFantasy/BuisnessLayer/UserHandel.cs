using footballFantasy.DataAccessLayer;
using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class UserHandel
    {
        public static void sameUserCheck(string email, string username)
        {
            if (DataAccessLayer.handelUserDatabase.isSameEmailUserFind(email))
            {
                throw new Exception("your email is already exist");
            }
            if (DataAccessLayer.handelUserDatabase.isSameUserNameUserFind(username))
            {
                throw new Exception("your user name is already exist");
            }
        }
        public static void sameWaitUserCheck(string email, string username)
        {
            if (DataAccessLayer.handelUserDatabase.isSameEmailWaitUserFind(email))
            {
                throw new Exception("your email is already exist");
            }
            if (DataAccessLayer.handelUserDatabase.isSameUserNameWaitUserFind(username))
            {
                throw new Exception("your user name is already exist");
            }
        }
        public static string getToken(string username, string password)
        {
            if (handelUserDatabase.findUserName(username, password))
            {
                string token = tokenHandel.Get_Token(username);
                return token;
            }
            throw new Exception("your user name is incorrect");
        }
        public static void makeNewWaitUser(string password, string name, string email, string username, string code)
        {
            waitingUsers newWaitUser = new waitingUsers(password, DateTime.Now, name, email, username, code);
            handelUserDatabase.addToWaitList(newWaitUser);
        }
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
            handelUserDatabase.removeFromWaitList(email);
            return "your OTP is correct\nsuccessfuly sign up";
        }
    }
}
