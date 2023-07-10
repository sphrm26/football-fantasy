using footballFantasy.BuisnessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class addPlayer
    {
         public static string add_Player(string tk,int code)
        {
            User user = UserHandel.GetUserByToken(tk);
            try
            {
                user.team.addplayer(code,user.budget);
                UserHandel.deleteMoneyToWallet(code, user);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "successfully added";
        }
    }
}
