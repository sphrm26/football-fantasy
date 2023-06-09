using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;

namespace footballFantasy.PresentationLayer
{
    public class deletUsers
    {
        public static string cleaning(string adminPassword, string adminName)
        {
            try
            {
                adminHandel.access(adminPassword, adminName);
            }
            catch (Exception e)
            {
                return "access denied";
            }
            handelUserDatabase.deletAllUsers();
            return "successfuly deleted";
        }
    }
}
