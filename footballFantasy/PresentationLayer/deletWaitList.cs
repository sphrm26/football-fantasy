using footballFantasy.BuisnessLayer;
using footballFantasy.DataAccessLayer;
using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class deletWaitList
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
            adminHandel.deletAllWaitList();
            return "successfuly deleted";
        }
    }
}
