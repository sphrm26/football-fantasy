using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class logIn
    {
        public static string login(string username, string password)
        {
            using (var db = new Database())
            {
                foreach (var user in db.users)
                {
                    if (username == user.userName && password == user.password)
                    {
                        string token = BuisnessLayer.tokenHandel.Get_Token(username);
                        return token;
                    }
                }
            }
            return "your user name is not found";
        }
    }
}
