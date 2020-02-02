using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace EmployeeClient
{
    public partial class emailer
    {
        private static void sendEmail(Tuple<string, string, string> empDet)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("AcmeWellness@Acme.com");
                message.To.Add(new MailAddress(empDet.Item2.ToString())); // email of employee
                message.Subject = "Test";
                message.IsBodyHtml = true;
                message.Body = empDet.Item3;  //the msg and emplyee fullname.  + " " + empDet.Item1
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Send(message);
            }
            catch (Exception) { }
        }

        public void sendEmails(List<Tuple<string, string, string>> empDet)
        {
            empDet.ForEach(sendEmail);
        }
    }
}