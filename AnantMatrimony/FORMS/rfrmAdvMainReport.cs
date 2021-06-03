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
    public partial class rfrmAdvMainReport : Form
    {
        string strCaste = "", strEducation = "", strCountry = "", strCity = "", strMaritalStatus = "", strHeight = "", strWeight = "", strIncome = "";
        DataView dvCaste, dvEducation, dvCountry, dvCity, dvMaritalStatus, dvHeight, dvWeight;
        dbInteraction objDb = new dbInteraction();
        Global objGlobal = new Global();
        int[] FieldLength;

        public rfrmAdvMainReport()
        {
            InitializeComponent();
        }

        private void rfrmAdvMainReport_Load(object sender, EventArgs e)
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

                strHeight = " select Height,HeightCM from tbl_Height order by HeightCM";
                FieldLength = new int[] { 100, 0 };
                objGlobal.FillListView(LvwHeight, strHeight, FieldLength);

                //for (int cnt = 30; cnt < 200; cnt++)
                //{

                //}
                string strManglic = " SELECT 'Yes' as Manglik ,0 as Code ";
                strManglic += " UNION ALL ";
                strManglic += " SELECT 'No' as Manglik,1 as Code ";
                strManglic += " UNION ALL   ";
                strManglic += " SELECT 'Doesn''t Know'  as Manglik,2 as Code";
                FieldLength = new int[] { 100, 0 };
                objGlobal.FillListView(LvwManglic, strManglic, FieldLength);

                //strIncome = " SELECT 'All' AS AnnualIncome,0 as ORD,-1 AS AnnualIncomeCurrencyCode ";
                //strIncome += " UNION ALL ";
                strIncome += " SELECT AnnualIncome,1 as ORD,AnnualIncomeCode FROM tbl_AnnualIncome ";
                FieldLength = new int[] { 100, 0, 0 };
                objGlobal.FillListView(LvwIncome, strIncome, FieldLength);
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
                string Caste_Sel = "", Education_Sel = "", Country_Sel = "", State_Sel = "", MaritalStatus_Sel = "", Height_Sel = "", strWeight_Sel = "", StrManglik = "", Incom_Sel = "";

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
                for (int cnt = 0; cnt < LvwHeight.Items.Count; cnt++)
                {
                    if (LvwHeight.Items[cnt].SubItems[LvwHeight.Columns.Count - 1].Text != "-1")
                    {
                        if (LvwHeight.Items[cnt].Checked)
                        {
                            if (Height_Sel == "")
                            {
                                Height_Sel = LvwHeight.Items[cnt].SubItems[LvwHeight.Columns.Count - 1].Text;
                            }
                            else
                            {
                                Height_Sel += "," + LvwHeight.Items[cnt].SubItems[LvwHeight.Columns.Count - 1].Text;
                            }
                        }
                    }
                }
                for (int cnt = 0; cnt < LvwManglic.Items.Count; cnt++)
                {
                    if (LvwManglic.Items[cnt].SubItems[LvwManglic.Columns.Count - 1].Text != "-1")
                    {
                        if (LvwManglic.Items[cnt].Checked)
                        {
                            if (StrManglik == "")
                            {
                                StrManglik = LvwManglic.Items[cnt].SubItems[LvwManglic.Columns.Count - 1].Text;
                            }
                            else
                            {
                                StrManglik += "," + LvwManglic.Items[cnt].SubItems[LvwManglic.Columns.Count - 1].Text;
                            }
                        }
                    }
                }
                for (int cnt = 0; cnt < LvwIncome.Items.Count; cnt++)
                {
                    if (LvwIncome.Items[cnt].SubItems[LvwIncome.Columns.Count - 1].Text != "-1")
                    {
                        if (LvwIncome.Items[cnt].Checked)
                        {
                            if (Incom_Sel == "")
                            {
                                Incom_Sel = LvwIncome.Items[cnt].SubItems[LvwIncome.Columns.Count - 1].Text;
                            }
                            else
                            {
                                Incom_Sel += "," + LvwIncome.Items[cnt].SubItems[LvwIncome.Columns.Count - 1].Text;
                            }
                        }
                    }
                }
                string strSql = "";
                strSql = " Select MemberCode from tbl_MemberMaster MM where MM.isActive IN (1 ,2)  AND MM.Gender =" + (rdbtnMale.Checked == true ? "0" : "1");
                strSql += " AND Convert(varchar(4),MM.DateOfBirth,111) Between " + ddlPAgeFrom.Text + " AND " + ddlPAgeTo.Text + "";
                if (State_Sel != "")
                {
                    strSql += " AND MM.StateCity IN (" + State_Sel + ")";
                }
                if (MaritalStatus_Sel != "")
                {
                    strSql += " AND MM.MaritalStatus IN (" + MaritalStatus_Sel + ") ";
                }
                if (Education_Sel != "")
                {
                    strSql += " AND MM.Education IN (" + Education_Sel + ")";
                }
                if (Country_Sel != "")
                {
                    strSql += " AND MM.VisaCountry IN (" + Country_Sel + ")";
                }
                if (Caste_Sel != "")
                {
                    strSql += " AND MM.Caste IN (" + Caste_Sel + ")";
                }
                if (Height_Sel != "")
                {
                    strSql += " AND MM.Height IN (" + Height_Sel + ")";
                }
                if (strWeight_Sel != "")
                {
                    strSql += " AND MM.Weight IN (" + strWeight_Sel + ")";
                }
                if (StrManglik != "")
                {
                    strSql += " AND MM.Manglik IN (" + StrManglik + ")";
                }
                if (txtFromWeight.Text != "" && txtToWeight.Text != "")
                {
                    strSql += " AND Weight BETWEEN " + txtFromWeight.Text + " AND " + txtToWeight.Text + "";
                }
                if (Incom_Sel != "")
                {
                    strSql += " AND AnnualIncome IN (" + Incom_Sel + ")";
                }
                if (txtFromDate.Text != txtToDate.Text)
                {
                    strSql += " AND RegisterDate between '" + txtFromDate.Value.ToString("dd/MMM/yyyy") + "' and '" + txtToDate.Value.ToString("dd/MMM/yyyy") + "'";
                }
                strSql += " ORDER BY MemberCode DESC";
                //if (State_Sel == "")
                //{
                //    MessageBox.Show("Please select any State", "State Selection Validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    return;
                //}
                string strMemberCode = "";
                DataTable dt = objDb.GetDataTable(strSql);
                if (dt.Rows.Count > 0)
                {
                    for (int cnt = 0; cnt < dt.Rows.Count; cnt++)
                    {
                        if (strMemberCode == "")
                        {
                            strMemberCode = Convert.ToString(dt.Rows[cnt]["MemberCode"]);
                        }
                        else
                        {
                            strMemberCode += "," + Convert.ToString(dt.Rows[cnt]["MemberCode"]);
                        }
                    }
                }
                int PageCount = 0, RecordCount = 0;
                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsdata = objtbl_MemberMasterBAL.Load_ProfileList_New(strMemberCode);
                dsdata.Tables[0].TableName = "dsMainReport";
                frmReportViewer objReportViewer = new frmReportViewer();
                ReportDocument cryRpt = new ReportDocument();
                string strPath = "";
                if (rbtnFirstPage.Checked)
                {
                    strPath = Application.StartupPath + @"\REPORTS\ProfileReport.rpt";
                }
                else if (rbtnPhoneNumber.Checked)
                {
                    strPath = Application.StartupPath + @"\REPORTS\MemberPhoneNumber.rpt";
                }
                else if(rbtnEmail.Checked)
                {
                    strPath = Application.StartupPath + @"\REPORTS\MemberEmailList.rpt";
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
            }
        }

        private void rfrmAdvMainReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuAdvanceMainReport.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            objGlobal.onlyNumber(sender, e, false);
        }

        private void txtToWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            objGlobal.onlyNumber(sender, e, false);
        }

        private void LvwCountry_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
