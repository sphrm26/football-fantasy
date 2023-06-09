using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;

namespace footballFantasy.PresentationLayer
{
    public class logIn
    {
        public static string login(string username, string password)
        {
            try
            {
                return UserHandel.getToken(username, password);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
