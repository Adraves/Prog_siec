using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Xml;

namespace SMTP_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Config data path:");
            string path = Console.ReadLine();
            XmlDocument data = new XmlDocument();
            try
            {
                data.Load(path);
                string rAdress = data.DocumentElement.SelectSingleNode("/main/rAdress").InnerText.ToString();
                string sAdress = data.DocumentElement.SelectSingleNode("/main/sAdress").InnerText.ToString();
                string porttemp = data.DocumentElement.SelectSingleNode("/main/port").InnerText.ToString();
                int port = Convert.ToInt32(porttemp);
                string sender = data.DocumentElement.SelectSingleNode("/main/sender").InnerText.ToString();
                string receiver = data.DocumentElement.SelectSingleNode("/main/receiver").InnerText.ToString();
                string pass = b64(data.DocumentElement.SelectSingleNode("/main/pass").InnerText.ToString());
                string subject;


                SMTP smtp = new SMTP();

                MailMessage mail = new MailMessage();


                Console.WriteLine(smtp.Connect(sAdress, port));
                smtp.send2("EHLO " + rAdress);
                Console.Write(smtp.read_multi_line());

                Console.WriteLine(smtp.send("AUTH LOGIN"));
                Console.WriteLine(smtp.send(b64(sender)));
                Console.WriteLine(smtp.send(pass));

                Console.WriteLine(smtp.send("MAIL FROM <" + sender + ">"));
                Console.WriteLine(smtp.send("RCPT TO <" + receiver + ">"));

                Console.WriteLine(smtp.send("DATA"));
                Console.WriteLine("Mail subject: ");
                subject = Console.ReadLine();
                Console.WriteLine("Mail text:\n");

                string line = string.Empty;
                string body = string.Empty;
                while (line != ".")
                {
                    line = Console.ReadLine();
                    body += line + smtp.CRLF;
                }

                Mail newMail = new Mail(sender, receiver, subject);
                Console.WriteLine(smtp.send(newMail.MailTemplate(body)));
                Console.WriteLine("Success!!!!11111oneoneone");

                Console.WriteLine(smtp.send("QUIT"));
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Nieprawidlowy plik");
                Console.ReadKey();
            }
            

        }
        public static string b64(string text)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
} 
