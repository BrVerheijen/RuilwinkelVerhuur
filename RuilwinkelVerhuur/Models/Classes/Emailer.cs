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
            string messageBody = "<img src='https://pastepixel.com/image/DMpwPqhCeM4Un9BY6efD.png' width='0' height='0'>";
            string testmail = "nathangroenveld3@gmail.com";
            string testsubject = "test123";
            Email(messageBody, testmail, testsubject);
        }

        public static void Email(string htmlString, string toMailAddress, string subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ruilwinkelverhuur@mail.com");
                message.To.Add(new MailAddress(toMailAddress));
                message.Subject = subject;
                message.IsBodyHtml = true;   
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.mail.com"; //insert mail server   
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ruilwinkelverhuur@mail.com", "Sleutel123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
