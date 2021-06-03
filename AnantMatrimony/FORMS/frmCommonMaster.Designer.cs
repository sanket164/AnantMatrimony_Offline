namespace AnantMatrimony.FORMS
{
    partial class frmCommonMaster
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
            this.lblFrmName = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblFrmName);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 85);
            this.panel1.TabIndex = 1;
            // 
            // lblFrmName
            // 
            this.lblFrmName.AutoSize = true;
            this.lblFrmName.Location = new System.Drawing.Point(6, 64);
            this.lblFrmName.Name = "lblFrmName";
            this.lblFrmName.Size = new System.Drawing.Size(87, 14);
            this.lblFrmName.TabIndex = 137;
            this.lblFrmName.Text = "lblFrmName";
            this.lblFrmName.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Location = new System.Drawing.Point(334, 37);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(13, 22);
            this.txtCode.TabIndex = 136;
            this.txtCode.Tag = "";
            this.txtCode.Visible = false;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(7, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(321, 22);
            this.txtName.TabIndex = 6;
            this.txtName.Tag = "";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(97, 14);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Blood Group :";
            // 
            // frmCommonMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 110);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmCommonMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmCommonMaster";
            this.Activated += new System.EventHandler(this.frmCommonMaster_Activated);
            this.Deactivate += new System.EventHandler(this.frmCommonMaster_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCommonMaster_FormClosed);
            this.Load += new System.EventHandler(this.frmCommonMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFrmName;
    }
}