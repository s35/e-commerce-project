using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace BooksForAll
{
    public class EmailSender
    {
        public static void SendMail(string customerEmail, string subject, string body)
        {
            using (MailMessage email = new MailMessage())
            {
                email.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                email.Subject = subject;
                email.Body = body;
                email.IsBodyHtml = true;
                email.To.Add(new MailAddress(customerEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential networkCred = new System.Net.NetworkCredential();
                networkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                networkCred.Password = ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(email);
            }
        }

    }
}