using System.Net.Mail;
using System.Net;
using System;

namespace MWF.Models
{
    public class EmailService
    {
        public string MyMessage { get; set; } 
        public string fromEmail { get; set; } 
        public string toEmail { get; set; } 
        public string subject { get; set; } 
        public string body { get; set; } 

       


        public EmailService()
        {
            // Email details
            string fromEmail = "your-email@example.com";
            string toEmail = "recipient-email@example.com";
            string subject = "Test Email";
            string body = "This is a test email sent from C#.";

            // SMTP Server details
            string smtpHost = "smtp.example.com";  // Replace with your SMTP server
            int smtpPort = 587;  // Replace with your SMTP port (587 for TLS, 465 for SSL)
            string smtpUsername = "your-email@example.com";
            string smtpPassword = "your-email-password";


        }


    }

    public class SmtpService
    {
        // SMTP Server details
        public string smtpHost { get; set; } = "smtp.mumtazwelfare.org";  // Replace with your SMTP server
        public int smtpPort { get; set; } = 587;  // Replace with your SMTP port (587 for TLS, 465 for SSL)
        public string smtpUsername { get; set; } = "receipt@mumtazwelfare.org";
        public string smtpPassword { get; set; } = "Mumtaz%786";


    }
}




