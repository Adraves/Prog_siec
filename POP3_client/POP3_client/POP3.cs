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

        public string Connect(string server, int port)
        {
            client = new TcpClient(server, port);
            client.ReceiveTimeout = 5000;
            try
            {

                networkStream = client.GetStream();
                streamReader = new StreamReader(networkStream);

                state = connectState.AUTHORISATION;

                return (streamReader.ReadLine()+CRLF);
            }
            catch (Exception err)
            {
                return ("Error: " + err.ToString());
            }
        }

        public string USER(string login)
        {
            string temp;
            if(state!=connectState.AUTHORISATION)
            {
                temp = "Not in AUTHENTICATION";
            }
            else
            {
                temp = send("USER " + login);
            }
            return temp+CRLF;
        }
        public string PASS(string pass)
        {
            string temp;
            if (state != connectState.AUTHORISATION)
            {
                temp = "Not in AUTHENTICATION";
            }
            
            else
            {
                temp = send("PASS " + pass);
                if (temp.StartsWith("+"))
                {
                    state = connectState.TRANSACTION;
                }
                else temp = "Error during PASS command";
            }
            return temp + CRLF;
        }
        public string STAT()
        {
            string temp;
            if (state != connectState.TRANSACTION)
            {
                temp = "Not in TRANSACTION";
            }
            else
            {
                temp = send("STAT");
            }
            return temp + CRLF;
        }

        

        public string send(string message)
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
            string temp;
 
            temp = send("QUIT" + CRLF);
            if (state == connectState.TRANSACTION)
            {
                state = connectState.UPDATE;
            }
            else if (state == connectState.AUTHORISATION)
            {
                state = connectState.disconnect;
            }
            networkStream.Close();
            streamReader.Close();
            
            

            return temp + CRLF;
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
