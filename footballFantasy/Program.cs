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
                            return "your OTP is expired";
                        }
                        return "tour OTP is correct";
                    }
                }
            }
            return "your OTP is incorrect";
        }

        public static string signup(string name, string email, string username, string password)
        {
            User newUser = new User();
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
                WaitingUsers newWaitUser = new WaitingUsers(username, DateTime.Now, name, email, username, code);
                db.waitingListUsers.Add(newWaitUser);
                db.SaveChanges();
                //go to OTP check api
                //try catch
                // check all in databas ewaiting list

                db.users.Add(newUser);
                db.SaveChanges();

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
