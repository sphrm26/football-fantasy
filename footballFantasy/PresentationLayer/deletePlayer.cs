using footballFantasy.BuisnessLayer;
using footballFantasy.Model;
namespace footballFantasy.PresentationLayer;

public class deletePlayer
{
    public static string delete_Player(string token, int code)
    {
        User user = UserHandel.GetUserByToken(token);

        try
        {
            BuisnessLayer.Team.deletePlayer(code, user);
            UserHandel.addMoneyToWallet(code, user);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "successfully deleted";
    }
}