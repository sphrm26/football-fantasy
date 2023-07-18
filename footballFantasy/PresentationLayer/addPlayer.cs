using footballFantasy.BuisnessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class addPlayer
    {
        public static string add_Player(string token, int code)
        {
            User user = UserHandel.GetUserByToken(token);
            try
            {
                BuisnessLayer.Team.addplayer(code, user.budget, user);
                UserHandel.deleteMoneyToWallet(code, user);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "successfully added";
        }
    }
}
