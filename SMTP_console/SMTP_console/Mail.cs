using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTP_console
{
    class Mail
    {
        string sender;
        string receiver;
        string subject;

        public Mail(string sender, string receiver, string subject)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.subject = subject;
        }

        public string MailTemplate(string body)
        {
            string mail;
            
            mail = String.Format("From: {0} \r\nTo: {1} \r\nSubject: {2} \r\n\r\n{3}",sender,receiver,subject,body);
            return mail;
        }


    }
}
