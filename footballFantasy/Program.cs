namespace footballFantasy
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            
            app.Run("http://localhost:3001");
        }
    }
}
