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
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 465,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("aspdragoljubproject@gmail.com", "Password123!")
            };
            var message = new MailMessage("aspdragoljubproject@gmail.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}

