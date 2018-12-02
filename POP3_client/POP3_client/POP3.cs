using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace POP3_client
{
    class POP3
    {
        public enum connectState
        {
            disconnect,
            AUTHORISATION,
            TRANSACTION,
            UPDATE
        }
        public connectState state = connectState.disconnect;

        public TcpClient client;
        public NetworkStream networkStream;
        public StreamReader streamReader;
        
        
        public byte[] data;
        public string CRLF = "\r\n";
        

        public string Connect(string server, string login, string pass, int port)
        {
            string s;
            string mes = string.Empty;
            client = new TcpClient(server, port);
            client.ReceiveTimeout = 5000;
            try
            {
                
                networkStream = client.GetStream();
                streamReader = new StreamReader(networkStream);

                state = connectState.AUTHORISATION;

                mes += streamReader.ReadLine()+CRLF;
                s = send("USER " + login);
                mes += s + " login ok" + CRLF;
                
                s = send("PASS " + pass);
                mes += s + " pasy ok" + CRLF;

                s = send("STAT");
                mes += s + CRLF;

                state = connectState.TRANSACTION;

                return mes;

            }
            catch(Exception err)
            {
                return ("Error: " + err.ToString());
            }
            
        }

        public string send (string message)
        {
            try
            {
                data = Encoding.ASCII.GetBytes(message + CRLF);
                networkStream.Write(data, 0, data.Length);
                return streamReader.ReadLine();
            }
            catch (Exception err)
            {
                return "-ERR " + err.ToString();
            }
        }
        public string send2(string message)
        {
            try
            {
                string temp = string.Empty;
                string temp2 = string.Empty;
                data = Encoding.ASCII.GetBytes(message + CRLF);
                networkStream.Write(data, 0, data.Length);
                while(temp2!=".")
                {
                    temp += temp2 + CRLF;
                    temp2 = streamReader.ReadLine();
                }
                temp += "." + CRLF;
                return temp;
            }
            catch (Exception err)
            {
                return "-ERR " + err.ToString();
            }
        }



        public string QUIT()
        {
            send("QUIT" + CRLF);
            string temp = string.Empty;
            temp += streamReader.ReadLine();
            networkStream.Close();
            streamReader.Close();

            return temp;
        }
        public string STAT()
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                send("STAT");
                temp = streamReader.ReadLine();
            }
            return temp;
        }
        public string LIST()
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                send("LIST" + CRLF);
                temp = streamReader.ReadToEnd();
            }
            return temp;
        }
        public string LIST(string number)
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                send("LIST " + number +  CRLF);
                temp = streamReader.ReadLine();
            }
            return temp;
        }
        public string RETR(string number)
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                temp = send2("RETR " + number);
                
            }
            return temp;
        }
        public string DELE(string number)
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                send("DELE " + number + CRLF);
                temp = streamReader.ReadLine();
            }
            return temp;
        }
        public string NOOP()
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                send("NOOP" + CRLF);
                temp = streamReader.ReadLine();
            }
            return temp;
        }
        public string RSET()
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                send("RSET" + CRLF);
                temp = streamReader.ReadLine();
            }
            return temp;
        }
        public string UIDL()
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION state";
            }
            else
            {
                temp = send2("UIDL");
                
            }
            return temp;
        }
        public List<string> mailList(string message)
        {
            List<string> mailID = new List<string>();

            string temp = string.Empty;
            string temp2 = string.Empty;
            data = Encoding.ASCII.GetBytes(message + CRLF);
            networkStream.Write(data, 0, data.Length);
            while (temp2 != ".")
            {
                temp += temp2 + CRLF;
                temp2 = streamReader.ReadLine();
                if (temp2!="+OK"&& temp2 !=".")
                {
                    string[] temp3 = temp2.Split(' ').ToArray();
                    mailID.Add(temp3[1]);
                }
                
            }
            //temp += "." + CRLF;

            return mailID;
        }
    }

    

}
