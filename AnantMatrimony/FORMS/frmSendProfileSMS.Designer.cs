namespace AnantMatrimony.FORMS
{
    partial class frmSendProfileSMS
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label106 = new System.Windows.Forms.Label();
            this.ddlPAgeTo = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.ddlPAgeFrom = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdbtnFemale = new System.Windows.Forms.RadioButton();
            this.rdbtnMale = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LvwCaste = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LvwMaritalStatus = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LvwState = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LvwCountry = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LvwEducation = new System.Windows.Forms.ListView();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LvwDetails = new System.Windows.Forms.ListView();
            this.btnSearch_A = new System.Windows.Forms.Button();
            this.lblTotalCnt_A = new System.Windows.Forms.Label();
            this.lblTotalCnt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlTemplate = new System.Windows.Forms.ComboBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCovert = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label106);
            this.groupBox7.Controls.Add(this.ddlPAgeTo);
            this.groupBox7.Controls.Add(this.label105);
            this.groupBox7.Controls.Add(this.ddlPAgeFrom);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox7.Location = new System.Drawing.Point(155, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(238, 68);
            this.groupBox7.TabIndex = 322;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Year";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(6, 18);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(83, 14);
            this.label106.TabIndex = 309;
            this.label106.Text = "Born Year :";
            // 
            // ddlPAgeTo
            // 
            this.ddlPAgeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPAgeTo.FormattingEnabled = true;
            this.ddlPAgeTo.Location = new System.Drawing.Point(137, 35);
            this.ddlPAgeTo.Name = "ddlPAgeTo";
            this.ddlPAgeTo.Size = new System.Drawing.Size(98, 22);
            this.ddlPAgeTo.TabIndex = 308;
            this.ddlPAgeTo.Tag = "nonBorn Year upto";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(108, 41);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(23, 13);
            this.label105.TabIndex = 310;
            this.label105.Text = "To";
            // 
            // ddlPAgeFrom
            // 
            this.ddlPAgeFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPAgeFrom.FormattingEnabled = true;
            this.ddlPAgeFrom.Location = new System.Drawing.Point(4, 35);
            this.ddlPAgeFrom.Name = "ddlPAgeFrom";
            this.ddlPAgeFrom.Size = new System.Drawing.Size(98, 22);
            this.ddlPAgeFrom.TabIndex = 307;
            this.ddlPAgeFrom.Tag = "nonBorn Year Start";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdbtnFemale);
            this.groupBox6.Controls.Add(this.rdbtnMale);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(141, 68);
            this.groupBox6.TabIndex = 321;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Gender";
            // 
            // rdbtnFemale
            // 
            this.rdbtnFemale.AutoSize = true;
            this.rdbtnFemale.Location = new System.Drawing.Point(60, 31);
            this.rdbtnFemale.Name = "rdbtnFemale";
            this.rdbtnFemale.Size = new System.Drawing.Size(73, 18);
            this.rdbtnFemale.TabIndex = 304;
            this.rdbtnFemale.Text = "Female";
            this.rdbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdbtnMale
            // 
            this.rdbtnMale.AutoSize = true;
            this.rdbtnMale.Checked = true;
            this.rdbtnMale.Location = new System.Drawing.Point(5, 31);
            this.rdbtnMale.Name = "rdbtnMale";
            this.rdbtnMale.Size = new System.Drawing.Size(56, 18);
            this.rdbtnMale.TabIndex = 303;
            this.rdbtnMale.TabStop = true;
            this.rdbtnMale.Text = "Male";
            this.rdbtnMale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LvwCaste);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 197);
            this.groupBox2.TabIndex = 323;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caste";
            // 
            // LvwCaste
            // 
            this.LvwCaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwCaste.CheckBoxes = true;
            this.LvwCaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwCaste.GridLines = true;
            this.LvwCaste.Location = new System.Drawing.Point(3, 18);
            this.LvwCaste.Name = "LvwCaste";
            this.LvwCaste.Size = new System.Drawing.Size(156, 176);
            this.LvwCaste.TabIndex = 0;
            this.LvwCaste.UseCompatibleStateImageBehavior = false;
            this.LvwCaste.View = System.Windows.Forms.View.Details;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LvwMaritalStatus);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(12, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 145);
            this.groupBox3.TabIndex = 324;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Marital Status";
            // 
            // LvwMaritalStatus
            // 
            this.LvwMaritalStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwMaritalStatus.CheckBoxes = true;
            this.LvwMaritalStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwMaritalStatus.GridLines = true;
            this.LvwMaritalStatus.Location = new System.Drawing.Point(3, 18);
            this.LvwMaritalStatus.Name = "LvwMaritalStatus";
            this.LvwMaritalStatus.Size = new System.Drawing.Size(156, 124);
            this.LvwMaritalStatus.TabIndex = 0;
            this.LvwMaritalStatus.UseCompatibleStateImageBehavior = false;
            this.LvwMaritalStatus.View = System.Windows.Forms.View.Details;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LvwState);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox5.Location = new System.Drawing.Point(495, 86);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(170, 348);
            this.groupBox5.TabIndex = 327;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "State";
            // 
            // LvwState
            // 
            this.LvwState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwState.CheckBoxes = true;
            this.LvwState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwState.GridLines = true;
            this.LvwState.Location = new System.Drawing.Point(3, 18);
            this.LvwState.Name = "LvwState";
            this.LvwState.Size = new System.Drawing.Size(164, 327);
            this.LvwState.TabIndex = 0;
            this.LvwState.UseCompatibleStateImageBehavior = false;
            this.LvwState.View = System.Windows.Forms.View.Details;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LvwCountry);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(343, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(147, 348);
            this.groupBox4.TabIndex = 326;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Visa Country";
            // 
            // LvwCountry
            // 
            this.LvwCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwCountry.CheckBoxes = true;
            this.LvwCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwCountry.GridLines = true;
            this.LvwCountry.Location = new System.Drawing.Point(3, 18);
            this.LvwCountry.Name = "LvwCountry";
            this.LvwCountry.Size = new System.Drawing.Size(141, 327);
            this.LvwCountry.TabIndex = 0;
            this.LvwCountry.UseCompatibleStateImageBehavior = false;
            this.LvwCountry.View = System.Windows.Forms.View.Details;
            this.LvwCountry.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LvwCountry_ItemChecked);
            this.LvwCountry.SelectedIndexChanged += new System.EventHandler(this.LvwCountry_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LvwEducation);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(180, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 348);
            this.groupBox1.TabIndex = 325;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Education";
            // 
            // LvwEducation
            // 
            this.LvwEducation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwEducation.CheckBoxes = true;
            this.LvwEducation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwEducation.GridLines = true;
            this.LvwEducation.Location = new System.Drawing.Point(3, 18);
            this.LvwEducation.Name = "LvwEducation";
            this.LvwEducation.Size = new System.Drawing.Size(151, 327);
            this.LvwEducation.TabIndex = 0;
            this.LvwEducation.UseCompatibleStateImageBehavior = false;
            this.LvwEducation.View = System.Windows.Forms.View.Details;
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSMS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.Location = new System.Drawing.Point(982, 435);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(87, 31);
            this.btnSendSMS.TabIndex = 364;
            this.btnSendSMS.Text = "Send SMS";
            this.btnSendSMS.UseVisualStyleBackColor = false;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Location = new System.Drawing.Point(734, 435);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(98, 31);
            this.btnAll.TabIndex = 361;
            this.btnAll.Text = "SELECT ALL";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(836, 435);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 31);
            this.btnClear.TabIndex = 362;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.BackColor = System.Drawing.Color.Gainsboro;
            this.btnInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvert.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvert.Location = new System.Drawing.Point(903, 435);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(75, 31);
            this.btnInvert.TabIndex = 363;
            this.btnInvert.Text = "INVERT";
            this.btnInvert.UseVisualStyleBackColor = false;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LvwDetails);
            this.panel2.Location = new System.Drawing.Point(695, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 422);
            this.panel2.TabIndex = 360;
            // 
            // LvwDetails
            // 
            this.LvwDetails.BackColor = System.Drawing.SystemColors.Info;
            this.LvwDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwDetails.CheckBoxes = true;
            this.LvwDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwDetails.FullRowSelect = true;
            this.LvwDetails.GridLines = true;
            this.LvwDetails.Location = new System.Drawing.Point(0, 0);
            this.LvwDetails.Name = "LvwDetails";
            this.LvwDetails.Size = new System.Drawing.Size(411, 420);
            this.LvwDetails.TabIndex = 1;
            this.LvwDetails.UseCompatibleStateImageBehavior = false;
            this.LvwDetails.View = System.Windows.Forms.View.Details;
            // 
            // btnSearch_A
            // 
            this.btnSearch_A.BackColor = System.Drawing.SystemColors.Info;
            this.btnSearch_A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch_A.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_A.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch_A.Location = new System.Drawing.Point(565, 434);
            this.btnSearch_A.Name = "btnSearch_A";
            this.btnSearch_A.Size = new System.Drawing.Size(100, 32);
            this.btnSearch_A.TabIndex = 365;
            this.btnSearch_A.Text = "Search";
            this.btnSearch_A.UseVisualStyleBackColor = false;
            this.btnSearch_A.Click += new System.EventHandler(this.btnSearch_A_Click);
            // 
            // lblTotalCnt_A
            // 
            this.lblTotalCnt_A.AutoSize = true;
            this.lblTotalCnt_A.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCnt_A.Location = new System.Drawing.Point(607, 79);
            this.lblTotalCnt_A.Name = "lblTotalCnt_A";
            this.lblTotalCnt_A.Size = new System.Drawing.Size(55, 13);
            this.lblTotalCnt_A.TabIndex = 366;
            this.lblTotalCnt_A.Text = "Total : 0";
            // 
            // lblTotalCnt
            // 
            this.lblTotalCnt.AutoSize = true;
            this.lblTotalCnt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCnt.Location = new System.Drawing.Point(492, 592);
            this.lblTotalCnt.Name = "lblTotalCnt";
            this.lblTotalCnt.Size = new System.Drawing.Size(64, 13);
            this.lblTotalCnt.TabIndex = 370;
            this.lblTotalCnt.Text = "[TotalCnt]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 369;
            this.label2.Text = "Message :";
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(87, 469);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(472, 120);
            this.txtMessage.TabIndex = 367;
            this.txtMessage.Text = "";
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 371;
            this.label1.Text = "Template :";
            // 
            // ddlTemplate
            // 
            this.ddlTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTemplate.FormattingEnabled = true;
            this.ddlTemplate.Location = new System.Drawing.Point(87, 443);
            this.ddlTemplate.Name = "ddlTemplate";
            this.ddlTemplate.Size = new System.Drawing.Size(469, 22);
            this.ddlTemplate.TabIndex = 311;
            this.ddlTemplate.Tag = "nonBorn Year upto";
            this.ddlTemplate.SelectedIndexChanged += new System.EventHandler(this.ddlTemplate_SelectedIndexChanged);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(562, 528);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(531, 22);
            this.txtLink.TabIndex = 372;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 511);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 373;
            this.label3.Text = "Link :";
            // 
            // btnCovert
            // 
            this.btnCovert.BackColor = System.Drawing.SystemColors.Info;
            this.btnCovert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCovert.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCovert.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCovert.Location = new System.Drawing.Point(562, 556);
            this.btnCovert.Name = "btnCovert";
            this.btnCovert.Size = new System.Drawing.Size(100, 32);
            this.btnCovert.TabIndex = 374;
            this.btnCovert.Text = "Convert";
            this.btnCovert.UseVisualStyleBackColor = false;
            this.btnCovert.Click += new System.EventHandler(this.btnCovert_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dtpToDate);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.dtpFromDate);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox8.Location = new System.Drawing.Point(399, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(291, 68);
            this.groupBox8.TabIndex = 375;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(146, 37);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(137, 22);
            this.dtpToDate.TabIndex = 317;
            this.dtpToDate.Tag = "DateofBirth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 309;
            this.label4.Text = "From :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(6, 37);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(136, 22);
            this.dtpFromDate.TabIndex = 316;
            this.dtpFromDate.Tag = "DateofBirth";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(155, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 310;
            this.label5.Text = "To";
            // 
            // frmSendProfileSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 607);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnCovert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.ddlTemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalCnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblTotalCnt_A);
            this.Controls.Add(this.btnSearch_A);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSendProfileSMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Send Profile SMS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSendProfileSMS_FormClosed);
            this.Load += new System.EventHandler(this.frmSendProfileSMS_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.ComboBox ddlPAgeTo;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.ComboBox ddlPAgeFrom;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdbtnFemale;
        private System.Windows.Forms.RadioButton rdbtnMale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LvwCaste;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView LvwMaritalStatus;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView LvwState;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView LvwCountry;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView LvwEducation;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView LvwDetails;
        private System.Windows.Forms.Button btnSearch_A;
        private System.Windows.Forms.Label lblTotalCnt_A;
        private System.Windows.Forms.Label lblTotalCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlTemplate;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCovert;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label5;
    }
}