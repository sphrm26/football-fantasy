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
        public static User? findUserByemail(string email)
        {
            using (var db = new Database())
            {
                var record = db.users.FirstOrDefault(record => record.email == email);
                return record;
            }
        }
        public static User? findUserByUserName(string userName)
        {
            using (var db = new Database())
            {
                var record = db.users.FirstOrDefault(record => record.userName == userName);
                return record;
            }
        }
        public static waitingUsers? findWaitUser(string otp, string email)
        {
            using (var db = new Database())
            {
                var record = db.waitingListUsers.FirstOrDefault(record => record.email == email && record.OTP == otp);
                return record;
            }
        }
        public static void addToWaitList(waitingUsers newWaitUser)
        {
            using (var db = new Database())
            {
                db.waitingListUsers.Add(newWaitUser);
                db.SaveChanges();
            }
        }
        public static void removeFromWaitList(string email)
        {
            using (var db = new Database())
            {
                foreach (var record in db.waitingListUsers)
                {
                    if (email == record.email)
                    {
                        db.waitingListUsers.Remove(record);
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void addToUsers(User newUser)
        {
            using (var db = new Database())
            {
                db.users.Add(newUser);
                db.SaveChanges();
            }
        }
        public static List<Object> getAllWaitList()
        {
            List<Object> response = new List<Object>();
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
        public static List<Object> getAllUser()
        {
            List<Object> response = new List<Object>();
            using (var db = new Database())
            {
                foreach (var user in db.users)
                {
                    response.Add(new
                    {
                        name = user.name,
                        email = user.email,
                        userName = user.userName,
                        password = user.password
                    });
                }
            }
            return response;
        }
        public static void deletAllWaitList()
        {
            using (var db = new Database())
            {
                foreach (var item in db.waitingListUsers)
                {
                    db.waitingListUsers.Remove(item);
                }
                db.SaveChanges();
            }
        }
        public static void deletAllUsers()
        {
            using (var db = new Database())
            {
                foreach (var item in db.users)
                {
                    db.users.Remove(item);
                }
                db.SaveChanges();
            }
        }
        public static void changingPassword(string email, string password)
        {
            using (var db = new Database())
            {
                var record = db.users.FirstOrDefault(record => record.email == email);
                record.password = password;
                db.SaveChanges();
            }
        }
        public static User? findUserByEmailAndUserName(string email, string userName)
        {
            using (var db = new Database())
            {
                var record = db.users.FirstOrDefault(record => record.email == email && record.userName == userName);
                return record;
            }
        }
        public static void saveChanges(User user)
        {
            using (var db = new Database())
            {
                /*foreach(var item in db.users)
                {
                    if (item.email == user.email)
                    {
                        db.users[i] = user;
                        db.SaveChanges();
                        return;
                    }
                    i++;
                }*/
                Console.WriteLine(user.team.insideMID[0]);
                Console.WriteLine(user.team.insideMID[1]);
                Console.WriteLine(user.team.insideMID[2]);
                Console.WriteLine(user.team.insideMID[3]);

                var record = db.users.FirstOrDefault(record => record.userName == user.userName);
                record.team.insideMID[0] = user.team.insideMID[0];

                Console.WriteLine(record.team.insideMID[0]);
                Console.WriteLine(record.team.insideMID[1]);
                Console.WriteLine(record.team.insideMID[2]);
                Console.WriteLine(record.team.insideMID[3]);

                Console.WriteLine(record.team.insideMID[0]);
                Console.WriteLine(record.team.insideMID[1]);
                Console.WriteLine(record.team.insideMID[2]);
                Console.WriteLine(record.team.insideMID[3]);

                db.users.Remove(record);
                db.SaveChanges();
                db.users.Add(user);
                db.SaveChanges();


                var record1 = db.users.FirstOrDefault(record => record.userName == user.userName);


                Console.WriteLine(record1.team.insideMID[0]);
                Console.WriteLine(record1.team.insideMID[1]);
                Console.WriteLine(record1.team.insideMID[2]);
                Console.WriteLine(record1.team.insideMID[3]);
            }
        }

        public static List<User> getUserList()
        {
            var db = new Database();
            List<User> allUsers = new List<User>();
            foreach (var user in db.users)
            {
                allUsers.Add(user);
            }

            return allUsers;
        }
    }
}
