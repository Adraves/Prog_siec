using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_wf
{
    public partial class Form1 : Form
    {
        FTP ftp = new FTP();
        List<string> files = new List<string>();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            textBoxLog.Text += ftp.Connect(textBoxHost.Text, int.Parse(textBoxPort.Text));
            textBoxLog.Text += ftp.User(textBoxUser.Text);
            textBoxLog.Text += ftp.Pass(textBoxPassword.Text);
            PrintFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = ftp.GetSingleResponse("CWD " + textBoxPathToWrite.Text);
            textBoxLog.Text += response;

            if (response.Substring(0, 1) == "2")
            {
                PrintFiles();
                textBoxPath.Text = textBoxPathToWrite.Text;
            }

        }

        private void listBoxFiles_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem!=null)
            {
                string response = ftp.GetSingleResponse("CWD " + listBoxFiles.SelectedItem);
                textBoxLog.Text += response;
                textBoxPath.Text = ftp.PrintWorkingDirectory();
                textBoxPathToWrite.Text = textBoxPath.Text;
                if (response.Substring(0, 1) == "2")
                {
                    PrintFiles();
                    
                }
            }
        }

        private void PrintFiles()
        {

            textBoxLog.Text += ftp.PassiveConnect(textBoxHost.Text);
            textBoxLog.Text += ftp.GetMultipleResponces("NLST");
            files = ftp.receivePassiveResponces();
            listBoxFiles.Items.Clear();
            listBoxFiles.BeginUpdate();
            foreach (string file in files)
            {
                listBoxFiles.Items.Add(file);
            }
            listBoxFiles.EndUpdate();
        }

        private void buttonParentDir_Click(object sender, EventArgs e)
        {
            string response = ftp.GetSingleResponse("CDUP");
            textBoxLog.Text += response;

            if (response.Substring(0, 1) == "2")
            {
                PrintFiles();
                textBoxPath.Text = ftp.PrintWorkingDirectory();
                textBoxPathToWrite.Text = textBoxPath.Text;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            textBoxLog.Text += ftp.Disconnect();
            listBoxFiles.Items.Clear();
            textBoxPath.Clear();
        }

        private void textBoxLog_TextChanged(object sender, EventArgs e)
        {
            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.ScrollToCaret();
        }
    }
}
