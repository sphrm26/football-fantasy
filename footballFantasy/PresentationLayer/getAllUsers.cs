using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;

namespace footballFantasy.PresentationLayer
{
    public class getAllUsers
    {
        public static List<Object> getAllUsersAPI(string adminPassword, string adminName)
        {
            try
            {
                adminHandel.access(adminPassword, adminName);
            }
            catch (Exception e)
            {
                return null;
            }
            return handelUserDatabase.getAllUser();
        }
    }
}
