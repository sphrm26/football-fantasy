using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class getAllWaitList
    {
        public static List<Object> getAllWaitListAPI(string adminPassword, string adminName)
        {
            List<Object> response = new List<Object>();
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
                return new List<object> {new
                { error = "access denied"
                } };
            }
            using (var db = new Database())
            {
                foreach (var WaitUser in db.waitingListUsers)
                {
                    response.Add(new
                    {
                        name = WaitUser.name,
                        email = WaitUser.email,
                        userName = WaitUser.userName,
                        password = WaitUser.password
                    });
                }
            }


            return response;
        }
    }
}
