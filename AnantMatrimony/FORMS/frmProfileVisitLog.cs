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
    public partial class frmProfileVisitLog : Form
    {
        public frmProfileVisitLog()
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

        private void frmProfileVisitLog_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmProfileVisitLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuProfileVisitLog.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void btnSearch_VisitLog_Click(object sender, EventArgs e)
        {
            try
            {
                string strMemberCode = "";               
                //strSql = "select * from tbl_ProfilevisitLog_New where profileid = '" + txtProfileId_VisitLog.Text + "'";
                //DataTable dtMemberCodeList = objDb.GetDataTable(strSql);
                //if (dtMemberCodeList.Rows.Count > 0)
                //{
                //    for (int cnt = 0; cnt < dtMemberCodeList.Rows.Count; cnt++)
                //    {
                //        if (strMemberCode == "")
                //        {
                //            strMemberCode = Convert.ToString(dtMemberCodeList.Rows[cnt]["MemberCode"]);
                //        }
                //        else
                //        {
                //            strMemberCode += "," + Convert.ToString(dtMemberCodeList.Rows[cnt]["MemberCode"]);
                //        }
                //    }
                //}
                //if (strMemberCode != "")
                //{
                tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                Objtbl_MemberMasterProp.MemberCode = 0;
                Objtbl_MemberMasterProp.ProfileID = txtProfileId_VisitLog.Text; // ProfileID;
                Objtbl_MemberMasterProp.isLogedin = true;
                Objtbl_MemberMasterProp.LoginCode = 0;

                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsMemberMaster = Objtbl_MemberMasterBAL.Load_MemberDetails(Objtbl_MemberMasterProp);
                if (dsMemberMaster.Tables[0].Rows.Count > 0)
                {
                    lblBirthYear.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["DateOfBirth"]);
                    lblName.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["MemberName"]);
                    lblCast.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["Caste"]);
                }

                LvwDetails.Clear();
                strSql = " Select MM.ProfileID,MM.MemberName,convert(nvarchar,MM.DateofBirth,103) as DateofBirth,MM.MobileNo,MM.MobileNo1,MM.LandlineNo,";
                strSql += " SM.StateCity,Convert(varchar(4),MM.DateOfBirth,111) as BornYear, Cas.Caste,CASE WHEN MM.Gender = 0 then 'MALE' else 'FEMALE' END AS Gender, ";
                strSql += " PL.VisitDate";
                strSql += " from tbl_MemberMaster MM ";
                strSql += " inner join dbo.tbl_StateCity SM on SM.StateCityCode=MM.StateCity ";
                strSql += " LEFT OUTER JOIN dbo.tbl_Caste AS Cas ON MM.Caste = Cas.CasteCode  ";
                strSql += " INNER JOIN tbl_ProfilevisitLog_new PL ON PL.MemberCode= MM.MemberCode";
                //strSql += " WHERE MM.isActive IN (1 ,2) and MM.MemberCode in (" + strMemberCode + ") ";
                strSql += " WHERE MM.isActive IN (1 ,2) and PL.profileid='" + txtProfileId_VisitLog.Text + "' order by PL.VisitDate DESC  ";
                DataTable dtDetails = objDb.GetDataTable(strSql);
                if (dtDetails.Rows.Count > 0)
                {
                    lblTotalCnt.Text = "Total : " + Convert.ToString(dtDetails.Rows.Count);
                    FieldLength = new int[] { 150, 200, 100, 120, 0, 0, 100, 80, 80, 0, 200 };
                    objGlobal.FillListView(LvwDetails, dtDetails, FieldLength);
                    LvwDetails.CheckBoxes = false;
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_ProfileHistory_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                Objtbl_MemberMasterProp.MemberCode = 0;
                Objtbl_MemberMasterProp.ProfileID = txtProfileId_ProfileHistory.Text; // ProfileID;
                Objtbl_MemberMasterProp.isLogedin = true;
                Objtbl_MemberMasterProp.LoginCode = 0;

                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsMemberMaster = Objtbl_MemberMasterBAL.Load_MemberDetails(Objtbl_MemberMasterProp);
                if (dsMemberMaster.Tables[0].Rows.Count > 0)
                {
                    lblBirthYear.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["DateOfBirth"]);
                    lblName.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["MemberName"]);
                    lblCast.Text = Convert.ToString(dsMemberMaster.Tables[0].Rows[0]["Caste"]);
                }

                int MemberCode = Objtbl_MemberMasterBAL.GetMemberCode(txtProfileId_ProfileHistory.Text);
                LvwDetails.Clear();
                if (rbtnDetails.Checked)
                {
                    strSql = " Select MM.ProfileID,MM.MemberName,convert(nvarchar,MM.DateofBirth,103) as DateofBirth,MM.MobileNo,MM.MobileNo1,MM.LandlineNo,";
                    strSql += " SM.StateCity,Convert(varchar(4),MM.DateOfBirth,111) as BornYear, Cas.Caste,CASE WHEN MM.Gender = 0 then 'MALE' else 'FEMALE' END AS Gender, ";
                    strSql += " PL.VisitDate";
                    strSql += " from tbl_MemberMaster MM ";
                    strSql += " inner join dbo.tbl_StateCity SM on SM.StateCityCode=MM.StateCity ";
                    strSql += " LEFT OUTER JOIN dbo.tbl_Caste AS Cas ON MM.Caste = Cas.CasteCode  ";
                    strSql += " INNER JOIN tbl_ProfilevisitLog_new PL ON PL.profileid= MM.profileid";
                    strSql += " WHERE MM.isActive IN (1 ,2) and PL.MemberCode = " + MemberCode + " order by PL.VisitDate DESC  ";
                    //strSql += " WHERE MM.isActive IN (1 ,2) and PL.profileid='" + txtProfileId_VisitLog.Text + "' order by PL.VisitDate DESC  ";
                    DataTable dtDetails = objDb.GetDataTable(strSql);
                    if (dtDetails.Rows.Count > 0)
                    {
                        lblTotalCnt.Text = "Total : " + Convert.ToString(dtDetails.Rows.Count);
                        FieldLength = new int[] { 150, 200, 100, 120, 0, 0, 100, 80, 80, 0, 150 };
                        objGlobal.FillListView(LvwDetails, dtDetails, FieldLength);
                        LvwDetails.CheckBoxes = false;
                    }
                }
                else if (rbtnSummary.Checked)
                {
                    strSql = " SELECT count(*) as Count,Profileid from tbl_ProfilevisitLog_new where MemberCode=" + MemberCode + " group by Profileid order by count(*) desc ";
                    DataTable dtDetails = objDb.GetDataTable(strSql);
                    if (dtDetails.Rows.Count > 0)
                    {
                        lblTotalCnt.Text = "Total : " + Convert.ToString(dtDetails.Rows.Count);
                        FieldLength = new int[] { 150, 200 };
                        objGlobal.FillListView(LvwDetails, dtDetails, FieldLength);
                        LvwDetails.CheckBoxes = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
