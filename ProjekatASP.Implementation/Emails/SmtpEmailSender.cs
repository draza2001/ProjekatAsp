using ProjekatASP.Application.Emails;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProjekatASP.Implementation.Emails
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDTO dto)
        {

            
                string email = dto.SendTo;
                string subject = dto.Subject;
                string message =dto.Content;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dragoljub.ciric2001@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("dragoljub.ciric2001@gmail.com", "jjxlwhfgzznqtjpx");

                try
                {
                    smtpClient.Send(mail);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while sending the email: " + ex.Message);
               }
            
        }
    }
}

