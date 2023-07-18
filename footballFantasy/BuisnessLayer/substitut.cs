using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class substitut
    {
        public static void sub(User user, int code1, int code2)
        {
            BuisnessLayer.Team.swapPlayer(code1, code2, user);
            DataAccessLayer.handelUserDatabase.saveChanges(user);
        }
    }
}
