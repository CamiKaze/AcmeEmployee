using System.Text.RegularExpressions;

namespace EmployeeClient
{// Single responsibility - The class is responsible for creating an email address only
    public partial class EmailCreator
    {// There are no email addresses in the JSON file.
     // I am creating a valid email address format with this class
        public static string Create(string fname, string lname)
            => Create(fname, lname, "@acme.com");

        public static string Create(string fname, string lname, string domain)
        {// I am replacing all the invalid characters with nothing
            string email = fname.Trim() + lname.Trim() + domain.Trim();
            string emailResult = Regex.Replace(email, @"\s", "");
            return emailResult;
        }
    }
}