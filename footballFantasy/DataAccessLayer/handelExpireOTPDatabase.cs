using footballFantasy.Model;
using footballFantasy.BuisnessLayer;

namespace footballFantasy.DataAccessLayer
{
    public class handelExpireOTPDatabase
    {
        public static void checkAllOTPForExpire()
        {
            using (var db = new Database())
            {
                foreach (var item in db.waitingListUsers)
                {
                    if (expireOTP.checkExpire(item))
                    {
                        db.waitingListUsers.Remove(item);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
