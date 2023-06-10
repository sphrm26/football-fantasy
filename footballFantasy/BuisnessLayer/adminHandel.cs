using footballFantasy.DataAccessLayer;
using footballFantasy.Model;
namespace footballFantasy.BuisnessLayer
{
    public static class adminHandel
    {
        public static List<admin> admins = new List<admin>() { new admin("Sepehr", "sphrm26sphrm26") };
        public static void access(string adminPassword, string adminName)
        {
            foreach (var admin in admins)
            {
                if (adminName == admin.Name && adminPassword == admin.password)
                {
                    return;
                }
            }
            throw new Exception("access denied");
        }
        public static List<Object> getAllWaitList()
        {
            return handelUserDatabase.getAllWaitList();
        }
        public static List<Object> getAllUser()
        {
            return handelUserDatabase.getAllUser();
        }
        public static void deletAllWaitList()
        {
            handelUserDatabase.deletAllWaitList();
        }
        public static void deletAllUsers()
        {
            handelUserDatabase.deletAllUsers();
        }
    }
}
