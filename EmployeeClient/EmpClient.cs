using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeClient
{
    partial class EmpClient
    {
        public string endPoint { get; set; } // Holds the URI
        public httpVerb httpMethod { get; set; }

        public EmpClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            emailer send = new emailer();

            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode
                        != HttpStatusCode.OK)
                    { // Check response code
                        throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                    }
                    
                    using (Stream responseStream = response.GetResponseStream())
                    {// Process the response stream... (could be JSON, XML, or HTML etc.)
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            { // Read the json object
                                strResponseValue = reader.ReadToEnd();

                                List<EmployeeDetails> employees =
                                    JsonConvert.DeserializeObject<List<EmployeeDetails>>(strResponseValue);

                                List<Tuple<string, string, string>> empDet =
                                    employees
                                      .Where(isEmployeeOccassion)
                                      .Select(getEmailDetails).ToList();

                                send.sendEmails(empDet);

                                //here(isEmployeeOccassion)
                                //elect(getEmailDetails);

                                /*
                                 
                                 
                                foreach (var emp in empList)
                                {// Birth Date && employmentEndDate is null = They are still employed
                                    if (emp.dateOfBirth == "1955-10-28T00:00:00" // DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")
                                        && emp.employmentEndDate == null)
                                    {
                                        //email = emp.name + emp.lastname + "@acme.com"; // assuming that this is the email format
                                        email = EmailCreator.Create(emp.name, emp.lastname);
                                        fullName = emp.name + ' ' + emp.lastname;
                                        msg = "Happy Birthday";
                                        empDet.Add(new Tuple<string, string, string>(fullName, email, msg));
                                    }
                                    // employmentStartDate && employmentEndDate is null = They are employed and have a work anniversary
                                    if (emp.employmentStartDate == DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")
                                        && emp.employmentEndDate == null)
                                    {
                                        //email = emp.name + emp.lastname + "@acme.com";
                                        email = EmailCreator.Create(emp.name, emp.lastname);
                                        fullName = emp.name + ' ' + emp.lastname;
                                        msg = "Happy Anniversary";
                                        empDet.Add(new Tuple<string, string, string>(fullName, email, msg));
                                    }
                                }*/

                            } // End of StreamReader
                        }
                    } // End of using ResponseStream
                } // End of using response
            }
            catch (Exception ex)
            {
                strResponseValue = ex.Message;
            }
            return strResponseValue;
        }

        private Tuple<string, string, string> getEmailDetails(EmployeeDetails emp)
        {
            string email = EmailCreator.Create(emp.name, emp.lastname);
            string fullName = emp.name + ' ' + emp.lastname;
            string msg = OccassionMessageCreate(emp);
            Tuple<string, string, string> emailDet = new Tuple<string, string, string>(fullName, email, msg);
            return emailDet;
        }

        private bool isEmployeeOccassion(EmployeeDetails employee)
        {
            if (employee.employmentEndDate != null) 
            {
                return false;
            }

            string monthDay = DateTime.Now.ToString("MM'-'dd");
            string empBirthday = employee.dateOfBirth.Substring(5, 5);
            string empAnniversary = employee.employmentStartDate.Substring(5, 5);

            return empBirthday.Contains(monthDay) || empAnniversary.Contains(monthDay);
        }

        public string OccassionMessageCreate(EmployeeDetails employee) 
        {
            string monthDay = DateTime.Now.ToString("MM'-'dd");
            string empBirthday = employee.dateOfBirth.Substring(5, 5);
            string fullname = employee.name + " " + employee.lastname;

            if (empBirthday.Contains(monthDay)) 
            {
                return "Happy Birthday " + fullname; 
            }
            else 
            {
                return "Happy Anniversary " + fullname;
            }
        }
    }
}