using footballFantasy.Model;

namespace footballFantasy.PresentationLayer
{
    public class getAllUsers
    {
        public static List<Object> getAllUsersAPI(string adminPassword, string adminName)
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
                return null;
            }
            using (var db = new Database())
            {
                foreach (var item in db.users)
                {
                    response.Add(new
                    {
                        name = item.name,
                        email = item.email,
                        userName = item.userName,
                        password = item.password
                    });
                }
            }
            return response;
        }
    }
}
