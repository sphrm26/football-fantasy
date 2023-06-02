using System.ComponentModel.DataAnnotations;

namespace footballFantasy.Model
{
    public class waitingUsers
    {
        [Key]
        public string userName { get; set; }
        public DateTime dt { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string OTP { get; set; }

        public waitingUsers(string password, DateTime dt, string name, string email, string userName, string OTP)
        {
            this.OTP = OTP;
            this.dt = dt;
            this.name = name;
            this.email = email;
            this.userName = userName;
            this.password = password;
        }
        public bool checkExpire()
        {
            TimeSpan timesAfterSending = DateTime.Now - dt;
            if (timesAfterSending.TotalMinutes > 5)
            {
                return true;
            }
            return false;
        }
        public static void checkAllOTPForExpire()
        {
            using (var db = new Database())
            {
                foreach (var item in db.waitingListUsers)
                {
                    if (item.checkExpire())
                    {
                        db.waitingListUsers.Remove(item);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
