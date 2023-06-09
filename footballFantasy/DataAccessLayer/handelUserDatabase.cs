using footballFantasy.Model;

namespace footballFantasy.DataAccessLayer
{
    public class handelUserDatabase
    {
        public static bool isSameEmailWaitUserFind(string email)
        {
            using (var db = new Database())
            {
                var record = db.waitingListUsers.FirstOrDefault(record => record.email == email);
                if (record != null)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isSameUserNameWaitUserFind(string userName)
        {
            using (var db = new Database())
            {
                var record = db.waitingListUsers.FirstOrDefault(record => record.userName == userName);
                if (record != null)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isSameEmailUserFind(string email)
        {
            using (var db = new Database())
            {
                var record = db.users.FirstOrDefault(record => record.email == email);
                if (record != null)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isSameUserNameUserFind(string userName)
        {
            using (var db = new Database())
            {
                var record = db.users.FirstOrDefault(record => record.userName == userName);
                if (record != null)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool findUserName(string userName,string password)
        {
            using (var db = new Database())
            {
                var record = db.users.FirstOrDefault(record => record.userName == userName && record.password == password);
                if (record != null)
                {
                    return true;
                }
            }
            return false;
        }
        public static void addToWaitList(waitingUsers newWaitUser)
        {
            using (var db = new Database())
            {
                db.waitingListUsers.Add(newWaitUser);
                db.SaveChanges();
            }
        }
    }
}
