namespace AnantMatrimony.FORMS
{
    partial class frmStateCity
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
            this.txtStateCityCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCounteryStateCity = new System.Windows.Forms.ComboBox();
            this.txtStateCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtStateCityCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbCounteryStateCity);
            this.panel1.Controls.Add(this.txtStateCity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 66);
            this.panel1.TabIndex = 0;
            // 
            // txtStateCityCode
            // 
            this.txtStateCityCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStateCityCode.Location = new System.Drawing.Point(354, 31);
            this.txtStateCityCode.Name = "txtStateCityCode";
            this.txtStateCityCode.Size = new System.Drawing.Size(13, 22);
            this.txtStateCityCode.TabIndex = 134;
            this.txtStateCityCode.Tag = "";
            this.txtStateCityCode.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "Country :";
            // 
            // cmbCounteryStateCity
            // 
            this.cmbCounteryStateCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCounteryStateCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCounteryStateCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounteryStateCity.Location = new System.Drawing.Point(114, 7);
            this.cmbCounteryStateCity.Name = "cmbCounteryStateCity";
            this.cmbCounteryStateCity.Size = new System.Drawing.Size(234, 22);
            this.cmbCounteryStateCity.TabIndex = 0;
            // 
            // txtStateCity
            // 
            this.txtStateCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStateCity.Location = new System.Drawing.Point(114, 31);
            this.txtStateCity.Name = "txtStateCity";
            this.txtStateCity.Size = new System.Drawing.Size(234, 22);
            this.txtStateCity.TabIndex = 1;
            this.txtStateCity.Tag = "comtxtStateCity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "State / City :";
            // 
            // frmStateCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 87);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmStateCity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "State/City";
            this.Activated += new System.EventHandler(this.frmStateCity_Activated);
            this.Deactivate += new System.EventHandler(this.frmStateCity_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStateCity_FormClosed);
            this.Load += new System.EventHandler(this.frmStateCity_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCounteryStateCity;
        private System.Windows.Forms.TextBox txtStateCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStateCityCode;
    }
}