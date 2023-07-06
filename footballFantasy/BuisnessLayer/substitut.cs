using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class substitut
    {
        public static void sub(User user,int code1,int code2)
        {
            //swapp
            DataAccessLayer.handelUserDatabase.saveChanges(user);
        }
    }
}
