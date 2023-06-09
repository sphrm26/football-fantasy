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
            //for checking all users
            app.MapGet("/getAllWaitList/",PresentationLayer.getAllWaitList.getAllWaitListAPI);
            app.Run("http://localhost:3001");
        }
    }
}
