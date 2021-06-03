namespace AnantMatrimony.FORMS
{
    partial class frmSMSTemplateMaster
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.txtTemplateMessage = new System.Windows.Forms.TextBox();
            this.txtTemplateId = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTemplateId);
            this.panel1.Controls.Add(this.txtTemplateMessage);
            this.panel1.Controls.Add(this.txtTemplateName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 161);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 310;
            this.label1.Text = "Template Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 14);
            this.label2.TabIndex = 311;
            this.label2.Text = "Template Message :";
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemplateName.Location = new System.Drawing.Point(157, 15);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(241, 22);
            this.txtTemplateName.TabIndex = 312;
            this.txtTemplateName.Tag = "TemplateName";
            // 
            // txtTemplateMessage
            // 
            this.txtTemplateMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemplateMessage.Location = new System.Drawing.Point(157, 46);
            this.txtTemplateMessage.Multiline = true;
            this.txtTemplateMessage.Name = "txtTemplateMessage";
            this.txtTemplateMessage.Size = new System.Drawing.Size(346, 97);
            this.txtTemplateMessage.TabIndex = 313;
            this.txtTemplateMessage.Tag = "TemplateMessage";
            // 
            // txtTemplateId
            // 
            this.txtTemplateId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemplateId.Location = new System.Drawing.Point(404, 18);
            this.txtTemplateId.Name = "txtTemplateId";
            this.txtTemplateId.Size = new System.Drawing.Size(13, 22);
            this.txtTemplateId.TabIndex = 137;
            this.txtTemplateId.Tag = "";
            this.txtTemplateId.Visible = false;
            // 
            // frmSMSTemplateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 180);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSMSTemplateMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SMS Template Master";
            this.Activated += new System.EventHandler(this.frmSMSTemplateMaster_Activated);
            this.Deactivate += new System.EventHandler(this.frmSMSTemplateMaster_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSMSTemplateMaster_FormClosing);
            this.Load += new System.EventHandler(this.frmSMSTemplateMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.TextBox txtTemplateMessage;
        private System.Windows.Forms.TextBox txtTemplateId;
    }
}