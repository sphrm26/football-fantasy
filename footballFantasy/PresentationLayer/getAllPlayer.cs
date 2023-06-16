using footballFantasy.BuisnessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer;

public class getAllPlayer
{
    public static List<object> gettingPlayer(string token)
    {
        User user = UserHandel.GetUserByToken(token);
        return UserHandel.getAllPlayers(user);
    }
}