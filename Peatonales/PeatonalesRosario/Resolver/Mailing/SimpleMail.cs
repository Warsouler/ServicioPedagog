#region Usings

using System;
using System.Configuration;
using sec = GO.Fwk.Toolkits.Cryptography;
using GO.Fwk.Toolkits;
using System.Net.Mail;
using System.Linq;

#endregion

namespace GO.Fwk.Toolkits.Mailing
{
    public class SimpleMail : IMail
    {
        public void SendMail(IStateMail modelData)
        {
            String account = MailConfiguration.GetInstance().AppSettings["mail_account"];
            String password = sec.Base64Encryption.GetInstance().Decrypt(MailConfiguration.GetInstance().AppSettings["mail_password"]);
            String sender = MailConfiguration.GetInstance().AppSettings["mail_sender"];

            MailMessage mail = new MailMessage();

            modelData.To().ToList().ForEach(mailAdress => mail.To.Add(mailAdress));

            mail.Body = modelData.Body();
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.Subject = modelData.Subject();
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            mail.From = new MailAddress(account);
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = MailConfiguration.GetInstance().AppSettings["mail_host"];
            smtp.Port = Convert.ToInt32(MailConfiguration.GetInstance().AppSettings["mail_port"]);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(account, password);// Enter seders User name and password

            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
    }
}
