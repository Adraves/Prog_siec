using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace FTP_wf
{
    class FTP
    {
        public TcpClient client;
        public NetworkStream networkStream;
        public StreamReader streamReader;
        public byte[] data;

        public TcpClient passiveClient;
        public NetworkStream passiveNetwork;
        public StreamReader passiveReader;
        public byte[] passiveData;

        public string CRLF = "\r\n";

        public string Connect(string server, int port)
        {
            string response = string.Empty;
            client = new TcpClient(server, port);
            client.ReceiveTimeout = 5000;
            
            try
            {
                networkStream = client.GetStream();
                streamReader = new StreamReader(networkStream);
                response += streamReader.ReadLine()+CRLF;

                return response;

            }
            catch (Exception err)
            {
                return ("Error: " + err.ToString());
            }
        }

        public string PassiveConnect(string server)
        {

            string response = string.Empty;
            string[] separatedValues;
            int p1 = 0;
            int p2 = 0;
            int passivePort = 0;
            try
            {
                response += GetSingleResponse("PASV");

                separatedValues = response.Split(",".ToCharArray());

                p1 = Convert.ToInt16(separatedValues[4]) * 256;
                separatedValues[5] = separatedValues[5].Substring(0, separatedValues[5].IndexOf(")"));

                p2 = Convert.ToInt16(separatedValues[5]);

                passivePort = p2 + p1;

                passiveClient = new TcpClient(server, passivePort);
                passiveClient.ReceiveTimeout = 5000;
                passiveNetwork = passiveClient.GetStream();
                passiveReader = new StreamReader(passiveNetwork);
                return response;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public string GetSingleResponse(string message)
        {
            try
            {
                data = Encoding.ASCII.GetBytes(message + CRLF);
                networkStream.Write(data, 0, data.Length);
                
                return streamReader.ReadLine()+CRLF;
            }
            catch (Exception err)
            {
                return err.ToString();
            }
        }

        public string GetMultipleResponces(string message)
        {
            try
            {
                string response = string.Empty;
                string responces = string.Empty;
                data = Encoding.ASCII.GetBytes(message + CRLF);
                networkStream.Write(data, 0, data.Length);
                do
                {
                    response = streamReader.ReadLine();
                    responces += response + CRLF;

                } while (response.Substring(0, 1) != "2");

                return responces; 
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public List<string> receivePassiveResponces()
        {
            string responce = string.Empty;
            List<string> passiveResponces = new List<string>();
            while (true)
            {
                responce = passiveReader.ReadLine();
                if (responce == null) break;
                passiveResponces.Add(responce);
            }
            return passiveResponces;

        }
        public string User(string login)
        {
            string temp;
            temp = GetSingleResponse("USER " + login);
            return temp;
        }
        public string Pass(string pass)
        {
            string temp;
            temp = GetSingleResponse("PASS " + pass);
            return temp;
        }
        public string Disconnect()
        {
            return GetSingleResponse("QUIT");
        }
        public string PrintWorkingDirectory()
        {
            
            return GetSingleResponse("PWD").Substring(4).Replace("\"",string.Empty);
        }


    }
}
