using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
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
    public partial class frmSendSMS : Form
    {
        public frmSendSMS()
        {
            InitializeComponent();
        }

        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmSendSMS_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidation())
                {
                    string _tempPhNo = "";
                    bool tThread = false;
                    string[] PhoneArr = txtPhoneNumber.Text.Split(',');
                    if (PhoneArr.Length > 0)
                    {
                        for (int i = 0; i < PhoneArr.Length; i++)
                        {
                            if (_tempPhNo == PhoneArr[i].ToString())
                            {
                                tThread = true;
                            }
                            if (!objGlobal.SendSMS(PhoneArr[i].ToString(), txtMessage.Text, tThread))
                            {
                                break;
                            }
                            _tempPhNo = PhoneArr[i].ToString();
                            //else
                            //{
                            //    objGlobal.CreateSMSLog(txtMessage.Text, PhoneArr[i].ToString());
                            //}
                        }
                        MessageBox.Show("Message Sent Successfully", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMessage.Text = "";
                        txtPhoneNumber.Text = "";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CheckValidation()
        {
            bool isValid = true;
            try
            {
                if (txtPhoneNumber.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Phone Number", "Phone Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNumber.Focus();
                    isValid = false;
                }
                if (txtPhoneNumber.Text.Length < 10)
                {
                    MessageBox.Show("Please Enter Valid Phone Number", "Phone Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNumber.Focus();
                    isValid = false;
                }
                if (txtMessage.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Message", "Message Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMessage.Focus();
                    isValid = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isValid;
        }

        private void frmSendSMS_Activated(object sender, EventArgs e)
        {

        }

        private void frmSendSMS_Deactivate(object sender, EventArgs e)
        {

        }

        private void frmSendSMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuSendMessage.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblTotalCnt.Text = "Total : " + (txtMessage.Text.Length).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
