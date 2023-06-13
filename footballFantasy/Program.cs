namespace footballFantasy
{
    public class Program
    {
        public static void Main(String[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapPost("/signup/", PresentationLayer.signUp.signup);
            app.MapPost("/OTPCheck/", PresentationLayer.OTPChecking.OTPCheck);
            app.MapGet("/login/", PresentationLayer.logIn.login);
            app.MapPost("/forgetPassword/", PresentationLayer.forgetPassWord.remakePassword);
            app.MapPost("/getOTP/", PresentationLayer.forgetPassWord.getOTP);
            //for checking all waitusers
            app.MapGet("/getAllWaitList/", PresentationLayer.getAllWaitList.getAllWaitListAPI);

            //for checking all users
            app.MapGet("/getAllUser/", PresentationLayer.getAllUsers.getAllUsersAPI);

            //for deleting wait user
            app.MapPost("/deletWaitUser/", PresentationLayer.deletWaitList.cleaning);

            //for deleting user
            app.MapPost("/deletUser/", PresentationLayer.deletUsers.cleaning);

            app.Run("http://localhost:3001");
        }
    }
}
