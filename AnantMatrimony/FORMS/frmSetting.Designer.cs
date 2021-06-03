namespace AnantMatrimony.FORMS
{
    partial class frmSetting
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
            this.label94 = new System.Windows.Forms.Label();
            this.txtAgeDiff = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtProfileId = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.chkPMaritalStatus = new System.Windows.Forms.CheckedListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.chkPMaritalStatus);
            this.panel1.Controls.Add(this.txtProfileId);
            this.panel1.Controls.Add(this.label68);
            this.panel1.Controls.Add(this.btnSaveSettings);
            this.panel1.Controls.Add(this.label94);
            this.panel1.Controls.Add(this.txtAgeDiff);
            this.panel1.Controls.Add(this.label93);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 208);
            this.panel1.TabIndex = 0;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(17, 64);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(104, 14);
            this.label94.TabIndex = 315;
            this.label94.Text = "MaritalStatus :";
            // 
            // txtAgeDiff
            // 
            this.txtAgeDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgeDiff.Location = new System.Drawing.Point(127, 39);
            this.txtAgeDiff.Name = "txtAgeDiff";
            this.txtAgeDiff.Size = new System.Drawing.Size(143, 22);
            this.txtAgeDiff.TabIndex = 1;
            this.txtAgeDiff.Tag = "";
            this.txtAgeDiff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgeDiff_KeyPress);
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.Location = new System.Drawing.Point(52, 40);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(69, 14);
            this.label93.TabIndex = 312;
            this.label93.Text = "Age Diff :";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(424, 172);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(94, 31);
            this.btnSaveSettings.TabIndex = 3;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtProfileId
            // 
            this.txtProfileId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileId.Location = new System.Drawing.Point(127, 14);
            this.txtProfileId.Name = "txtProfileId";
            this.txtProfileId.Size = new System.Drawing.Size(143, 22);
            this.txtProfileId.TabIndex = 0;
            this.txtProfileId.Tag = "";
            this.txtProfileId.TextChanged += new System.EventHandler(this.txtProfileId_TextChanged);
            this.txtProfileId.Validating += new System.ComponentModel.CancelEventHandler(this.txtProfileId_Validating);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(47, 18);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(78, 14);
            this.label68.TabIndex = 331;
            this.label68.Text = "Profile Id :";
            // 
            // chkPMaritalStatus
            // 
            this.chkPMaritalStatus.CheckOnClick = true;
            this.chkPMaritalStatus.FormattingEnabled = true;
            this.chkPMaritalStatus.Location = new System.Drawing.Point(127, 64);
            this.chkPMaritalStatus.Name = "chkPMaritalStatus";
            this.chkPMaritalStatus.Size = new System.Drawing.Size(260, 123);
            this.chkPMaritalStatus.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(276, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 25);
            this.btnSearch.TabIndex = 332;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 230);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Member Setting ";
            this.Activated += new System.EventHandler(this.frmSetting_Activated);
            this.Deactivate += new System.EventHandler(this.frmSetting_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetting_FormClosed);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.TextBox txtAgeDiff;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtProfileId;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.CheckedListBox chkPMaritalStatus;
        private System.Windows.Forms.Button btnSearch;
    }
}