using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Net.Mail;


namespace SMTP_console
{
    class SMTP
    {
        
        public TcpClient client;
        public NetworkStream networkStream;
        public StreamReader streamReader;
        
        
        public byte[] data;
        public string CRLF = "\r\n";

        public string Connect(string server, int port)
        {
            client = new TcpClient(server, port);
            client.ReceiveTimeout = 3000;
            try
            {

                networkStream = client.GetStream();
                streamReader = new StreamReader(networkStream);

                
                return (streamReader.ReadLine()+CRLF);
            }
            catch (Exception err)
            {
                return ("Error: " + err.ToString());
            }
        }

        public string send(string message)
        {
            try
            {
                data = Encoding.ASCII.GetBytes(message+CRLF);
                networkStream.Write(data, 0, data.Length);
                return streamReader.ReadLine();
            }
            catch (Exception err)
            {
                return "-ERR " + err.ToString();
            }
        }
        public void send2(string message)
        {
            try
            {
                
                data = Encoding.ASCII.GetBytes(message + CRLF);
                networkStream.Write(data, 0, data.Length);

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
        public string read_multi_line()
        {
            string line = string.Empty;
            string xd = string.Empty;
            try
            {
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    xd += line + CRLF;
                }
                
            }
            catch
            {

            }
            
            return xd;
        }
       /* public string read_multi_line()
        {
            string line = string.Empty;
            string xd = string.Empty;
            while (line!=null)
            {
                
                xd += line + CRLF;
                line = streamReader.ReadLine();
            }
            return xd;
        }*/

        public string USER(string login)
        {
            string temp;
            temp = send("USER " + login);
            return temp + CRLF;
        }
        public string PASS(string pass)
        {
            string temp;
            temp = send("PASS " + pass);
            return temp + CRLF;
        }

    }

    

}
