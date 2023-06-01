namespace footballFantasy
{
    public class Program
    {
        public static void Main(String[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.Run("http://localhost:3001");
            app.MapPost("/singnup/",PresentationLayer.signUp.signup);
            app.MapPost("/OTPCheck/", PresentationLayer.OTPChecking.OTPCheck);
        }
    }
}
