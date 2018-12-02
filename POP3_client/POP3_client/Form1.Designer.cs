namespace POP3_client
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.Mails = new System.Windows.Forms.RichTextBox();
            this.CommandWindow = new System.Windows.Forms.RichTextBox();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.textBoxMsgNr = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonMsgShow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDisconnect);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonConnect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxPass);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.textBoxAdress);
            this.panel1.Controls.Add(this.buttonConfig);
            this.panel1.Location = new System.Drawing.Point(551, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 165);
            this.panel1.TabIndex = 0;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(111, 138);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(90, 23);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(3, 138);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(90, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Adress";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(75, 80);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.ReadOnly = true;
            this.textBoxPass.Size = new System.Drawing.Size(126, 20);
            this.textBoxPass.TabIndex = 3;
            this.textBoxPass.UseSystemPasswordChar = true;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(75, 50);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(126, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(75, 20);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.ReadOnly = true;
            this.textBoxAdress.Size = new System.Drawing.Size(126, 20);
            this.textBoxAdress.TabIndex = 1;
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(56, 110);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(145, 25);
            this.buttonConfig.TabIndex = 0;
            this.buttonConfig.Text = "Select config file";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // Mails
            // 
            this.Mails.BackColor = System.Drawing.SystemColors.Window;
            this.Mails.Location = new System.Drawing.Point(12, 12);
            this.Mails.Name = "Mails";
            this.Mails.ReadOnly = true;
            this.Mails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Mails.Size = new System.Drawing.Size(520, 200);
            this.Mails.TabIndex = 1;
            this.Mails.Text = "";
            // 
            // CommandWindow
            // 
            this.CommandWindow.BackColor = System.Drawing.SystemColors.Window;
            this.CommandWindow.Location = new System.Drawing.Point(12, 218);
            this.CommandWindow.Name = "CommandWindow";
            this.CommandWindow.ReadOnly = true;
            this.CommandWindow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.CommandWindow.Size = new System.Drawing.Size(520, 100);
            this.CommandWindow.TabIndex = 2;
            this.CommandWindow.Text = "";
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.Location = new System.Drawing.Point(13, 325);
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.Size = new System.Drawing.Size(519, 20);
            this.textBoxCmd.TabIndex = 3;
            // 
            // textBoxMsgNr
            // 
            this.textBoxMsgNr.Location = new System.Drawing.Point(538, 218);
            this.textBoxMsgNr.Name = "textBoxMsgNr";
            this.textBoxMsgNr.Size = new System.Drawing.Size(20, 20);
            this.textBoxMsgNr.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonMsgShow
            // 
            this.buttonMsgShow.Location = new System.Drawing.Point(564, 216);
            this.buttonMsgShow.Name = "buttonMsgShow";
            this.buttonMsgShow.Size = new System.Drawing.Size(92, 23);
            this.buttonMsgShow.TabIndex = 6;
            this.buttonMsgShow.Text = "Show message!";
            this.buttonMsgShow.UseVisualStyleBackColor = true;
            this.buttonMsgShow.Click += new System.EventHandler(this.buttonMsgShow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 450);
            this.Controls.Add(this.buttonMsgShow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxMsgNr);
            this.Controls.Add(this.textBoxCmd);
            this.Controls.Add(this.CommandWindow);
            this.Controls.Add(this.Mails);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.RichTextBox Mails;
        private System.Windows.Forms.RichTextBox CommandWindow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxCmd;
        private System.Windows.Forms.TextBox textBoxMsgNr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonMsgShow;
    }
}

