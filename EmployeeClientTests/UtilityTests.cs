using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeClient.Tests
{
    [TestClass()]
    public class UtilityTests
    {
        [TestMethod()]
        public void IsValidEmailTest()
        {
            string email = string.Empty;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error code: " + ex.Message); //  return false;
            }
            Assert.Fail();
        }
    }
}