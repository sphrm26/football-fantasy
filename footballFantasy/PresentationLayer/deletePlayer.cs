using footballFantasy.Model;
using footballFantasy.BuisnessLayer;
namespace footballFantasy.PresentationLayer;

public class deletePlayer
{
    public static string delete_Player(string token ,int code)
    {
        User user = UserHandel.GetUserByToken(token);
        
        try
        {
            user.team.deletePlayer(code);
            
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "successfully deleted";
    }
}