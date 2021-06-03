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
    public partial class frmMarriedConfirmation : Form
    {
        public frmMarriedConfirmation()
        {
            InitializeComponent();
        }

        public enum CI
        {
            MemberCode = 0,
            ProfileId,
            MemberName,
            CityName,
            Caste,
            BornYear,
            Gender,
            Email,
            MobileNo,
            EX,
            EX1
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();
        string strSql = "";
        int[] FieldLength;

        private void frmMarriedConfirmation_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeFrom.DataSource = dtBornYear;
                ddlPAgeFrom.DisplayMember = "Number";
                ddlPAgeFrom.ValueMember = "NValue";

                DataTable dtToBornYear = dtBornYear.Copy();
                ddlPAgeTo.DataSource = dtToBornYear;
                ddlPAgeTo.DisplayMember = "Number";
                ddlPAgeTo.ValueMember = "NValue";

                strSql = " SELECT 0 AS CasteCode,'All' AS Caste,0 as ORD";
                strSql += " UNION ALL ";
                strSql += "SELECT CasteCode,Caste,1 as ORD FROM tbl_Caste ORDER BY ORD,Caste";
                DataTable dvCaste = objDb.GetDataTable(strSql);
                ddlCaste.DataSource = dvCaste;
                ddlCaste.DisplayMember = "Caste";
                ddlCaste.ValueMember = "CasteCode";
                ddlUpdateStatus.SelectedIndex = 0;
                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMarriedConfirmation.frmMarriedConfirmation_Load() " + ex.ToString());
            }
        }

        private void frmMarriedConfirmation_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuMarriedConfirmation.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()
        {
            try
            {
                LvwDetails.Items.Clear();
                string strCondi = "";
                //strSql = "  SELECT TOP 1000 MemberCode,ProfileId,MobileNo,MobileNo_Rel,MobileNo1,MobileNo1_Rel,LandlineNo,MobileNo2_Rel,LandlineNo1,LandlineNo1_Rel FROM tbl_membermaster WHERE isnull(MobileNo_Rel,'')='' ";
                strCondi += " AND MM.Gender =" + (rdbtnMale.Checked == true ? "0" : "1");
                if (Convert.ToString(ddlPAgeFrom.SelectedValue) != Convert.ToString(ddlPAgeTo.SelectedValue))
                {
                    strCondi += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom.Text + " AND " + ddlPAgeTo.Text + "";
                }
                if (Convert.ToInt32(ddlCaste.SelectedValue) > 0)
                {
                    strCondi += " AND MM.Caste = " + ddlCaste.SelectedValue;
                }

                if (ddlUpdateStatus.Text.ToUpper() == "NOT SEND LIST")
                {
                    strCondi += " and Married= -1 ";
                }
                else if (ddlUpdateStatus.Text.ToUpper() == "SEND LIST")
                {
                    strCondi += " and Married= 0 ";
                }
                else if (ddlUpdateStatus.Text.ToUpper() == "YES LIST")
                {
                    strCondi += " and Married= 1 ";
                }
                else if (ddlUpdateStatus.Text.ToUpper() == "NO LIST")
                {
                    strCondi += " and Married= 2 ";
                }
                if (txtProfileId.Text.Trim() != "")
                {
                    strCondi += " AND profileid='" + txtProfileId.Text.Trim() + "'";
                }
                tbl_MemberMasterBAL objMembermaster = new tbl_MemberMasterBAL();
                DataSet dtDetails = objMembermaster.GetMarriedConfirmationList(strCondi);
                if (dtDetails.Tables[0].Rows.Count > 0)
                {
                    lblTotalCnt.Text = "Total : " + Convert.ToString(dtDetails.Tables[0].Rows.Count);
                    FieldLength = new int[] { 150, 200, 100, 120, 170, 80, 50, 50, 0 };
                    objGlobal.FillListView(LvwDetails, dtDetails.Tables[0], FieldLength);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                Cursor = Cursors.WaitCursor;
                string EmailAdd = "", strMemberName = "", strMemberCode = "";
                for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                {
                    if (LvwDetails.Items[cnt].Checked)
                    {
                        if (EmailAdd == "")
                        {
                            EmailAdd = LvwDetails.Items[cnt].SubItems[4].Text;
                            strMemberName = LvwDetails.Items[cnt].SubItems[1].Text;
                            strMemberCode = LvwDetails.Items[cnt].SubItems[8].Text;
                        }
                        else
                        {
                            EmailAdd += "|" + LvwDetails.Items[cnt].SubItems[4].Text;
                            strMemberName += "|" + LvwDetails.Items[cnt].SubItems[1].Text;
                            strMemberCode += "|" + LvwDetails.Items[cnt].SubItems[8].Text;
                        }
                    }
                }
                if (EmailAdd != "")
                {
                    string[] arrEmailAdd = EmailAdd.Split('|');
                    string[] arrMemberName = strMemberName.Split('|');
                    string[] arrMemberCode = strMemberCode.Split('|');
                    for (int i = 0; i < arrEmailAdd.Length; i++)
                    {
                        string strHTML = "<html> ";
                        strHTML += " <head> ";
                        strHTML += " <title>Anant Matrimony</title> ";
                        strHTML += " <link href='https://fonts.googleapis.com/css?family=Lato:400,500,600,700' rel='stylesheet' /> ";
                        strHTML += " </head> ";
                        strHTML += " <body style='font-family: 'Lato', sans-serif;background-color: #ffffff;margin: 0px;padding: 0px;width: 100%;font-size: 15px;font-weight: 400;color: #323232;line-height: 18px;text-align:left;'> ";
                        strHTML += "  <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' class='contentbg'> ";
                        strHTML += " <tr> <td valign='top'>  ";
                        strHTML += "  <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                        strHTML += " <tr> <td valign='top' bgcolor='#FFFFFF'>  ";
                        strHTML += "  <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'>  ";
                        strHTML += "  <tr> <td width='80%' height='105' align='left' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr>  ";
                        strHTML += "  <td valign='top' bgcolor='#ca3b3b' style='padding:35px;'><a href='#'><img src='http://www.anantmatrimony.com/images/logo.png' width='349' height='107' alt='logo' style='margin-left: auto;margin-right: auto;' /></a></td> ";
                        strHTML += "  </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> ";
                        strHTML += " <td valign='top'> ";
                        strHTML += " <table width='50%' border='0' cellspacing='0' cellpadding='0' align='center'> ";
                        strHTML += " <tr> <td valign='top'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding:20px 0px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> ";
                        strHTML += "  <td width='100%' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += "  <tr> ";
                        strHTML += "  <td width='100%' valign='top' style='padding-bottom: 16px; text-align: left; font-size: 22px; font-weight: 600; color: #323232; line-height: 44px; border-bottom: 1px solid #e8e8e8; '> ";
                        strHTML += "  <p>Hello " + arrMemberName[i] + " ,</p> ";
                        strHTML += "   <p>We request you to update us with your relationship status so that we can delete your profile if you are already engaged or married. <a href='http://www.anantmatrimony.com/MarriedConfirmation?mid=" + arrMemberCode[i] + "' target='_blank'>www.anantmatrimony.com/UpdateStatus</a></p> ";
                        strHTML += "  </td> </tr> <tr> ";
                        strHTML += "    <td class='footerheading' width='100%' valign='top' style='padding-bottom:16px;text-align:center;font-size: 22px;font-weight: 600;color: #323232;line-height: 44px;'>For More Details, Call Us!</td> ";
                        strHTML += "   </tr> <tr> ";
                        strHTML += "     <td width='100%' valign='top' style='padding-bottom:16px;border-bottom:1px solid #e8e8e8;font-size: 35px;font-weight: 600;color: #f54d56;line-height: 24px;text-align:center;'>9428412065/9998489093</td> ";
                        strHTML += "   </tr> <tr> ";
                        strHTML += " <td width='100%' valign='top' style='padding-bottom: 16px; border-bottom: 1px solid #e8e8e8; color: #323232; line-height: 24px; text-align: justify; '> ";
                        strHTML += "  <p style=' padding: 0px; margin: 0px; margin-top: 15px;'>425, 4th Floor, Saman Complex,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Opp. Satyam Mall,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Near Jodhpur Cross Roads,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Satellite, Ahmedabad,</p> ";
                        strHTML += " <p style=' padding: 0px; margin: 0px;'>Gujarat 380015</p> ";
                        strHTML += " </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td valign='top'> ";
                        strHTML += " <table width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding-bottom:33px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> <td width='100%' valign='top'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'> ";
                        strHTML += " <tr> <td valign='top' style='padding-top:21px; padding-bottom:17px;'> ";
                        strHTML += " <table width='100%' border='0' cellspacing='0' cellpadding='0'></table> ";
                        strHTML += " </td> </tr> <tr> ";
                        strHTML += " <td valign='top' style='font-size:13px;color:#989797;text-align:center; padding-right:84px;'> ";
                        strHTML += " © 2003 - 2019 AnantMatrimony.com & Kankukanya.com. All Rights Reserved.<br /> ";
                        strHTML += "  </td> </tr> </table> </td>  </tr> </table> </td> </tr> </table> </td> </tr> ";
                        strHTML += " </table> </td> </tr> </table> </body> </html>";
                        if (objGlobal.SendMail(arrEmailAdd[i], "AnantMatrimony : Relationship Status ", strHTML, true, "relationship@anantmatrimony.com", "Changeme@123"))
                        {
                            UpdateSendStatus(Convert.ToInt32(arrMemberCode[i]));
                        }
                        else
                        {

                        }
                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("E-Mail Sent", "Send Eamil info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMarriedConfirmation.btnSendEmail_Click() " + ex.ToString());
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string MobileNo = "", strMemberName = "", strMemberCode = "", strProfileId = "";
                for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                {
                    if (LvwDetails.Items[cnt].Checked)
                    {
                        if (MobileNo == "")
                        {
                            MobileNo = LvwDetails.Items[cnt].SubItems[3].Text;
                            strMemberName = LvwDetails.Items[cnt].SubItems[1].Text;
                            strMemberCode = LvwDetails.Items[cnt].SubItems[8].Text;
                            strProfileId = LvwDetails.Items[cnt].SubItems[0].Text;
                        }
                        else
                        {
                            MobileNo += "|" + LvwDetails.Items[cnt].SubItems[3].Text;
                            strMemberName += "|" + LvwDetails.Items[cnt].SubItems[1].Text;
                            strMemberCode += "|" + LvwDetails.Items[cnt].SubItems[8].Text;
                            strProfileId += "|" + LvwDetails.Items[cnt].SubItems[0].Text;
                        }
                    }
                }
                if (MobileNo != "")
                {
                    string[] arrMobileno = MobileNo.Split('|');
                    string[] arrMemberName = strMemberName.Split('|');
                    string[] arrMemberCode = strMemberCode.Split('|');
                    string[] arrProfileId = strProfileId.Split('|');
                    string _tempPhNo = "";
                    bool tThread = false;
                    for (int i = 0; i < arrMobileno.Length; i++)
                    {
                        if (_tempPhNo == arrMobileno[i].ToString())
                        {
                            tThread = true;
                        }
                        string strSMS = "Hello " + arrMemberName[i] + Environment.NewLine;
                        strSMS += "Please notify your marraige status so we can update your profile.";
                        strSMS += " www.anantmatrimony.com/MarriedConfirmation?mid=" + arrMemberCode[i];
                        objGlobal.SendSMS(arrMobileno[i], strSMS, tThread);
                        UpdateSendStatus(Convert.ToInt32(arrMemberCode[i]));
                        _tempPhNo = arrMobileno[i].ToString();
                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("Message Sent", "Send Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMarriedConfirmation.btnSendSMS_Click() " + ex.ToString());
            }
        }

        public bool UpdateSendStatus(int MemberCode)
        {
            try
            {
                strSql = " UPDATE tbl_membermaster SET Married=0 WHERE MemberCode=" + MemberCode;
                int Res = objDb.ExecuteNonQuery(strSql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMarriedConfirmation.btnSendEmail_Click() " + ex.ToString());
                return false;
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUpdateStatus.Text.ToUpper() == "YES LIST")
                {
                    int iCnt = 0;
                    for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                    {
                        if (LvwDetails.Items[cnt].Checked)
                        {
                            string strMemberCode = LvwDetails.Items[cnt].SubItems[8].Text;
                            strSql = " UPDATE tbl_MemberMaster SET isActive=3 WHERE MemberCode=" + strMemberCode;
                            objDb.ExecuteNonQuery(strSql);
                            iCnt++;
                            strSql = "DELETE FROM tbl_ProfilevisitLog_new WHERE MemberCode=" + strMemberCode;
                            objDb.ExecuteNonQuery(strSql);
                            strSql = "DELETE FROM tbl_LogTable WHERE MemberCode=" + strMemberCode;
                            objDb.ExecuteNonQuery(strSql);
                        }
                    }
                    
                    MessageBox.Show("Total : " + iCnt + " Update Successfully", "Done MemberStatus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Only works in Yes List","Validation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
