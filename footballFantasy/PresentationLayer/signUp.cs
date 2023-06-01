using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class signUp
    {
        public static string signup(string name, string email, string username, string password)
        {
            using (var db = new Database())
            {
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
                //try catch
                //BuisnessLayer.validaitonSignUp.validation(name, email, username, password);

                // otp
                string code = BuisnessLayer.OTP.OTPSet(email);
                waitingUsers newWaitUser = new waitingUsers(username, DateTime.Now, name, email, username, code);
                db.waitingListUsers.Add(newWaitUser);
                db.SaveChanges();
                //go to OTP check api
                //try catch
                // check all in databas ewaiting list

            }

            return "YOUR SIGN UP IS OK !!";

        }
    }
}
