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
    public partial class rfrmHeadingWiseReport : Form
    {
        string strCaste = "", strEducation = "", strCountry = "", strCity = "", strMaritalStatus = "", strIncome = "";
        DataView dvCaste, dvEducation, dvCountry, dvCity, dvMaritalStatus;
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;

        public rfrmHeadingWiseReport()
        {
            InitializeComponent();
        }

        private void grpOption_Enter(object sender, EventArgs e)
        {

        }

        private void rfrmHeadingWiseReport_Load(object sender, EventArgs e)
        {
            FillList();
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

                strEducation = " SELECT 'All' AS Education,0 as ORD,-1 AS EducationCode ";
                strEducation += " UNION ALL ";
                strEducation += " SELECT Education,1 as ORD,EducationCode FROM tbl_Education ORDER BY ORD,Education";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwEducation, strEducation, FieldLength);

                strCountry = " SELECT 'All' AS Country,0 as ORD,-1 AS CountryCode ";
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

                strMaritalStatus = " SELECT 'All' AS MaritalStatus,0 as ORD,-1 AS MaritalStatusCode ";
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

        private void LvwCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rfrmHeadingWiseReport_Activated(object sender, EventArgs e)
        {

        }

        private void rfrmHeadingWiseReport_Deactivate(object sender, EventArgs e)
        {

        }

        private void rfrmHeadingWiseReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuMainReport.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void LvwCountry_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void LvwCountry_ItemChecked(object sender, ItemCheckedEventArgs e)
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string Caste_Sel = "", Education_Sel = "", Country_Sel = "", State_Sel = "", MaritalStatus_Sel = "", strHeight = "", strWeight = "";
                tbl_MemberMasterSearchProp Objtbl_MemberMasterSearchProp = new tbl_MemberMasterSearchProp();
                Objtbl_MemberMasterSearchProp.sMemberCode = -1;
                Objtbl_MemberMasterSearchProp.sGender = (rdbtnMale.Checked == true ? "0" : "1");
                Objtbl_MemberMasterSearchProp.sAgeStart = ddlPAgeFrom.Text;
                Objtbl_MemberMasterSearchProp.sAgeUpto = ddlPAgeTo.Text;
                Objtbl_MemberMasterSearchProp.PageNo = 0;
                Objtbl_MemberMasterSearchProp.RecordCount = 0;
                Objtbl_MemberMasterSearchProp.sSqlCondition = true;
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
                Objtbl_MemberMasterSearchProp.sCaste = Caste_Sel;
                if (Caste_Sel == "")
                {
                    MessageBox.Show("Please select any caste", "Caste Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                Country_Sel = "";
                for (int cnt = 0; cnt < LvwCountry.Items.Count; cnt++)
                {
                    if (LvwCountry.Items[cnt].SubItems[LvwCountry.Columns.Count - 1].Text != "-1")
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
                }
                Objtbl_MemberMasterSearchProp.sCountry = Country_Sel;
                //if (Country_Sel == "")
                //{
                //    MessageBox.Show("Please select any Country", "Country Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    return;
                //}
                for (int cnt = 0; cnt < LvwEducation.Items.Count; cnt++)
                {
                    if (LvwEducation.Items[cnt].SubItems[LvwEducation.Columns.Count - 1].Text != "-1")
                    {
                        if (LvwEducation.Items[cnt].Checked)
                        {
                            if (Education_Sel == "")
                            {
                                Education_Sel = LvwEducation.Items[cnt].SubItems[LvwEducation.Columns.Count - 1].Text;
                            }
                            else
                            {
                                Education_Sel += "," + LvwEducation.Items[cnt].SubItems[LvwEducation.Columns.Count - 1].Text;
                            }
                        }
                    }
                }
                Objtbl_MemberMasterSearchProp.sEducation = Education_Sel;
                //if (Education_Sel == "")
                //{
                //    MessageBox.Show("Please select any Education", "Education Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    return;
                //}
                for (int cnt = 0; cnt < LvwMaritalStatus.Items.Count; cnt++)
                {
                    if (LvwMaritalStatus.Items[cnt].SubItems[LvwMaritalStatus.Columns.Count - 1].Text != "-1")
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
                }
                Objtbl_MemberMasterSearchProp.sMaritalStatus = MaritalStatus_Sel;
                //if (MaritalStatus_Sel == "")
                //{
                //    MessageBox.Show("Please select any Marital Status", "Marital Status Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    return;
                //}
                for (int cnt = 0; cnt < LvwState.Items.Count; cnt++)
                {
                    if (LvwState.Items[cnt].SubItems[LvwState.Columns.Count - 1].Text != "-1")
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
                }
                Objtbl_MemberMasterSearchProp.sStateCity = State_Sel;
                //Objtbl_MemberMasterSearchProp.sSqlCondition

                //if (State_Sel == "")
                //{
                //    MessageBox.Show("Please select any State", "State Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    return;
                //}
                int PageCount = 0, RecordCount = 0;
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.Load_ProfileList(Objtbl_MemberMasterSearchProp, ref PageCount, ref RecordCount);
                dsdata.Tables[0].TableName = "dsMainReport";
                frmReportViewer objReportViewer = new frmReportViewer();
                ReportDocument cryRpt = new ReportDocument();
                string strPath = "";
                if (rbtnFirstPage.Checked)
                {
                    strPath = Application.StartupPath + @"\REPORTS\ProfileReport.rpt";
                }
                else if (rbtnEmail.Checked)
                {
                    strPath = Application.StartupPath + @"\REPORTS\MemberEmailList.rpt";
                }
                else if (rbtnPhoneNumber.Checked)
                {
                    strPath = Application.StartupPath + @"\REPORTS\MemberPhoneNumber.rpt";
                }
                cryRpt.Load(strPath);
                cryRpt.SetDataSource(dsdata.Tables[0]);
                objReportViewer.RptViewer.ReportSource = cryRpt;
                objReportViewer.RptViewer.Refresh();
                objReportViewer.ShowDialog();
                objReportViewer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


    }
}
