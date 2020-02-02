using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace EmployeeClient.Tests
{
    [TestClass()]
    public class emailerTests
    {
        [TestMethod()]
        public void sendEmailTest()
        {
            string from = "sender@test.com";
            string to = "receiver@test.com";
            MailMessage mail = new MailMessage(from, to);

            mail.Subject = "Unit Test MVC";
            mail.Body = "Unit Test for sending mail in MVC app";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.test.com";
            smtp.EnableSsl = true;
            System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(from, "testpassword");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkCredential;
            smtp.Port = 587;
            smtp.SendAsync(mail, null);

            smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);


          //  Assert.Fail();
        }

        static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

        }
    }
}