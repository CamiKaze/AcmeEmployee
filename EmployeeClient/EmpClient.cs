using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            string strResponseValue = string.Empty;
            string email = string.Empty;
            string fullName = string.Empty;
            string msg = string.Empty;
            emailer send = new emailer();
            List<Tuple<string, string, string>> empDet = new List<Tuple<string, string, string>>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode
                        != HttpStatusCode.OK) // Check response code
                    {
                        throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                    }

                    // Process the response stream... (could be JSON, XML, or HTML etc.)
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            { // Read the json object
                                strResponseValue = reader.ReadToEnd();

                                dynamic empList = JsonConvert.DeserializeObject<List<EmployeeDetails>>(strResponseValue);
                                
                                // Condition of when an an email is sent
                                foreach (var emp in empList)
                                {// Check Birth Date and if employmentEndDate is null (They are still employed)
                                    if (emp.dateOfBirth == DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")
                                        && emp.employmentEndDate == null) // "1950-12-30T00:00:00" test value
                                    {
                                        email = emp.name + emp.lastname + "@acme.com;"; // assuming that this is the email format
                                        fullName = emp.name + ' ' + emp.lastname;
                                        msg = "Happy Birthday";
                                        empDet.Add(new Tuple<string, string, string>(fullName, email, msg));
                                    }
                                    // Check employmentStartDate and if employmentEndDate is null (They are employed and have a work anniversary)
                                    if (emp.employmentStartDate == DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")
                                        && emp.employmentEndDate == null)
                                    {
                                        email = emp.name + emp.lastname + "@acme.com;";
                                        fullName = emp.name + ' ' + emp.lastname;
                                        msg = "Happy Anniversary";
                                        empDet.Add(new Tuple<string, string, string>(fullName, email, msg));
                                    }
                                }
                                send.sendEmail(empDet);
                                
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
    }
}
