using footballFantasy.Model;

namespace footballFantasy.BuisnessLayer
{
    public class expireOTP
    {
        public static bool checkExpire(waitingUsers item)
        {
            TimeSpan timesAfterSending = DateTime.Now - item.dt;
            if (timesAfterSending.TotalMinutes > 5)
            {
                return true;
            }
            return false;
        }
    }
}
