using footballFantasy.Model;

namespace footballFantasy.PresentationLayer;

public class getMoney
{
    public static string gettingMoney(string token)
    {
       User user =BuisnessLayer.UserHandel.GetUserByToken(token);
       return Convert.ToString(user.budget);
    }
}