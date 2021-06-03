using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmPhotosUploadInfo : Form
    {
        public frmPhotosUploadInfo()
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

        private void frmPhotosUploadInfo_Load(object sender, EventArgs e)
        {
            try
            {
                //GridDesign(dgvDetails);

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

                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmPhotosUploadInfo.frmPhotosUploadInfo_Load() " + ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string EmailAdd = "", strMemberName = "";
                for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                {
                    if (LvwDetails.Items[cnt].Checked)
                    {
                        if (EmailAdd == "")
                        {
                            EmailAdd = LvwDetails.Items[cnt].SubItems[4].Text;
                            strMemberName = LvwDetails.Items[cnt].SubItems[1].Text;
                        }
                        else
                        {
                            EmailAdd += "|" + LvwDetails.Items[cnt].SubItems[4].Text;
                            strMemberName += "|" + LvwDetails.Items[cnt].SubItems[1].Text;
                        }
                    }
                }
                if (EmailAdd != "")
                {
                    string[] arrEmailAdd = EmailAdd.Split('|');
                    string[] arrMemberName = strMemberName.Split('|');
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
                        strHTML += "   <p>It's seems like you have not uploaded photos in your profile. Please upload your photos to get proper inquires. Visis us on <a href='http://www.anantmatrimony.com' target='_blank'>www.anantmatrimony.com</a></p> ";
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
                        objGlobal.SendMail(arrEmailAdd[i], "AnantMatrimony : photos not Upload", strHTML, true, "photoupdate@anantmatrimony.com", "Changeme@123");

                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("Mail Sent to Sender", "Send Email info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string MobileNo = "", strMemberName = "", strProfileId = "";
                for (int cnt = 0; cnt < LvwDetails.Items.Count; cnt++)
                {
                    if (LvwDetails.Items[cnt].Checked)
                    {
                        if (MobileNo == "")
                        {
                            MobileNo = LvwDetails.Items[cnt].SubItems[3].Text;
                            strMemberName = LvwDetails.Items[cnt].SubItems[1].Text;
                            strProfileId = LvwDetails.Items[cnt].SubItems[0].Text;
                        }
                        else
                        {
                            MobileNo += "|" + LvwDetails.Items[cnt].SubItems[3].Text;
                            strMemberName += "|" + LvwDetails.Items[cnt].SubItems[1].Text;
                            strProfileId += "|" + LvwDetails.Items[cnt].SubItems[0].Text;
                        }
                    }
                }
                if (MobileNo != "")
                {
                    string[] arrMobileno = MobileNo.Split('|');
                    string[] arrMemberName = strMemberName.Split('|');
                    string[] arrProfileId = strProfileId.Split('|');
                    string _tempPhNo = "";
                    bool tThread = false;
                    for (int i = 0; i < arrMobileno.Length; i++)
                    {
                        if (_tempPhNo == arrMobileno[i].ToString())
                        {
                            tThread = true;
                        }
                        string strSMS = "Hello " + arrProfileId[i] + Environment.NewLine;
                        strSMS += "It's seems like you have not uploaded photos in your profile. Please upload photos to get proper inquires. Visis us on www.anantmatrimony.com";
                        objGlobal.SendSMS(arrMobileno[i], strSMS, tThread);
                        _tempPhNo = arrMobileno[i].ToString();
                    }
                }
                Cursor = Cursors.Default;
                MessageBox.Show("Message Sent", "Send Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }

        private void frmPhotosUploadInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuPhotoUploadSMSEmail.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        public void GridDesign(DataGridView dgv)
        {
            try
            {
                int index = 0;
                //dgv.TopLeftHeaderCell.Value = "SrNo.";
                //dgv.RowHeadersWidth = 50;
                dgv.RowHeadersVisible = false;
                int btnCounter = 0;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                DataGridViewTextBoxColumn[] columnArray = new DataGridViewTextBoxColumn[20];
                DataGridViewButtonColumn grdButton;
                string[] strArray = new string[] { 
                "MemberCode","Profile Id","Member Name","CityName","Caste","BornYear","Gender","Email","MobileNo", "Ex","Ex1"
            };
                int[] numArray = new int[] { 
                0,100, 100,100, 100, 100,100,100, 100, 0, 0
            };
                for (int i = 0; i < strArray.Length; i++)
                {

                    columnArray[index] = new DataGridViewTextBoxColumn();
                    columnArray[index].HeaderText = strArray[i];
                    columnArray[index].Width = numArray[i];
                    dgv.Columns.Add(columnArray[index]);
                    dgv.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                    index++;

                }
                dgv.Columns[(int)CI.EX].Visible = false;
                dgv.Columns[(int)CI.EX1].Visible = false;
                dgv.Columns[(int)CI.MemberCode].Visible = false;

                dgv.ReadOnly = true;

                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
                dgv.DefaultCellStyle.ForeColor = Color.Blue;
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmPhotosUploadInfo.GridDesign() " + exception.ToString());
            }
        }

        public void FillGrid()
        {
            try
            {
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
                if (txtProfileId.Text.Trim() != "")
                {
                    strCondi += " AND profileid='" + txtProfileId.Text.Trim() + "'";
                }
                tbl_MemberMasterBAL objMembermaster = new tbl_MemberMasterBAL();
                DataSet dtDetails = objMembermaster.GET_UPLOAD_PHOTO_PENDING(strCondi);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
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
                tbl_MemberMasterBAL objMembermaster = new tbl_MemberMasterBAL();
                DataSet dtDetails = objMembermaster.GET_UPLOAD_PHOTO_PENDING(strCondi);
                if (dtDetails.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objReportViewer = new frmReportViewer();
                    ReportDocument cryRpt = new ReportDocument();
                    string strPath = "";
                    strPath = Application.StartupPath + @"\REPORTS\PhotoUploadPending.rpt";
                    cryRpt.Load(strPath);
                    cryRpt.SetDataSource(dtDetails.Tables[0]);
                    objReportViewer.RptViewer.ReportSource = cryRpt;
                    objReportViewer.RptViewer.Refresh();
                    objReportViewer.ShowDialog();
                    objReportViewer.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
