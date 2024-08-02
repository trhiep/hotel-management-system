using System.Net.Mail;
using System.Net;

namespace HotelManagementSystem.Utils
{
    public class EmailSender
    {
        string SenderMail = "hieptvhe173252@gmail.com";
        string SenderPassword = "xrub dxja ykrc nwuk";

        public System.Threading.Tasks.Task SendEmail(string email, string subject, string body, bool isBodyHtml)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(SenderMail, SenderPassword)
            };
            var senderAddress = new MailAddress(SenderMail, "Hotel Management System");
            var mailMessage = new MailMessage
            {
                From = senderAddress,
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            return client.SendMailAsync(mailMessage);
        }

        public static void SendEmailMultiThread(string code, string email)
        {
            EmailSender sender = new EmailSender();
            sender.SendEmail(email, "Reset password OTP", "Here is your reset password OTP: " + code, true).Wait();
        }

    }
}
