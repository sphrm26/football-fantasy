using System.Net.Mail;

namespace footballFantasy.BuisnessLayer
{
    public class OTP
    {
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

        public static string OTPSet(string email)
        {
            Random rnd = new Random();
            int randNum = rnd.Next(100000, 1000000);
            string code = Convert.ToString(randNum);
            sendOTP(email, code);
            return code;
        }
    }
}
