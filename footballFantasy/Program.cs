using ServiceStack;

namespace footballFantasy
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Use((context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                return next();
            });

            app.MapPut("/updatedatabase/", BuisnessLayer.apiRequest.json2csharp);
            app.MapPut("endevent", BuisnessLayer.UserHandel.calculateAllUsersPoint);

            app.MapPost("/signup/", PresentationLayer.signUp.signup);
            app.MapPut("/userPoint/", PresentationLayer.userPoint.calculatePoint);
            app.MapGet("/tablePoint/", PresentationLayer.userPoint.tablePoint);
            app.MapGet("/getMoney/", PresentationLayer.getMoney.gettingMoney);
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
            app.MapPost("/addplyerToteam/", PresentationLayer.addPlayer.add_Player);
            //for deleting user
            app.MapPost("/deletUser/", PresentationLayer.deletUsers.cleaning);
            app.MapGet("/getAllPlayer/", PresentationLayer.getAllPlayer.gettingPlayer);
            app.MapGet("/substitutPlayer/", PresentationLayer.substitutPlayer.substitut);
            app.MapPost("/deletePlayer/", PresentationLayer.deletePlayer.delete_Player);
            app.Run("http://localhost:3001");
        }
    }
}
