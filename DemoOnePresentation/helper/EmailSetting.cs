using DAL.Models;
using System.Net;
using System.Net.Mail;

namespace DemoOnePresentation.helper
{
    public static class EmailSetting
    {
        public static void SendEmail(Email email)
        {
            var clent = new SmtpClient("smtp.gmail.com", 587);
            clent.EnableSsl = true; // encrypted mail
            clent.Credentials = new NetworkCredential("aa9900743@gmail.com", "ynnxggfxlwewrueg");
            clent.Send("muhammadalaa776@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
