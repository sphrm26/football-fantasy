namespace footballFantasy
{
    public class Program
    {
        public static string OTPCheck(string otp, string email)
        {
            using (var db = new Database())
            {
                foreach (var item in db.waitingListUsers)
                {
                    if (item.email == email && item.OTP == otp)
                    {
                        if (item.checkExpire())
                        {
                            waitingUsers.checkAllOTPForExpire();
                            return "your OTP is expired";
                        }
                        db.users.Add(new User(item.password, item.name, item.email, item.userName));
                        db.waitingListUsers.Remove(item);
                        db.SaveChanges();
                        waitingUsers.checkAllOTPForExpire();
                        return "your OTP is correct";
                    }
                }
            }
            waitingUsers.checkAllOTPForExpire();
            return "your OTP is incorrect";
        }

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
                //validation

                // otp
                Random rnd = new Random();
                int randNum = rnd.Next(100000, 1000000);
                string code = Convert.ToString(randNum);
                User.sendOTP(email, code);
                waitingUsers newWaitUser = new waitingUsers(username, DateTime.Now, name, email, username, code);
                db.waitingListUsers.Add(newWaitUser);
                db.SaveChanges();
                //go to OTP check api
                //try catch
                // check all in databas ewaiting list

            }

            return "YOUR SIGN UP IS OK !!";

        }

        public static void Main(String[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.Run("http://localhost:3001");
            app.MapPost("/singnup/", signup);

        }
    }
}
