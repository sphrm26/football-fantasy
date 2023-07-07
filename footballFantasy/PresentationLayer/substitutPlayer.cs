using footballFantasy.BuisnessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class substitutPlayer
    {
        public static string substitut(string token, int code1, int code2)
        {
            User user = UserHandel.GetUserByToken(token);
            try
            {
                BuisnessLayer.substitut.sub(user, code1, code2);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "succesfuly swaped";
        }
    }
}
