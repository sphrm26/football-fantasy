using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;

namespace footballFantasy.PresentationLayer
{
    public class logIn
    {
        public static string login(string userInformation, string password)
        {
            try
            {
                return UserHandel.login(userInformation, password);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
