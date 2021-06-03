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
    public partial class frmExpireNoti : Form
    {
        public frmExpireNoti()
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
        int[] FieldLength;


        private void frmExpireNoti_Load(object sender, EventArgs e)
        {

        }

        private void frmExpireNoti_FormClosing(object sender, FormClosingEventArgs e)
        {
            //mnuExpireMembershipSMS
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuExpireMembershipSMS.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        public void FillList()
        {
            try
            {
                string strCond = "", Caste_Sel = "";
                //if (dtpFromDate.Value.ToShortDateString() != dtpToDate.Value.ToShortDateString())
                //{
                strCond += " AND MS.EndDate BETWEEN '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                //}
                if (strCond == "")
                {
                    MessageBox.Show("Please select Something", "Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.GET_ExpiredMembership(strCond);
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    lblTotalCnt.Text = "Total : " + Convert.ToString(dsdata.Tables[0].Rows.Count);
                    FieldLength = new int[] { 150, 200, 100, 120, 120, 0, 100, 0, 100, 0, 0, 80, 80, 80, 0 };
                    objGlobal.FillListView(LvwDetails, dsdata.Tables[0], FieldLength);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillList();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails, true, false, false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails, false, true, false);
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            objGlobal.LISTVIEWSELECTION(LvwDetails, false, false, true);
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string _tempPhNo = "";
                bool tThread = false;
                string MobileNo = "", strMemberName = "", strExpireDate = "", strProfileId = "";
                for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                {
                    if (LvwDetails.Items[cnt].Checked)
                    {
                        if (MobileNo == "")
                        {
                            MobileNo = LvwDetails.Items[cnt].SubItems[3].Text;
                            strMemberName = LvwDetails.Items[cnt].SubItems[1].Text;
                            strExpireDate = LvwDetails.Items[cnt].SubItems[8].Text;
                            strProfileId = LvwDetails.Items[cnt].SubItems[0].Text;
                        }
                        else
                        {
                            MobileNo += "|" + LvwDetails.Items[cnt].SubItems[3].Text;
                            strMemberName += "|" + LvwDetails.Items[cnt].SubItems[1].Text;
                            strExpireDate += "|" + LvwDetails.Items[cnt].SubItems[8].Text;
                            strProfileId += "|" + LvwDetails.Items[cnt].SubItems[0].Text;
                        }
                    }
                }
                if (MobileNo != "")
                {

                    string[] arrMobileno = MobileNo.Split('|');
                    string[] arrMemberName = strMemberName.Split('|');
                    string[] arrExpireDate = strExpireDate.Split('|');
                    string[] arrProfileId = strProfileId.Split('|');

                    for (int i = 0; i < arrMobileno.Length; i++)
                    {
                        if (_tempPhNo == arrMobileno[i].ToString())
                        {
                            tThread = true;
                        }
                        string strSMS = "Hello " + arrMemberName[i] + Environment.NewLine;
                        strSMS += "Your Membership is going to be Expired on " + arrExpireDate[i] + " at";
                        strSMS += " www.anantmatrimony.com";
                        objGlobal.SendSMS(arrMobileno[i], strSMS, tThread);
                        _tempPhNo = arrMobileno[i].ToString();
                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("Message Sent", "Send Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
