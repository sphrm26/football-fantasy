﻿using footballFantasy.BuisnessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class forgetPassWord
    {
        public static string getOTP(string email, string newPassword, string otp)
        {
            //validation password
            try
            {
                validaitonSignUp.passwordCorrectionCheck(newPassword);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            //check correct OTP
            waitingUsers user;
            try
            {
                user = UserHandel.OTPCheck(otp, email);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            //add new user
            //remove wait user
            UserHandel.changeUserPassword(newPassword, user.email);
            return "your password successfuly changed";
        }
        public static string remakePassword(string email, string userName)
        {
            //find user
            try
            {
                UserHandel.findUserByEmailAndUserName(email, userName);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            try
            {
                UserHandel.OTPCheck("otp", email);
            }
            catch
            {
            }
            //send email
            string code = OTP.OTPSet(email);
            //make new wait user
            //we must change it to a new tabel type!!!!!!!!!!!!!!
            UserHandel.makeNewWaitUser("password", "name", email, userName, code);
            return "please enter your otp";
        }
    }
}
