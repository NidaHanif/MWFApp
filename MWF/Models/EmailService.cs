using System.Net.Mail;
using System.Net;
using System;

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

        private SmtpService smtpService;

        public EmailService()
        {
            MyMessage = "This is a test email sent from C#. Blazor Class";

            // Email details
            FromEmail = "receipt@mumtazwelfare.org";
            ToEmail = "aamirjk1968@gmail.com";
            Subject = "Test Email from Blazor Class";
            AttachementPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "OutputFiles", "Sample.pdf");
            Body = MyMessage;

            // SMTP Server details

            smtpService = new SmtpService();
           
        }

        public void SendEmail2()
        {
            var smtpClient = new SmtpClient("mail.mumtazwelfare.org")
            {
                Port = 465, // or 465, depending on your provider
                Credentials = new NetworkCredential("receipt@mumtazwelfare.org", "Mumtaz%786"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("receipt@mumtazwelfare.org"),
                Subject = "Test Email",
                Body = "This is a test email.",
                IsBodyHtml = true,
            };
            mailMessage.To.Add("aamirjk1968@gmail.com");

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                // Log or handle the exception
                Console.WriteLine(ex.Message);
            }
        }



        public void SendEmail()
        {
            try
            {
                // Create a new MailMessage object
                MailMessage mail = new MailMessage(FromEmail, ToEmail);
                mail.Subject = Subject;
                mail.Body = Body;

                //Attachment attachment = new Attachment(AttachementPath);
                //mail.Attachments.Add(attachment);


                // Create a new SmtpClient object
                SmtpClient smtpClient = new SmtpClient(smtpService.smtpHost, smtpService.smtpPort);

                // Enable SSL and set the credentials
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(smtpService.smtpUsername, smtpService.smtpPassword);
                
                // Send the email
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }


    }

    public class SmtpService
    {
        // SMTP Server details
        public string smtpHost { get; set; } = "smtp.mumtazwelfare.org";  // Replace with your SMTP server
        public int smtpPort { get; set; } = 465;  // Replace with your SMTP port (587 for TLS, 465 for SSL)
        public string smtpUsername { get; set; } = "receipt@mumtazwelfare.org";
        public string smtpPassword { get; set; } = "Mumtaz%786";


    }
}
