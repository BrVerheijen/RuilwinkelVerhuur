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
            string messageBody = "<img src='https://pastepixel.com/image/5a4dnez9FzzCbCwSv52P.png' width='0' height='0'>";
            string testmail = "nathangroenveld3@gmail.com";
            string testsubject = "test123";
            EmailSender(messageBody, testmail, testsubject);
        }

        public static void EmailSender(string htmlString, string toMailAddress, string subject)
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

        public static void FactuurGenerator(List<int> cart, Factuur factuur, User user)
        {


            string messageBody = "<h1>Factuur: " + factuur.ID + "</h1>";
            messageBody = messageBody + "<h2>Datum: " + factuur.Date + "</h2>";
            messageBody = messageBody + "<h4>Naam: " + user.Name + "</h4>";
            messageBody = messageBody + "<h4>GebruikersID: " + user.ID + "</h4> </br> </br>";
            messageBody = messageBody + "<table> <thead> <tr> <th> Naam </th> <th> Afbeelding </th> <th> Categorie </th> <th> Prijs </th> </tr> </thead> <tbody>";


            foreach (var productid in cart)
            {
                foreach (var product in ProductComm.retrieveList().Result)
                {
                    if (product.ID == productid)
                    {
                        string productpicture = "'" + product.Picture + "'";

                        messageBody = messageBody + "<tr> <td>" + product.Name + "</td> <td> <img src =" + productpicture + " height ='150'/> </td> <td>" + product.Category + "</td> <td>" + product.Cost + "</td> </tr>";
                    }
                }
            }

            messageBody = messageBody + "<img src='https://pastepixel.com/image/5a4dnez9FzzCbCwSv52P.png' width='0' height='0'>";

            string title = "Factuur: " + factuur.ID;

            EmailSender(messageBody, user.Email, title);

        }
    }
}
