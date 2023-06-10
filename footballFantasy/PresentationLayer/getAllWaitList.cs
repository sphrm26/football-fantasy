using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;

namespace footballFantasy.PresentationLayer
{
    public class getAllWaitList
    {
        public static List<Object> getAllWaitListAPI(string adminPassword, string adminName)
        {
            try
            {
                adminHandel.access(adminPassword, adminName);
            }
            catch (Exception e)
            {
                return null;
            }
            return adminHandel.getAllWaitList();
        }
    }
}
