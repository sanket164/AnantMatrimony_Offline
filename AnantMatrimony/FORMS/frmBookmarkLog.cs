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
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmBookmarkLog : Form
    {
        public frmBookmarkLog()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        dbInteraction objDb = new dbInteraction();
        string strSql = "";
        int[] FieldLength;

        private void frmBookmarkLog_Load(object sender, EventArgs e)
        {

        }

        private void frmBookmarkLog_Activated(object sender, EventArgs e)
        {
            if (((frmMain)base.MdiParent).pnlMain.Visible == true)
            {
                ((frmMain)base.MdiParent).pnlMain.Visible = false;
            }
        }

        private void frmBookmarkLog_Deactivate(object sender, EventArgs e)
        {

        }

        private void frmBookmarkLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuBookmarkLogs.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                Objtbl_MemberMasterProp.MemberCode = 0;
                Objtbl_MemberMasterProp.ProfileID = txtSearchValue.Text; // ProfileID;
                Objtbl_MemberMasterProp.isLogedin = true;
                Objtbl_MemberMasterProp.LoginCode = 0;

                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsMemberMaster = Objtbl_MemberMasterBAL.Load_MemberDetails(Objtbl_MemberMasterProp);
                if (dsMemberMaster.Tables[0].Rows.Count > 0)
                {
                    lblBirthYear.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["DateOfBirth"]);
                    lblName.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["MemberName"]);
                    lblCast.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["Caste"]);

                    //tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                    int MemberCode = Objtbl_MemberMasterBAL.GetMemberCode(txtSearchValue.Text);
                    LvwDetails.Clear();
                    lblTotalCnt.Text = "";
                    strSql = " select mm.membercode,MM.ProfileID,MM.MemberName,convert(nvarchar,MM.DateofBirth,103) as DateofBirth,MM.MobileNo,MM.MobileNo1,MM.LandlineNo, ";
                    strSql += " SM.StateCity,Convert(varchar(4),MM.DateOfBirth,111) as BornYear, Cas.Caste,CASE WHEN MM.Gender = 0 then 'MALE' else 'FEMALE' END AS Gender, ";
                    strSql += " CASE WHEN dbo.isYetMember(mm.MemberCode, 0) <= 0 THEN 'FREE' ELSE 'PAID' END AS Membership";
                    strSql += " from tbl_BookmarkList bm";
                    strSql += " inner join tbl_MemberMaster mm on mm.membercode=bm.membercode ";
                    strSql += " left join dbo.tbl_StateCity SM on SM.StateCityCode=MM.StateCity ";
                    strSql += " LEFT OUTER JOIN dbo.tbl_Caste AS Cas ON MM.Caste = Cas.CasteCode ";
                    strSql += " WHERE MM.isActive IN (1 ,2) and bm.BookmarkedProfile like '%" + MemberCode + "%'";
                    DataTable dtDetails = objDb.GetDataTable(strSql);
                    if (dtDetails.Rows.Count > 0)
                    {
                        lblTotalCnt.Text = "Total : " + Convert.ToString(dtDetails.Rows.Count);
                        FieldLength = new int[] { 0, 120, 200, 100, 120, 0, 0, 100, 80, 80, 80, 80 };
                        objGlobal.FillListView(LvwDetails, dtDetails, FieldLength);
                        LvwDetails.CheckBoxes = false;
                    }
                    else
                    {
                        MessageBox.Show("Data not found", txtSearchValue.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                int MemberCode = Objtbl_MemberMasterBAL.GetMemberCode(txtSearchValue.Text);
                strSql = " select mm.membercode,MM.ProfileID,MM.MemberName,convert(nvarchar,MM.DateofBirth,103) as DateofBirth,MM.MobileNo,MM.MobileNo1,MM.LandlineNo, ";
                strSql += " SM.StateCity,Convert(varchar(4),MM.DateOfBirth,111) as BornYear, Cas.Caste,CASE WHEN MM.Gender = 0 then 'MALE' else 'FEMALE' END AS Gender, ";
                strSql += " CASE WHEN dbo.isYetMember(mm.MemberCode, 0) <= 0 THEN 'FREE' ELSE 'PAID' END AS Membership";
                strSql += " from tbl_BookmarkList bm";
                strSql += " inner join tbl_MemberMaster mm on mm.membercode=bm.membercode ";
                strSql += " left join dbo.tbl_StateCity SM on SM.StateCityCode=MM.StateCity ";
                strSql += " LEFT OUTER JOIN dbo.tbl_Caste AS Cas ON MM.Caste = Cas.CasteCode ";
                strSql += " WHERE MM.isActive IN (1 ,2) and bm.BookmarkedProfile like '%" + MemberCode + "%'";
                DataTable dtDetails = objDb.GetDataTable(strSql);
                if (dtDetails.Rows.Count > 0)
                {
                    dtDetails.TableName = "dsBookmarklog";
                    frmReportViewer objReportViewer = new frmReportViewer();
                    ReportDocument cryRpt = new ReportDocument();
                    string strPath = "";

                    strPath = Application.StartupPath + @"\REPORTS\BookmarkLog.rpt";

                    cryRpt.Load(strPath);
                    cryRpt.SetDataSource(dtDetails);
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
