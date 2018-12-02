using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


namespace POP3_client
{
    class ReadConfig
    {
        public configData read(string filePath)
        {
            var data = new configData();
           
            XmlDocument config = new XmlDocument();
            config.Load(filePath);

            data.server = config.DocumentElement.SelectSingleNode("//configuration/server").InnerText;
            data.login = config.DocumentElement.SelectSingleNode("//configuration/user").InnerText;
            data.pass = config.DocumentElement.SelectSingleNode("//configuration/pass").InnerText;
            data.port = Convert.ToInt32(config.DocumentElement.SelectSingleNode("//configuration/port").InnerText);
            data.refreshRate = Convert.ToInt32(config.DocumentElement.SelectSingleNode("//configuration/refreshRate").InnerText);

            return data;
        }

    }
    struct configData
    {
        public string server;
        public string login;
        public string pass;
        public int port;
        public int refreshRate;

    }

}
