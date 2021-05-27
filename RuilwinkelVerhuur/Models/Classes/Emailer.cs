using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class Emailer
    {

        public static void MailGenerateTest()
        {
            string messageBody = "<img src='https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Rotating_earth_%28large%29.gif/200px-Rotating_earth_%28large%29.gif' width='0' height='0'>";
            string testmail = "testmail";
            string testsubject = "test123";
            Email(messageBody, testmail, testsubject);
        }

        public static void Email(string htmlString, string toMailAddress, string subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("FromMailAddress");
                message.To.Add(new MailAddress(toMailAddress));
                message.Subject = subject;
                message.IsBodyHtml = true;   
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.mailserver.com"; //insert mail server   
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
