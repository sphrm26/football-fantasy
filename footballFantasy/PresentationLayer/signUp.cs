using footballFantasy.Model;
using System.Net.Mail;

namespace footballFantasy.PresentationLayer
{
    public class signUp
    {
        public static string signup(User newUser)
        {
            string name = newUser.name, email = newUser.email, username = newUser.userName, password = newUser.password;
            using (var db = new Database())
            {
                //foreach(var in db.waituser)
                foreach (var user in db.users)
                {
                    if (username == user.userName)
                    {
                        return "YOUR USERNAME IS ALREADY EXIST ";

                    }

                    if (email == user.email)
                    {
                        return "YOUR EMAIL IS ALREADY EXIST";

                    }
                }
                try
                {
                    BuisnessLayer.validaitonSignUp.validation(name, email, username, password);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                // otp
                string code = BuisnessLayer.OTP.OTPSet(email);
                waitingUsers newWaitUser = new waitingUsers(username, DateTime.Now, name, email, username, code);
                db.waitingListUsers.Add(newWaitUser);
                db.SaveChanges();

                //go to OTP check api

            return $"{code}\n{email}\nYOUR SIGN UP IS OK !!";
            }


        }
    }
}
