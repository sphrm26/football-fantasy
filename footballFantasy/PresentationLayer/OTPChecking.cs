﻿using footballFantasy.BuisnessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class OTPChecking
    {
        public static string OTPCheck(string otp, string email)
        {
            using (var db = new Database())
            {
                foreach (var item in db.waitingListUsers)
                {
                    if (item.email == email && item.OTP == otp)
                    {
                        if (expireOTP.checkExpire(item))
                        {
                            DataAccessLayer.handelExpireOTPDatabase.checkAllOTPForExpire();
                            return "your OTP is expired";
                        }
                        db.users.Add(new User(item.password, item.name, item.email, item.userName));
                        db.waitingListUsers.Remove(item);
                        db.SaveChanges();
                        DataAccessLayer.handelExpireOTPDatabase.checkAllOTPForExpire();
                        return "your OTP is correct";
                    }
                }
            }
            DataAccessLayer.handelExpireOTPDatabase.checkAllOTPForExpire();
            return "your OTP is incorrect";
        }
    }
}
