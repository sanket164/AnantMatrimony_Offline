using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmQueryMessage : Form
    {
        int MessageCode = 0;
        public frmQueryMessage()
        {
            InitializeComponent();
        }

        public frmQueryMessage(int iMessageCode)
        {
            InitializeComponent();
            MessageCode = iMessageCode;
        }

        private void frmQueryMessage_Load(object sender, EventArgs e)
        {
            if (MessageCode > 0)
            {
                FillData(MessageCode);
            }
        }

        private void FillData(int MessCode)
        {
            try
            {
                int PageCount = 0;
                tbl_QueryProp objtbl_QueryProp = new tbl_QueryProp();
                objtbl_QueryProp.MessageCode = MessCode;

                tbl_QueryBAL objtbl_QueryBAL = new tbl_QueryBAL();
                DataSet dsData = objtbl_QueryBAL.Select_Data(objtbl_QueryProp, ref PageCount);

                txtName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["Surname"]) + " " + Convert.ToString(dsData.Tables[0].Rows[0]["SenderName"]);
                txtContactNo.Text = Convert.ToString(dsData.Tables[0].Rows[0]["ContactNo"]);
                txtEmail.Text = Convert.ToString(dsData.Tables[0].Rows[0]["Email"]);
                txtAddress.Text = Convert.ToString(dsData.Tables[0].Rows[0]["Address"]);
                txtSubject.Text = Convert.ToString(dsData.Tables[0].Rows[0]["Subject"]);
                txtMessage.Text = Convert.ToString(dsData.Tables[0].Rows[0]["SenderMessage"]);
                dtpDate.Value = Convert.ToDateTime(dsData.Tables[0].Rows[0]["Date"]);

                objtbl_QueryProp.Address = txtAddress.Text;
                objtbl_QueryProp.ContactNo = txtContactNo.Text;
                objtbl_QueryProp.Date = dtpDate.Value;
                objtbl_QueryProp.Email = txtEmail.Text;
                objtbl_QueryProp.SenderMessage = txtMessage.Text;
                objtbl_QueryProp.SenderName = txtName.Text;
                objtbl_QueryProp.Subject = txtSubject.Text;
                objtbl_QueryProp.Surname = "";
                objtbl_QueryProp.Status = true;
                //objtbl_QueryProp.Date = DateTime.Today;
                objtbl_QueryBAL.InsertUpdate_Data(objtbl_QueryProp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_QueryProp objtbl_QueryProp = new tbl_QueryProp();
                if (MessageCode > 0)
                {
                    objtbl_QueryProp.MessageCode = MessageCode;
                }
                else
                {
                    objtbl_QueryProp.MessageCode = 0;
                }

                tbl_QueryBAL objtbl_QueryBAL = new tbl_QueryBAL();
                objtbl_QueryProp.Address = txtAddress.Text;
                objtbl_QueryProp.ContactNo = txtContactNo.Text;
                //objtbl_QueryProp.Date = dtpDate.Value;
                objtbl_QueryProp.Email = txtEmail.Text;
                objtbl_QueryProp.SenderMessage = txtMessage.Text;
                objtbl_QueryProp.SenderName = txtName.Text;
                objtbl_QueryProp.Subject = txtSubject.Text;
                objtbl_QueryProp.Surname = "";
                objtbl_QueryProp.Status = false;
                objtbl_QueryProp.Date = DateTime.Today;
                objtbl_QueryBAL.InsertUpdate_Data(objtbl_QueryProp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
