using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Emails
{
   public interface IEmailSender
    {
        void Send(SendEmailDTO dto);
    }
    public class SendEmailDTO
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
