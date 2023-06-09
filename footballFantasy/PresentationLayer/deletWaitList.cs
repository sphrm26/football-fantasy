using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class deletWaitList
    {
        public static string cleaning(string adminPassword, string adminName)
        {
            bool access = false;
            foreach (var admin in BuisnessLayer.adminHandel.admins)
            {
                if (adminName == admin.Name && adminPassword == admin.password)
                {
                    access = true;
                    break;
                }
            }
            if (!access)
            {
                return "access denied";
            }
            using (var db = new Database())
            {
                foreach (var item in db.waitingListUsers)
                {
                    db.waitingListUsers.Remove(item);
                }
                db.SaveChanges();
            }
            return "successfuly deleted";
        }
    }
}
