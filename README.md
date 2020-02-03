# AcmeEmployee
# OVERVIEW

A requirement exists at acme to develop a service component that will send birthday wishes to employees.

# Technologies used
.NET 4.7.2

C#

WPF (Windows Presentation Foundation)

SOLID Principles

Functional Programming

Declarative Programming

# API Server to use
https://eohmc-acme-api.azurewebsites.net/api/Employees

# Approach

I created a Windows Presentation Form with a text box (populated with a URI) and a multiline textbox to display that JSON data from the resource. The JSON data will be displayed after the user clicks on the "Get" button.

The application makes a "GET" request where I get all the records from the JSON resource. I use the information that was retrieved and check if an employee is celebrating an occassion (Birthday or Work Anniversay) based on birth date, and when they were first employed at Acme. The application takes the end of employment date into account as well so that an email is not sent to employees that are not in the employment of Acme anymore. 

If an employee is celebrating, I create a message tailored to the occassion.
"Happy Birthday Bill Gates"
"Happy Anniversary Bill Gates"

Taking into account that sending an email to an employee is a requirement, email addresses is not supplied in the content of the endpoint - therefore, I create an email address based on an employees first name and last name. The email is run through a regular expression to ensure that the created email address conforms to a valid email address format.

Given that I now have the full name, tailored message and email address of an employee, I supply this information to an emailer class using a Tuple. The necessary fields in the email is populated respectively and an email is sent off.

It is important to note that when the application runs, there is no data in the JSON content that matches any date in the current year of 2020.

It is noted that that data extracted from the endpoint does not contain any data related to the current year (2020).

I have added a test case to test the email class.
