namespace AnantMatrimony.FORMS
{
    partial class frmEmailSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEmailSettingId = new System.Windows.Forms.TextBox();
            this.txtCCEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsDefault = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtEmailSettingId);
            this.panel1.Controls.Add(this.txtCCEmail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chkIsDefault);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSmtpServer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFromEmail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 189);
            this.panel1.TabIndex = 0;
            // 
            // txtEmailSettingId
            // 
            this.txtEmailSettingId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailSettingId.Location = new System.Drawing.Point(274, 157);
            this.txtEmailSettingId.Name = "txtEmailSettingId";
            this.txtEmailSettingId.Size = new System.Drawing.Size(44, 22);
            this.txtEmailSettingId.TabIndex = 12;
            // 
            // txtCCEmail
            // 
            this.txtCCEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCEmail.Location = new System.Drawing.Point(112, 48);
            this.txtCCEmail.Name = "txtCCEmail";
            this.txtCCEmail.Size = new System.Drawing.Size(206, 22);
            this.txtCCEmail.TabIndex = 11;
            this.txtCCEmail.Tag = "CCEMail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "CC Email :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Location = new System.Drawing.Point(112, 161);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(71, 18);
            this.chkIsDefault.TabIndex = 9;
            this.chkIsDefault.Tag = "*IsDefault";
            this.chkIsDefault.Text = "Default";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(112, 127);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(206, 22);
            this.txtPort.TabIndex = 8;
            this.txtPort.Tag = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "PORT :";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSmtpServer.Location = new System.Drawing.Point(112, 100);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(206, 22);
            this.txtSmtpServer.TabIndex = 6;
            this.txtSmtpServer.Tag = "SMTPServer";
            this.txtSmtpServer.TextChanged += new System.EventHandler(this.txtSmtpServer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "SMPT Server :";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(112, 74);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(206, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Tag = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password :";
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromEmail.Location = new System.Drawing.Point(112, 23);
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(206, 22);
            this.txtFromEmail.TabIndex = 2;
            this.txtFromEmail.Tag = "FromEmail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Email :";
            // 
            // frmEmailSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 202);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmEmailSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Email Setting";
            this.Activated += new System.EventHandler(this.frmEmailSetting_Activated);
            this.Deactivate += new System.EventHandler(this.frmEmailSetting_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmailSetting_FormClosed);
            this.Load += new System.EventHandler(this.frmEmailSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsDefault;
        private System.Windows.Forms.TextBox txtCCEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmailSettingId;
    }
}