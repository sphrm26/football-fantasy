using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace footballFantasy
{
    public class Database : DbContext
    {
        public DbSet<waitingUsers> waitingListUsers { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlite("Data source=database.db");
        }
    }

    public class waitingUsers
    {
        [Key]
        public string userName { get; set; }
        public DateTime dt { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string OTP { get; set; }

        public waitingUsers(string userNmae, DateTime dt, string name, string email, string username, string OTP)
        {
            this.userName = userNmae;
            this.dt = dt;
            this.name = name;
            this.email = email;
            this.userName = username;
            this.password = password;
        }
        public bool checkExpire()
        {
            TimeSpan timesAfterSending = DateTime.Now - this.dt;
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

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public static void validationEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("please enter your email");
            }
            string pattern = @"[0-9a-ZA-z]{1}[0-9a-zA-Z\.]{5,29}[0-9a-ZA-z]{1}@{1}[0-9a-zA-Z]+\.[a-zA-z]{2,}$";
            if (!(Regex.IsMatch(email, pattern)))
            {
                throw new Exception("please enter a correct email address.");
            }
        }
        public static void validationName(string name)
        {
            if (name == null)
            {
                throw new Exception("please enter your name");
            }
            Regex regex = new Regex("^(?=.*[a-z])(?=.*\\d).+$");
            if (!Regex.IsMatch(name, "\\d"))
            {
                throw new Exception("No number found.");
            }
            else if (!Regex.IsMatch(name, "[a-z]"))
            {
                throw new Exception("No letter found.");
            }
            if (name.Length >= 30 && name.Length <= 5)
            {
                throw new Exception("your name length must be in range 5 to 30");
            }
        }
        public static void sendOTP(string email, string code)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("mysmtp2sphrm26@gmail.com");
                mail.To.Add(email);
                mail.Subject = "football fantasy one time password";
                mail.Body = $"hello\nthis is your one time password\n{code}\nnow you can signUp in football fantasy game\nhave a nice time";

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("mysmtp2sphrm26@gmail.com", "puajdydqkvctpxrj");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}