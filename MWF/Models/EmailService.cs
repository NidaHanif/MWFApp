using System.Net.Mail;
using System.Net;
using System;
using System.Text.RegularExpressions;


namespace MWF.Models
{
    public class EmailService
    {
        public string MyMessage { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AttachementPath { get; set; }


        public EmailService(string _EmailTo)
        {
            MyMessage = "This is a test email sent from C#. Blazor Class";
            // Email details
            FromEmail = "receipt@mumtazwelfare.org";
            ToEmail = _EmailTo;
            Subject = "Test Email from Blazor Class";
            AttachementPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "OutputFiles", "Sample.pdf");
            Body = MyMessage;

            // SMTP Server details


            SmtpClient smtpClient = new SmtpClient();
            SmtpClass smtpClass = new();

            smtpClient.Host = smtpClass.smtpHost;
            smtpClient.Port = smtpClass.smtpPort;
            smtpClient.Credentials = new NetworkCredential(smtpClass.smtpUsername, smtpClass.smtpPassword);
            smtpClient.EnableSsl = true;

        }


        public static bool IsValidEmail(string email)
        {
            // Define a regex pattern for validating an email
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Use Regex.IsMatch to check if the string matches the pattern
            return Regex.IsMatch(email, emailPattern);
        }


        public void SendEmail()
        {
            try
            {
                // Create a new MailMessage object
                MailMessage mail = new MailMessage(FromEmail, ToEmail);

                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                mail.Subject = Subject;
                mail.Body = Body;

                Attachment attachment = new(AttachementPath);
                mail.Attachments.Add(attachment);

                SmtpClass smtpClass = new();

                // Create a new SmtpClient object
                SmtpClient smtpClient = new(smtpClass.smtpHost, smtpClass.smtpPort);

                // Enable SSL and set the credentials
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(smtpClass.smtpUsername, smtpClass.smtpPassword);

                // Send the email
                smtpClient.Send(mail);
                MyMessage = "Email sent successfully.";
            }
            catch (Exception ex)
            {
                MyMessage = "Error sending email: " + ex.Message;
            }
        }
    }

    public class SmtpClass
    {
        // SMTP Server details
        public string smtpHost { get; set; } = "mail.mumtazwelfare.org";  // Replace with your SMTP server
        public int smtpPort { get; set; } = 587;  // Replace with your SMTP port (587 for TLS, 465 for SSL)
        public string smtpUsername { get; set; } = "receipt@mumtazwelfare.org";
        public string smtpPassword { get; set; } = "Mumtaz%786";


    }
}
