using AnantMatrimony.FORMS;
using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace AnantMatrimony
{
    public partial class frmFirstPageSMS : Form
    {
        public frmFirstPageSMS()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();
        string strSql = "";

        private void frmFirstPageSMS_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string strCode = "";
                if (txtProfileId.Text == "")
                {
                    MessageBox.Show("Please Enter Profile Id", "Profile Id Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProfileId.Focus();
                    return;
                }
                if (txtProfileId.Text != "")
                {
                    string strSQl = "select * from tbl_Membermaster where ProfileId='" + txtProfileId.Text.Trim() + "' ";
                    DataTable dt = objDb.GetDataTable(strSQl);
                    if (dt.Rows.Count > 0)
                    {
                        strCode = Convert.ToString(dt.Rows[0]["MemberCode"]);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter valid Profile Id", "Valid Profile Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtProfileId.Focus();
                        return;
                    }
                }
                strSql = "select * from tbl_memberMaster where ProfileID='" + txtProfileId.Text + "'";
                DataTable dtMember = objDb.GetDataTable(strSql);

                if (dtMember.Rows.Count > 0)
                {
                    string strMaritalStatus = Convert.ToString(dtMember.Rows[0]["MaritalStatus"]);
                    string strCaste = Convert.ToString(dtMember.Rows[0]["Caste"]);
                    DateTime BornYear = Convert.ToDateTime(dtMember.Rows[0]["DateOfBirth"]);
                    int Gender = Convert.ToInt32(dtMember.Rows[0]["Gender"]);
                    string PhoneNumber = Convert.ToString(dtMember.Rows[0]["MobileNo"]);
                    lblMobileNo.Text = Convert.ToString(dtMember.Rows[0]["MobileNo"]);
                    if (MessageBox.Show("Are you sure you want to send SMS on " + PhoneNumber, "SMS Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        Cursor = Cursors.Default;
                        return;
                    }
                    int op_Gender = 0;
                    string strGenderName = "";
                    string _fromYear = "", _toYear = "";
                    if (Gender == 1)//// Gander Female
                    {
                        _fromYear = (BornYear.Year - 5).ToString();
                        _toYear = (BornYear.Year).ToString();
                        op_Gender = 0;
                        strGenderName = "Grooms";
                    }
                    else////Gender Male
                    {
                        _fromYear = BornYear.Year.ToString();
                        _toYear = (BornYear.Year + 5).ToString();
                        op_Gender = 1;
                        strGenderName = "Brides";
                    }
                    string strCasteName = Convert.ToString(objDb.ExecuteScalar("select Caste from tbl_Caste where CasteCode=" + strCaste));
                    string strLink = "anantmatrimony.com/ProfileDetails?FYear=" + _fromYear + "&TYear=" + _toYear + "&MStatus=" + strMaritalStatus + "&Caste=" + strCaste + "&G=" + op_Gender + "&Edu=0&StCt=0&Cou=0";
                    strLink = HttpUtility.UrlEncode(strLink);
                    string strMsg = strCasteName + " " + strGenderName + " list " + _fromYear + " to " + _toYear + "\n\n";
                    strMsg += strLink + "\n\n";
                    strMsg += "Anant Matrimony \n";
                    strMsg += "91999849093";
                    if (objGlobal.SendSMS(PhoneNumber, strMsg, false))
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Message Sent", "Sucessfully Message Send", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Something went wrong", "Failed Message ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmFirstPageSMS.btnSearch_Click() " + ex.ToString());
            }
        }

        private void frmFirstPageSMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuFirstPageSMS.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }
    }
}
