using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace POP3_client
{
    public partial class Form1 : Form
    {
        
        string fileName = string.Empty;
        POP3 login = new POP3();
        ReadConfig readConfig = new ReadConfig();
        configData configData = new configData();
        List<string> uniqueMails = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.Title = "Choose config file";
            fileDialog1.Filter = "Select .config file|*.config";
            if (fileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = fileDialog1.FileName;
                var data = readConfig.read(fileName);
                configData.server = data.server;
                configData.login = data.login;
                configData.pass = data.pass;
                configData.port = data.port;
                configData.refreshRate = data.refreshRate;

                textBoxAdress.Text = configData.server;
                textBoxName.Text = configData.login;
                textBoxPass.Text = configData.pass;
            }
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            buttonConfig.Enabled = true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            CommandWindow.Text += login.Connect(configData.server, configData.port);
            CommandWindow.Text += login.USER(configData.login);
            CommandWindow.Text += login.PASS(configData.pass);
            timer1.Interval = configData.refreshRate*1000;
            if (login.state == POP3.connectState.TRANSACTION)
            {
                timer1.Start();

                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                buttonConfig.Enabled = false;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            
            timer1.Stop();
            CommandWindow.Text += login.QUIT();
            CommandWindow.Text += "Received mails total: " + uniqueMails.Count;
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            buttonConfig.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            CommandWindow.Text += login.send(textBoxCmd.Text);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
             List<string> mailsReceived = login.mailList("UIDL");
             int newMails = 0;
             foreach (string mail in mailsReceived)
             {
                 if (!uniqueMails.Contains(mail))
                 {
                     
                     uniqueMails.Add(mail);
                    newMails++;
                }
             }
             if (newMails>0)
                CommandWindow.Text += "New mails: " + newMails + "\n";
        }

        private void buttonMsgShow_Click(object sender, EventArgs e)
        {
            Mails.Text = string.Empty;
            Mails.Text += login.RETR(textBoxMsgNr.Text);
        }
    }
}
