using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClient
{
    public partial class emailer
    {
        public void sendEmail(List<Tuple<string, string, string>> empDet)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("send@gmail.com"); // AcmeWellness@Acme.com
                message.To.Add(new MailAddress("receive@gmail.com")); //(empDet[2].ToString())); // email of employee
                message.Subject = "Test";
                message.IsBodyHtml = true; //body has html format
                message.Body = "birthday/anniversary";  //empDet[3] + " " + empDet[1]; the msg and emplyee fullname. The json does not contain anything happening today
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
    }
}
