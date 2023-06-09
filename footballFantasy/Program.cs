using footballFantasy.Model;

namespace footballFantasy
{
    public class Program
    {
        public static void Main(String[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapPost("/signup/",PresentationLayer.signUp.signup);
            app.MapPost("/OTPCheck/", PresentationLayer.OTPChecking.OTPCheck);
            app.MapGet("/login/", PresentationLayer.logIn.login);
            //for checking all waitusers
            app.MapGet("/getAllWaitList/",PresentationLayer.getAllWaitList.getAllWaitListAPI);

            //for checking all users
            app.MapGet("/getAllUser/", PresentationLayer.getAllUsers.getAllUsersAPI);

            //for deleting wait user
            app.MapGet("/deletWaitUser/", PresentationLayer.deletWaitList.cleaning);

            //for deleting user
            app.MapGet("/deletUser/", PresentationLayer.deletUsers.cleaning);

            app.Run("http://localhost:3001");
        }
    }
}
