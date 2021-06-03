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
    public partial class rfrmRegistrationReports : Form
    {
        string strCaste = "", strEducation = "", strCountry = "", strCity = "", strMaritalStatus;
        DataView dvCaste, dvEducation, dvCountry, dvCity, dvMaritalStatus;
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;

        public rfrmRegistrationReports()
        {
            InitializeComponent();
        }

        private void rfrmRegistrationReports_Load(object sender, EventArgs e)
        {
            try
            {
                FillList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rfrmRegistrationReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
                ((frmMain)base.MdiParent).mnuRegistrationReport.Enabled = true;
                ((frmMain)base.MdiParent).pnlMain.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillList()
        {
            try
            {
                //strCaste = " SELECT 'All' AS Caste,0 as ORD,0 AS CasteCode";
                //strCaste += " UNION ALL ";
                strCaste = " SELECT Caste,1 as ORD,CasteCode FROM tbl_Caste ORDER BY ORD,Caste";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwCaste, strCaste, FieldLength);

                //strEducation = " SELECT 'All' AS Education,0 as ORD,-1 AS EducationCode ";
                //strEducation += " UNION ALL ";
                //strEducation += " SELECT Education,1 as ORD,EducationCode FROM tbl_Education ORDER BY ORD,Education";
                //FieldLength = new int[] { 100, 0, 0 };
                //objGlobal.FillListView(LvwEducation, strEducation, FieldLength);

                strCountry = " SELECT 'All' AS Country,0 as ORD,0 AS CountryCode ";
                strCountry += " UNION ALL ";
                strCountry += " SELECT Country,1 as ORD,CountryCode FROM tbl_Country ORDER BY ORD,Country";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwCountry, strCountry, FieldLength);

                DataTable dtBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeFrom.DataSource = dtBornYear;
                ddlPAgeFrom.DisplayMember = "Number";
                ddlPAgeFrom.ValueMember = "NValue";

                DataTable dtToBornYear = objGlobal.GetYearList(1950, DateTime.Now.Year);
                ddlPAgeTo.DataSource = dtToBornYear;
                ddlPAgeTo.DisplayMember = "Number";
                ddlPAgeTo.ValueMember = "NValue";

                strMaritalStatus = " SELECT 'All' AS MaritalStatus,0 as ORD,0 AS MaritalStatusCode ";
                strMaritalStatus += " UNION ALL ";
                strMaritalStatus += " SELECT MaritalStatus,1 as ORD,MaritalStatusCode from tbl_MaritalStatus ORDER BY ORD";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwMaritalStatus, strMaritalStatus, FieldLength);
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
                string strCond = "", Caste_Sel = "", Country_Sel = "", State_Sel = "",MaritalStatus_Sel="";
                if (rdbtnMale.Checked)
                {
                    strCond += " AND MM.Gender=0 ";
                }
                else if (rdbtnFemale.Checked)
                {
                    strCond += " AND MM.Gender=1 ";
                }
                for (int cnt = 0; cnt < LvwCaste.Items.Count; cnt++)
                {
                    if (LvwCaste.Items[cnt].Checked)
                    {
                        if (Caste_Sel == "")
                        {
                            Caste_Sel = LvwCaste.Items[cnt].SubItems[LvwCaste.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Caste_Sel += "," + LvwCaste.Items[cnt].SubItems[LvwCaste.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Caste_Sel != "")
                {
                    strCond += " AND MM.Caste in (" + Caste_Sel + ")";
                }
                if (Convert.ToString(ddlPAgeFrom.SelectedValue) != Convert.ToString(ddlPAgeTo.SelectedValue))
                {
                    strCond += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom.SelectedValue + " AND " + ddlPAgeTo.SelectedValue + " ";
                }
                for (int cnt = 1; cnt < LvwCountry.Items.Count; cnt++)
                {
                    if (LvwCountry.Items[cnt].Checked)
                    {
                        if (Country_Sel == "")
                        {
                            Country_Sel = LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                        }
                        else
                        {
                            Country_Sel += "," + LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                        }
                    }
                }
                if (Country_Sel != "")
                {
                    strCond += " AND MM.Country in (" + Country_Sel + ")";
                }
                for (int cnt = 1; cnt < LvwState.Items.Count; cnt++)
                {
                    if (LvwState.Items[cnt].Checked)
                    {
                        if (State_Sel == "")
                        {
                            State_Sel = LvwState.Items[cnt].SubItems[LvwState.Columns.Count - 1].Text;
                        }
                        else
                        {
                            State_Sel += "," + LvwState.Items[cnt].SubItems[LvwState.Columns.Count - 1].Text;
                        }
                    }
                }
                if (State_Sel != "")
                {
                    strCond += " AND MM.StateCity in (" + State_Sel + ")";
                }
                for (int cnt = 1; cnt < LvwMaritalStatus.Items.Count; cnt++)
                {
                    if (LvwMaritalStatus.Items[cnt].Checked)
                    {
                        if (MaritalStatus_Sel == "")
                        {
                            MaritalStatus_Sel = LvwMaritalStatus.Items[cnt].SubItems[LvwMaritalStatus.Columns.Count - 1].Text;
                        }
                        else
                        {
                            MaritalStatus_Sel += "," + LvwMaritalStatus.Items[cnt].SubItems[LvwMaritalStatus.Columns.Count - 1].Text;
                        }
                    }
                }
                if (MaritalStatus_Sel != "")
                {
                    strCond += " AND MM.MaritalStatus in (" + MaritalStatus_Sel + ")";
                }
                if (dtpFromDate.Value.ToShortDateString() != dtpToDate.Value.ToShortDateString())
                {
                    strCond += " AND MM.RegisterDate BETWEEN '" + dtpFromDate.Value.ToString("dd/MMM/yyyy") + "' AND '" + dtpToDate.Value.ToString("dd/MMM/yyyy") + "'";
                }
                if (strCond == "")
                {
                    MessageBox.Show("Please select Something", "Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.GET_REGISTERED_MEMBER(strCond);
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer objReportViewer = new frmReportViewer();
                    ReportDocument cryRpt = new ReportDocument();
                    string strPath = "";
                    strPath = Application.StartupPath + @"\REPORTS\RegisterReport.rpt";
                    cryRpt.Load(strPath);
                    cryRpt.SetDataSource(dsdata.Tables[0]);
                    objReportViewer.RptViewer.ReportSource = cryRpt;
                    objReportViewer.RptViewer.Refresh();
                    objReportViewer.ShowDialog();
                    objReportViewer.Focus();
                }
                else
                {
                    MessageBox.Show("No data found", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LvwCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LvwCountry_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                string strCountry_Sel = "";
                for (int cnt = 0; cnt < LvwCountry.Items.Count; cnt++)
                {
                    if (LvwCountry.Items[cnt].Checked)
                    {
                        if (strCountry_Sel == "")
                        {
                            strCountry_Sel = LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                        }
                        else
                        {
                            strCountry_Sel += "," + LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text;
                        }
                    }
                }
                if (strCountry_Sel != "")
                {
                    if (strCountry_Sel != "0")
                    {
                        strCity = " SELECT 'All' AS StateCity,-1 AS StateCityCode";
                        strCity += " UNION ALL ";
                        strCity += " SELECT StateCity,StateCityCode FROM tbl_StateCity WHERE CountryCode in (" + strCountry_Sel + ") ORDER BY StateCity";
                    }
                    else
                    {
                        strCity = " SELECT 'All' AS StateCity,0 AS StateCityCode";
                    }
                    FieldLength = new int[] { 100, 0 };
                    objGlobal.FillListView(LvwState, strCity, FieldLength);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
